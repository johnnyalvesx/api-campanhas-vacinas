using FluentValidation;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Application.Validators
{
    public class VacinaValidator : AbstractValidator<Vacina>
    {
        public VacinaValidator()
        {
            RuleFor(x => x.NomeDaVacina).NotNull().NotEmpty().MaximumLength(25);
            RuleFor(x => x.DicaDaVacina).MaximumLength(255);
        }

    }
}
