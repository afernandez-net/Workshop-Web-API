using Camones.Shop.Api.Filters;
using Camones.Shop.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camones.Shop
{
    public static class Extensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            var identityUrl = "http://localhost:7000";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.Audience = "camonesshop";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                    //    .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    //ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
        public static IServiceCollection AddSwaggerAuth(this IServiceCollection services)
        {
            var identityUrl = "http://localhost:7000";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {  Title = "Camones.Shop", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Password = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{identityUrl}/connect/authorize"),
                            TokenUrl = new Uri($"{identityUrl}/connect/token"),
                            RefreshUrl = new Uri($"{identityUrl}/connect/authorize"),
                            Scopes = new Dictionary<string, string>
                                {
                                    {"camonesshop", "API de servicios Camones Shop"}
                                }
                        }
                    }
                });

                c.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            return services;
        }

        public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var env = serviceScope.ServiceProvider.GetService<IWebHostEnvironment>();

                var context = serviceScope.ServiceProvider.GetRequiredService<ShopContext>();

                context.Database.EnsureCreated();
            }

            return app;
        }

        public static IApplicationBuilder UseSwaggerAuth(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de servicios Camones Shop");
                c.RoutePrefix = "docs";
                c.OAuthClientId("camonesweb");
                c.OAuthClientSecret("secret");
            });

            return app;
        }
    }
}
