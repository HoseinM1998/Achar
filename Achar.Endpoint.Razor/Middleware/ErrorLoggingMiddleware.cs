using Newtonsoft.Json;
using Serilog;

namespace Achar.Endpoint.Razor.Middleware
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            Log.Information("Request entered ErrorLoggingMiddleware");
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var message = $"An error occurred: {ex.Message}";

                Log.Error(ex, message);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    error = message,
                }));
            }
        }
    }

    public static class Extensions
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorLoggingMiddleware>();
            return app;
        }
    }
}
