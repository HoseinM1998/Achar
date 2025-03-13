using AcharDomainCore.Entites.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Achar.Endpoint.Api.ActionFillter
{
    public class FilterApiKey : IActionFilter
    {
        private const string ApiKeyHeaderName = "apikey";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var siteSetting = context.HttpContext.RequestServices.GetService<SiteSetting>();
            var apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName].ToString();

            if (string.IsNullOrWhiteSpace(apiKey) || siteSetting == null || apiKey != siteSetting.ApiKey)
            {
                context.Result = new UnauthorizedObjectResult(new { message = "شما دسترسی به این ای پی آی را ندارید." });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}