using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NiceShop.Models;

namespace NiceShop.Filters;

public class HandelErrorAttribute:IExceptionFilter {
    private readonly ILogger<HandelErrorAttribute> _logger;

    public HandelErrorAttribute(ILogger<HandelErrorAttribute> logger) {
        _logger = logger;
       
    }
    public void OnException(ExceptionContext context) {
        var requestId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier;
        var viewModel = new ErrorViewModel { RequestId = requestId };
    
        // Log the error
        _logger.LogError(context.Exception, "An unhandled exception occurred during execution.");
    
        // Set the result to your View
        context.Result = new ViewResult 
        { 
            ViewName = "Error",
            ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState) 
            { 
                Model = viewModel 
            }
        };
    
        context.ExceptionHandled = true;
    }
}