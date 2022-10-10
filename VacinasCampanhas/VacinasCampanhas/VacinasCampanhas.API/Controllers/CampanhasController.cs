using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;
using VacinasCampanhas.VacinasCampanhas.Domain.Implementations;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;

namespace VacinasCampanhas.VacinasCampanhas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampanhasController : ControllerBase
    {
        private readonly ICampanhaManager campanhaManager;

        public CampanhasController(IVacinaManager vacinaManager)
        {
            this.campanhaManager = campanhaManager;
        }

        [HttpGet]
        public async Task<IActionResult> PegarCampanhasAsync()
        {
            return Ok(await campanhaManager.PegarCampanhasAsync());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> PegarCampanhaPeloIdAsync(int id)
        {
            return Ok(await campanhaManager.PegarCampanhaPorIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCampanhaAsync(Campanha campanha)
        {
            var campanhaInserida = await campanhaManager.CadastrarCampanhaAsync(campanha);


            return CreatedAtAction(nameof(PegarCampanhasAsync), new { id = campanha.Id }, campanha);
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
