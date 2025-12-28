namespace middleware.Middleware
{
    public class HeaderCheckMiddleware
    {
        private readonly RequestDelegate next;

        public HeaderCheckMiddleware(
            RequestDelegate next)
        {
            this.next = next;
        }


        public async Task InvokeAsync(
            HttpContext context)
        {

            if(!context.Request.Headers.TryGetValue("x-api-header",out var value))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Header named as x-api-header doesn't exist in the request");
                return;
            }

            await next(context);



        }
    }
}
