using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace VacinasCampanhas.VacinasCampanhas.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vacinas e Campanhas", Version = "v1" });
                c.AddFluentValidationRulesScoped();
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = String.Empty;
            });
        }
    }
}
