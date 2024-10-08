using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiFilter.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("OnActionExecuting : Executing action method");

            var queryParams=context.HttpContext.Request.Query;
            var routeParams = context.RouteData.Values;

            _logger.LogInformation("Query Parameters : {QueryParams}",queryParams);
            _logger.LogInformation("Route Parameters : {RouteParams}", routeParams);

            if (!queryParams.ContainsKey("name"))
            {
                context.Result = new BadRequestObjectResult("Missing required name query param");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("OnActionExecuted : Executed action method");
        }

    }
}
