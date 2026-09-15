using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.Services;

namespace NiceShop.Controllers.Api;

public class AiChatRequestDto
{
    public string Message { get; set; } = string.Empty;
    public string? Model { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class AiChatController : ControllerBase
{
    private readonly IAiChatService _aiChatService;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public AiChatController(
        IAiChatService aiChatService,
        ApplicationDbContext dbContext,
        UserManager<ApplicationUser> userManager)
    {
        _aiChatService = aiChatService;
        _dbContext = dbContext;
        _userManager = userManager;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] AiChatRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
            return BadRequest("Message cannot be empty.");

        // For this example, we assume the user is logged in. 
        var user = await _userManager.GetUserAsync(User);
        string userId = user?.Id;

        if (userId == null)
        {
            // For testing via curl without auth, just grab the first user in the DB.
            var firstUser = await _dbContext.Users.FirstOrDefaultAsync();
            if (firstUser == null)
                return BadRequest("No users exist in the database to bind this chat to.");
            
            userId = firstUser.Id;
        }

        // Save User Message
        var userMessage = new ChatMessage
        {
            UserId = userId,
            Role = "user",
            Content = request.Message,
            Timestamp = System.DateTime.UtcNow
        };
        _dbContext.ChatMessages.Add(userMessage);
        await _dbContext.SaveChangesAsync();

        // Fetch truncated history (last 10 messages for this user)
        var history = await _dbContext.ChatMessages
            .Where(m => m.UserId == userId)
            .OrderByDescending(m => m.Timestamp)
            .Take(10)
            .ToListAsync();

        // Reverse to chronological order
        history.Reverse();

        // Note: The history already includes the user's latest message because we saved it above.
        // We will remove the very last one from the history array before sending, since the service adds it manually,
        // OR we can just pass the history (minus the last) and the userMessage separately.
        var historyToPass = history.Take(history.Count - 1).ToList();

        // Get AI Response
        string aiResponseText = await _aiChatService.GetAgentResponseAsync(historyToPass, request.Message, request.Model);

        // Save AI Response
        var aiMessage = new ChatMessage
        {
            UserId = userId,
            Role = "assistant",
            Content = aiResponseText,
            Timestamp = System.DateTime.UtcNow
        };
        _dbContext.ChatMessages.Add(aiMessage);
        await _dbContext.SaveChangesAsync();

        return Ok(new { response = aiResponseText });
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var user = await _userManager.GetUserAsync(User);
        string userId = user?.Id;

        if (userId == null)
        {
            var firstUser = await _dbContext.Users.FirstOrDefaultAsync();
            if (firstUser == null)
                return Ok(new object[] { });
            
            userId = firstUser.Id;
        }

        var history = await _dbContext.ChatMessages
            .Where(m => m.UserId == userId && m.Role != "tool") // Only return user/assistant visible messages
            .OrderByDescending(m => m.Timestamp)
            .Take(10)
            .Select(m => new { role = m.Role, content = m.Content })
            .ToListAsync();

        history.Reverse();
        return Ok(history);
    }
}
