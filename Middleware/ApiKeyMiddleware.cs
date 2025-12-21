using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace middleware.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;

        public ApiKeyMiddleware(RequestDelegate next,
            IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }


        public async Task Invoke(HttpContext context)
        {

            if(!context.Request.Headers.TryGetValue("x-api-key", out var apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Api Key  doesn't exist in request");
                return;
            }
            // check if provided api key is in sync with api key


            if (apiKey  != configuration.GetSection("ApiKeys:AuthKey").Value)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Api Key are not valid");
                return;
            }



            await next(context);

        }
    }
}
