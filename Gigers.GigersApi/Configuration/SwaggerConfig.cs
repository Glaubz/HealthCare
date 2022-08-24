using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fit.HealthCareApi.Configuration
{
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
            var info = new OpenApiInfo
            {
                Title = "API - HealthCare",
                Version = description.ApiVersion.ToString(),
                Description = "WebApi para o sistema HealthCare",
                Contact = new OpenApiContact { Name = "Matheus Glauber", Email = "teste@emailteste.com" }
                //TermsOfService = "",
                //License = ""
            };

            if (description.IsDeprecated)
            {
                info.Description += " Esta versão esta obsoleta!";
            }

            return info;
        }
    }
}
