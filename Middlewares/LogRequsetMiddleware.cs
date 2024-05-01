
using Microsoft.AspNetCore.Identity.Data;

namespace App.Demo.NetCore.Middlewares
{
    public class LogRequsetMiddleware : IMiddleware
    {
        private readonly ILogger<LogRequsetMiddleware> _logger;

        public LogRequsetMiddleware(ILogger<LogRequsetMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var httpRoute = context.Request.Path.ToString();
            _logger.LogWarning($"request to the route :{httpRoute}");
            await next(context);
        }
    }
}
