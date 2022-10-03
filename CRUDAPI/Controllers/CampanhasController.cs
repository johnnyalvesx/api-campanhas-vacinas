using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampanhasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public CampanhasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campanha>>> PegarTodasAsCampanhasAsync()
        {
            return await _contexto.Campanhas.ToListAsync();
        }

        [HttpGet("{campanhaId}")]
        public async Task<ActionResult<Campanha>> PegarCampanhaPeloIdAsync(int campanhaId)
        {
            Campanha campanha = await _contexto.Campanhas.FindAsync(campanhaId);

            if (campanha == null)
                return NotFound();

            return campanha;
        }

        [HttpPost]
        public async Task<ActionResult<Campanha>> SalvarCampanhaAsync(Campanha campanha)
        {
            await _contexto.Campanhas.AddAsync(campanha);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarCampanhaAsync(Campanha campanha)
        {
            _contexto.Campanhas.Update(campanha);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{campanhaId}")]
        public async Task<ActionResult> ExcluirCampanhaAsync(int campanhaId)
        {
            Campanha campanha = await _contexto.Campanhas.FindAsync(campanhaId);
            if (campanha == null)
                return NotFound();

            _contexto.Remove(campanha);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
    }
}
