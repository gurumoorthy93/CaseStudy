using CaseStudy.Core.Common;
using CaseStudy.Core.Helpers;
using CaseStudy.Core.Services;
using CaseStudy.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CaseStudy.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<ActionContext>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddSingleton<ITokenHelper, TokenHelper>();

            return services;
        }

        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)
        {

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(configOptons =>
            {
                configOptons.RequireHttpsMetadata = false;
                configOptons.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JWTKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = "Identity",
                    ValidateIssuer = true,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
