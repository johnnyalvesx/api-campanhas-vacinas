using VacinasCampanhas.Application.UseCases.Abstractions.Base;
using VacinasCampanhas.VacinasCampanhas.Application.Models;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Application.UseCases
{
    public class CriarCampanhaUseCase : IUseCaseRequestAsync<CriarCampanhaRequestDTO>
    {
        public void Execute(CriarCampanhaRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICriarCampanhaUseCase : IUseCaseRequestAsync<CriarCampanhaRequestDTO>
    {

    }
}
