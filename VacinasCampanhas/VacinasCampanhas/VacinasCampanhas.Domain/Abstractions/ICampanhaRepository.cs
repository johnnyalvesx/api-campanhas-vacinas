using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Domain.Abstractions
{
    public interface ICampanhaRepository
    {
        Task<IEnumerable<Vacina>> PegarCampanhasAsync();

        Task<Vacina> PegarCampanhaPorIdAsync(int id);

        Task<Vacina> CadastrarCampanhaAsync(Vacina vacina);

        Task<Vacina> AtualizarCampanhaAsync(Vacina vacina);

        Task DeletarCampanhaAsync(int id);
    }
}

