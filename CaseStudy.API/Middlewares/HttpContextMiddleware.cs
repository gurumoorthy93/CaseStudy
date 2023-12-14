using CaseStudy.Core.Common;

namespace CaseStudy.API.Middlewares
{
    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ActionContext actionContext)
        {
            if(context.User.Identity?.IsAuthenticated ?? false)
            {
                actionContext.UserId = Convert.ToInt32(context.User.Claims.Where(x => x.Type == "userid").FirstOrDefault()?.Value);
            }

            await _next.Invoke(context);
        }
    }
}
