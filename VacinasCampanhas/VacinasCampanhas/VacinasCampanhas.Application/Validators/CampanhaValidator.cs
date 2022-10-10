using FluentValidation;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Application.Validators
{
    public class CampanhaValidator : AbstractValidator<Campanha>
    {
        public CampanhaValidator()
        {
            RuleFor(x => x.NomeDaCampanha).NotNull().NotEmpty();
            RuleFor(x => x.DataDeInicio).NotNull().NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.DataDeTermino).NotNull().NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(x => x.StatusDaCampanha).NotNull().NotEmpty();
        }
    }
}
