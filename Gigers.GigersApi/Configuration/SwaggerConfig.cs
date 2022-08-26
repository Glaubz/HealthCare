using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit.HealthCareApi.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerDefaultValues>();

                var _security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new string[] { }
                    }
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT seguindo a sintaxe: Bearer {seu token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(_security);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            //Middleware para verificar autorização a documentação Swagger
            //app.UseMiddleware<SwaggerAuthorizedMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(
                options =>
                {
                    foreach(var description in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint(url: $"/swagger/{description.GroupName}/swagger.json", name: description.GroupName.ToUpperInvariant());
                });

            return app;
        }
    }

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            OpenApiInfo _info = new OpenApiInfo
            {
                Title = "API - HealthCare",
                Version = description.ApiVersion.ToString(),
                Description = "WebApi para o sistema HealthCare",
                Contact = new OpenApiContact { Name = "Matheus Glauber", Email = "teste@emailteste.com" }
                //TermsOfService = "",
                //License = ""
            };

            if (description.IsDeprecated)
                _info.Description += " Esta versão esta obsoleta!";

            return _info;
        }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            ApiDescription _apiDescription = context.ApiDescription;

            operation.Deprecated = _apiDescription.IsDeprecated();

            if (operation.Parameters is null)
                return;

            foreach (OpenApiParameter parameter in operation.Parameters)
            {
                //Link que ajudou em resolução de erro "Failed to load API definition Fetch error in Swagger(undefined /swagger/v1/swagger.json)"
                //https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1147

                ApiParameterDescription description = _apiDescription.ParameterDescriptions.First(apiParameterDescription => apiParameterDescription.Name == parameter.Name);
                ApiParameterRouteInfo routeInfo = description.RouteInfo;

                if (string.IsNullOrEmpty(parameter.Name))
                    parameter.Name = description.ModelMetadata?.Name;

                if (parameter.Description is null)
                    parameter.Description = description.ModelMetadata?.Description;

                if (routeInfo is null)
                    continue;

                parameter.Required |= description.IsRequired;
            }
        }
    }

    public class SwaggerAuthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerAuthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger") && !context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
