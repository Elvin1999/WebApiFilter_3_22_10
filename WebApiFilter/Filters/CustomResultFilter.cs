using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiFilter.Filters
{
    public class CustomResultFilter : IResultFilter
    {
        private readonly ILogger _logger;

        public CustomResultFilter(ILogger<CustomResultFilter> logger)
        {
            _logger = logger;
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headers=context.HttpContext.Request.Headers;
            var method=context.HttpContext.Request.Method;

            _logger.LogInformation("HTTP Method : {Method}", method);
            _logger.LogInformation("Request Headers : {Headers}", headers);

            if(context.Result is ObjectResult result)
            {
                result.Value = new { Message = "This result was modified by a result filter",Original=result.Value };
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("Result executed");
        }

    }
}
