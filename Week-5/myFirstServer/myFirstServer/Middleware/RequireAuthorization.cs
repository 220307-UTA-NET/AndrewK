namespace myFirstServer.Middleware
{
    public class RequireAuthorization
    {
        // Fields
        private readonly RequestDelegate _next;

        // Constructors
        public RequireAuthorization(RequestDelegate next)
        {
            _next = next;
        }

        // Methods
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query["authorization"] == "true")
            {
                // "You're good. Let whatever is next on the pipeline deal with this."
                await _next(context);
            }
            else
            {
                // If we don't have authorization, then what?
                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Error! Not authorized!");
            }
        }
    }
}
