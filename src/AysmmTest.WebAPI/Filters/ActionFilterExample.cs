using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AysmmTest.WebAPI.Filters
{
    public class ActionFilterExample : IActionFilter
    {
        private readonly ILogger<ActionFilterExample> _logger;

        public ActionFilterExample(ILogger<ActionFilterExample> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
            _logger.LogInformation("OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
            _logger.LogInformation("OnActionExecuted");
        }
    }
}
