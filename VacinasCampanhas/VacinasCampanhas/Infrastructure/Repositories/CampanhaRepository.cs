using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;

namespace VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Repositories
{
    public class CampanhaRepository : ICampanhaRepository
    {
        private readonly Contexto contexto;

        public CampanhaRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<Campanha>> PegarCampanhasAsync()
        {
            return await contexto.Campanhas.AsNoTracking().ToListAsync();
        }

        public async Task<Campanha> PegarCampanhaPorIdAsync(int id)
        {
            return await contexto.Campanhas.FindAsync(id);
        }

        public async Task<Campanha> CadastrarCampanhaAsync(Campanha campanha)
        {
            await contexto.Campanhas.AddAsync(campanha);
            await contexto.SaveChangesAsync();
            return campanha;
        }

        public async Task<Campanha> AtualizarCampanhaAsync(Campanha campanha)
        {
            var campanhaConsultada = await contexto.Campanhas.FindAsync(campanha.CampanhaId);
            if (campanhaConsultada == null)
            {
                return null;
            }

            contexto.Entry(campanhaConsultada).CurrentValues.SetValues(campanha);

            contexto.Campanhas.Update(campanhaConsultada);
            await contexto.SaveChangesAsync();
            return campanhaConsultada;
        }

        public async Task DeletarCampanhaAsync(int id)
        {
            var campanhaConsultada = await contexto.Campanhas.FindAsync(id);
            contexto.Campanhas.Remove(campanhaConsultada);
            await contexto.SaveChangesAsync();
        }
    }
}
