using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Domain.Implementations
{
    public class VacinaManager : IVacinaManager
    {

        private readonly IVacinaRepository vacinaRepository;
        public VacinaManager(IVacinaRepository vacinaRepository)
        {
            this.vacinaRepository = vacinaRepository;
        }

        public async Task<IEnumerable<Vacina>> PegarVacinasAsync()
        {
            return await vacinaRepository.PegarVacinasAsync();
        }

        public async Task<Vacina> PegarVacinaPorIdAsync(int id)
        {
            return await vacinaRepository.PegarVacinaPorIdAsync(id);
        }

        public async Task<Vacina> CadastrarVacinaAsync(Vacina vacina)
        {
            return await vacinaRepository.CadastrarVacinaAsync(vacina);
        }

        public async Task<Vacina> AtualizarVacinaAsync(Vacina vacina)
        {
            return await vacinaRepository.AtualizarVacinaAsync(vacina);
        }

        public async Task DeletarVacinaAsync(int id)
        {
            await vacinaRepository.DeletarVacinaAsync(id);
        }
    }
}
