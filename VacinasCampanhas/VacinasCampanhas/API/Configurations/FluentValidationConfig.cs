using FluentValidation.AspNetCore;
using VacinasCampanhas.VacinasCampanhas.Application.Validators;

namespace VacinasCampanhas.VacinasCampanhas.API.Configurations
{
    public static class FluentValidationConfig
    {
        [Obsolete]
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
               .AddFluentValidation(p =>
               p.RegisterValidatorsFromAssemblyContaining<VacinaValidator>());
        }
    }
}
