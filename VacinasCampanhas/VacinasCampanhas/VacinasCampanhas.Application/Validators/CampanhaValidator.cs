using FluentValidation;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Application.Validators
{
    public class CampanhaValidator : AbstractValidator<Campanha>
    {
        public CampanhaValidator()
        {
            RuleFor(x => x.NomeDaCampanha).NotNull().NotEmpty();
            RuleFor(x => x.DataDeInicio).NotNull().NotEmpty();
            RuleFor(x => x.DataDeTermino).NotNull().NotEmpty();
            RuleFor(x => x).Must(x => x.DataDeTermino == default(DateTime) || x.DataDeInicio == default(DateTime) || x.DataDeTermino > x.DataDeInicio)
                .WithMessage("Data de Término precisa ser maior que Data de Início.");
            RuleFor(x => x.StatusDaCampanha).NotNull().NotEmpty();
        }
    }
}
