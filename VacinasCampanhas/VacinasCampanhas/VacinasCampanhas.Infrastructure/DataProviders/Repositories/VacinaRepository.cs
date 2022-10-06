using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;

namespace VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Repositories
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly Contexto contexto;

        public VacinaRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<Vacina>> PegarVacinasAsync()
        {
            return await contexto.Vacinas.AsNoTracking().ToListAsync();
        }

        public async Task<Vacina> PegarVacinaPorIdAsync(int id)
        {
            return await contexto.Vacinas.FindAsync(id);
        }

        public async Task<Vacina> CadastrarVacinaAsync(Vacina vacina)
        {
            await contexto.Vacinas.AddAsync(vacina);
            await contexto.SaveChangesAsync();
            return vacina;
        }

        public async Task<Vacina> AtualizarVacinaAsync(Vacina vacina)
        {
            var vacinaConsultada = await contexto.Vacinas.FindAsync(vacina.VacinaId);
            if (vacinaConsultada == null)
            {
                return null;
            }

            //vacinaConsultada.NomeDaVacina = vacina.NomeDaVacina;
            //vacinaConsultada.DicaDaVacina = vacina.DicaDaVacina;

            contexto.Entry(vacinaConsultada).CurrentValues.SetValues(vacina);

            contexto.Vacinas.Update(vacinaConsultada);
            await contexto.SaveChangesAsync();
            return vacinaConsultada;

        }

        public async Task DeletarVacinaAsync(int id)
        {
            var vacinaConsultada = await contexto.Vacinas.FindAsync(id);
            contexto.Vacinas.Remove(vacinaConsultada);
            await contexto.SaveChangesAsync();
        }

    }
}
