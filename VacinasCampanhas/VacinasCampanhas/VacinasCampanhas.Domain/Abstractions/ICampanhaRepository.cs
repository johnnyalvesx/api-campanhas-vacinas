using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Domain.Abstractions
{
    public interface ICampanhaRepository
    {
        Task<IEnumerable<Campanha>> PegarCampanhasAsync();

        Task<Campanha> PegarCampanhaPorIdAsync(int id);

        Task<Campanha> CadastrarCampanhaAsync(Campanha campanha);

        Task<Campanha> AtualizarCampanhaAsync(Campanha campanha);

        Task DeletarCampanhaAsync(int id);
    }
}

