using Microsoft.AspNetCore.Mvc;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampanhasController : ControllerBase
    {
        private readonly ICampanhaManager campanhaManager;

        public CampanhasController(ICampanhaManager campanhaManager)
        {
            this.campanhaManager = campanhaManager;
        }

        [HttpGet]
        public async Task<IActionResult> PegarCampanhasAsync()
        {
            return Ok(await campanhaManager.PegarCampanhasAsync());
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> AtualizarCampanhaAsync(Campanha campanha)
        {
            var campanhaAtualizada = await campanhaManager.AtualizarCampanhaAsync(campanha);
            if (campanhaAtualizada == null)
            {
                return NotFound();
            }
            return Ok(campanhaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCampanhaAsync(int id)
        {
            await campanhaManager.DeletarCampanhaAsync(id);
            return NoContent();
        }
    }
}
