using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_dotNET6_WebAPI_Template.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "X-ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Check for "ApiKey" Header in the incoming request if exists
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            /*
             * It is not a good practice to check for API Keys with a .Equals() method and passing a literal string.
             * 
             * Normally, you would check if the API Key exists in the Database with the related entity. If so,
             * the request is Authorized. Otherwise, it would be rejected and a 401 Unauthorized result is returned to the client.
             */

            if (!potentialApiKey.Equals("MyAppSuperSecretKey"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
