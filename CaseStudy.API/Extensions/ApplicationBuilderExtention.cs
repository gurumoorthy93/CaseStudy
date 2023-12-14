using CaseStudy.API.Middlewares;

namespace CaseStudy.API.Extensions
{
    public static class ApplicationBuilderExtention
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<ExceptionMiddleware>()
                .UseMiddleware<HttpContextMiddleware>();
        }
    }
}
