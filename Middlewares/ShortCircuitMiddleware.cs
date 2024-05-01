
namespace App.Demo.NetCore.Middlewares
{
    public class ShortCircuitMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var routeQueries= context.Request.Query.Select(x => x.Key).ToList();
            if (routeQueries.Any( c => c.ToLower().Equals("babak")))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new { Message = "", Success = false });
                return;
            }
            await next(context);
        }
    }
}
