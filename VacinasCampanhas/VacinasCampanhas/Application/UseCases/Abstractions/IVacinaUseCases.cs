using VacinasCampanhas.Application.UseCases.Abstractions.Base;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.Application.UseCases.Abstractions
{
    public interface IVacinaUseCases
    {
        public interface ICadastrarVacinaUseCaseAsync { }

        public interface IEditarVacinaUseCaseAsync { }

        public interface IPegarVacinasUseCaseAsync { }
    }
}
