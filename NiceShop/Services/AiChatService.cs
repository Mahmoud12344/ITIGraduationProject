using System;
using System.Collections.Generic;
using System.ClientModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NiceShop.Data;
using OpenAI;
using OpenAI.Chat;

namespace NiceShop.Services;

public interface IAiChatService
{
    Task<string> GetAgentResponseAsync(List<NiceShop.Models.ChatMessage> history, string userMessage, string? requestedModel = null);
}

public class AiChatService : IAiChatService
{
    private readonly IConfiguration _config;
    private readonly ILogger<AiChatService> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly IHttpClientFactory _httpClientFactory;

    public AiChatService(
        IConfiguration config, 
        ILogger<AiChatService> logger, 
        ApplicationDbContext dbContext,
        IHttpClientFactory httpClientFactory)
    {
        _config = config;
        _logger = logger;
        _dbContext = dbContext;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> GetAgentResponseAsync(List<NiceShop.Models.ChatMessage> history, string userMessage, string? requestedModel = null)
    {
        var primaryKey = _config["AiChatSettings:PrimaryKey"];
        var fallbackKey = _config["AiChatSettings:FallbackKey"];

        string systemPrompt = @"You are a helpful, expert AI shopping concierge for NiceShop, a luxury fashion store. 
Your primary goal is to help users find products and offer expert styling advice.
IMPORTANT RULES:
1. When displaying prices, ALWAYS format them in Egyptian Pounds (EGP).
2. If the user asks for products, always use the 'SearchProducts' tool to find real items in the database.
3. NEVER make up products, prices, or inventory. Only recommend what the tool returns.
4. Keep your responses concise, elegant, and friendly. 
5. Format your output nicely using markdown, e.g., bullet points for product lists.
6. When mentioning a product, ALWAYS make it a clickable markdown link pointing to its details page using the format: [Product Name](/Products/Details/{Id}).";

        var chatMessages = new List<ChatMessage>
        {
            new SystemChatMessage(systemPrompt)
        };

        foreach (var msg in history)
        {
            if (msg.Role.ToLower() == "user")
                chatMessages.Add(new UserChatMessage(msg.Content));
            else if (msg.Role.ToLower() == "assistant")
                chatMessages.Add(new AssistantChatMessage(msg.Content));
        }
        
        chatMessages.Add(new UserChatMessage(userMessage));

        // Define our Agent Tools
        var searchProductsTool = ChatTool.CreateFunctionTool(
            functionName: "SearchProducts",
            functionDescription: "Searches the database for products by name or category. Use this to find products for the user.",
            functionParameters: BinaryData.FromString(@"
            {
                ""type"": ""object"",
                ""properties"": {
                    ""searchTerm"": {
                        ""type"": ""string"",
                        ""description"": ""The search keyword (e.g. 'shoes', 'red dress')""
                    }
                },
                ""required"": [""searchTerm""]
            }")
        );

        var toolOptions = new ChatCompletionOptions
        {
            Tools = { searchProductsTool }
        };

        if (!string.IsNullOrEmpty(requestedModel))
        {
            try
            {
                _logger.LogInformation("Attempting specifically requested model: {model}", requestedModel);
                ChatClient client;
                if (requestedModel.Contains("gemini", StringComparison.OrdinalIgnoreCase))
                {
                    var options = new OpenAIClientOptions { Endpoint = new Uri("https://generativelanguage.googleapis.com/v1beta/openai/") };
                    client = new ChatClient(requestedModel, new ApiKeyCredential(primaryKey!), options);
                }
                else
                {
                    var specificHttpClient = _httpClientFactory.CreateClient("OpenRouterClient");
                    specificHttpClient.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost:5078");
                    specificHttpClient.DefaultRequestHeaders.Add("X-Title", "NiceShop AI Stylist");
                    var specificOpenRouterOptions = new OpenAIClientOptions { 
                        Endpoint = new Uri("https://openrouter.ai/api/v1/"),
                        Transport = new System.ClientModel.Primitives.HttpClientPipelineTransport(specificHttpClient)
                    };
                    client = new ChatClient(requestedModel, new ApiKeyCredential(fallbackKey!), specificOpenRouterOptions);
                }
                return await ExecuteAgentLoopAsync(client, chatMessages, toolOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Specifically requested AI model failed.");
                return "I'm sorry, but the specific model you requested is currently experiencing technical difficulties.";
            }
        }

        // 1. Try Gemini
        try
        {
            _logger.LogInformation("Attempting primary model (Gemini)...");
            var options = new OpenAIClientOptions { Endpoint = new Uri("https://generativelanguage.googleapis.com/v1beta/openai/") };
            var client = new ChatClient("gemini-3.6-flash", new ApiKeyCredential(primaryKey!), options);
            
            return await ExecuteAgentLoopAsync(client, chatMessages, toolOptions);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Primary model failed. Falling back to OpenRouter Backup 1.");
        }

        // 2. Try OpenRouter (Backup 1)
        var httpClient = _httpClientFactory.CreateClient("OpenRouterClient");
        httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost:5078");
        httpClient.DefaultRequestHeaders.Add("X-Title", "NiceShop AI Stylist");
        var openRouterOptions = new OpenAIClientOptions 
        { 
            Endpoint = new Uri("https://openrouter.ai/api/v1/"),
            Transport = new System.ClientModel.Primitives.HttpClientPipelineTransport(httpClient)
        };

        try
        {
            _logger.LogInformation("Attempting fallback 1 (gemma-4-31b)...");
            var client = new ChatClient("google/gemma-4-31b-it:free", new ApiKeyCredential(fallbackKey!), openRouterOptions);
            return await ExecuteAgentLoopAsync(client, chatMessages, toolOptions);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Fallback 1 failed. Falling back to OpenRouter Backup 2.");
        }

        // 3. Try OpenRouter (Backup 2)
        try
        {
            _logger.LogInformation("Attempting fallback 2 (nemotron-120b)...");
            var client = new ChatClient("nvidia/nemotron-3-super-120b-a12b:free", new ApiKeyCredential(fallbackKey!), openRouterOptions);
            return await ExecuteAgentLoopAsync(client, chatMessages, toolOptions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "All AI models failed.");
            return "I'm sorry, but I am currently experiencing technical difficulties connecting to my AI brain. Please try again later.";
        }
    }

    private async Task<string> ExecuteAgentLoopAsync(ChatClient client, List<ChatMessage> chatMessages, ChatCompletionOptions options)
    {
        int maxIterations = 5;
        for (int i = 0; i < maxIterations; i++)
        {
            var response = await client.CompleteChatAsync(chatMessages, options);
            var completion = response.Value;

            if (completion.FinishReason == ChatFinishReason.ToolCalls)
            {
                // The model wants to call a tool
                chatMessages.Add(new AssistantChatMessage(completion));

                foreach (var toolCall in completion.ToolCalls)
                {
                    if (toolCall.FunctionName == "SearchProducts")
                    {
                        var args = toolCall.FunctionArguments.ToString();
                        // simplistic parsing of {"searchTerm": "..."}
                        string searchTerm = "";
                        var match = System.Text.RegularExpressions.Regex.Match(args, @"""searchTerm""\s*:\s*""([^""]+)""");
                        if (match.Success)
                            searchTerm = match.Groups[1].Value;

                        _logger.LogInformation("Agent called SearchProducts with term: {term}", searchTerm);

                        // Execute against NiceShopDbContext directly!
                        var productsQuery = _dbContext.Products
                            .Where(p => p.IsActive && p.Name.Contains(searchTerm))
                            .Take(5)
                            .Select(p => new { p.Id, p.Name, p.Price, p.Description })
                            .ToList();
                            
                        var products = productsQuery.Select(p => new {
                            p.Id,
                            p.Name,
                            Price = p.Price.ToString("F2") + " EGP",
                            p.Description
                        }).ToList();

                        string resultJson = System.Text.Json.JsonSerializer.Serialize(products);
                        chatMessages.Add(new ToolChatMessage(toolCall.Id, resultJson));
                    }
                }
            }
            else
            {
                // Finished
                return completion.Content[0].Text;
            }
        }

        return "I had to think too long about that one, let's start over.";
    }
}
