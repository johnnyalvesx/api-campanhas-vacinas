using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Repositories;

namespace VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Implementations
{
    public class CampanhaManager : ICampanhaManager
    {
        private readonly ICampanhaManager campanhaRepository;

        public CampanhaManager(ICampanhaManager campanhaRepository)
        {
            this.campanhaRepository = campanhaRepository;
        }

        public async Task<IEnumerable<Campanha>> PegarCampanhasAsync()
        {
            return await campanhaRepository.PegarCampanhasAsync();
        }

        public async Task<Campanha> PegarCampanhaPorIdAsync(int id)
        {
            return await campanhaRepository.PegarCampanhaPorIdAsync(id);
        }

        public async Task<Campanha> CadastrarCampanhaAsync(Campanha campanha)
        {
            return await campanhaRepository.CadastrarCampanhaAsync(campanha);
        }

        public async Task<Campanha> AtualizarCampanhaAsync(Campanha campanha)
        {
            return await campanhaRepository.AtualizarCampanhaAsync(campanha);
        }

        public async Task DeletarCampanhaAsync(int id)
        {
            await campanhaRepository.DeletarCampanhaAsync(id);
        }
    }
}
