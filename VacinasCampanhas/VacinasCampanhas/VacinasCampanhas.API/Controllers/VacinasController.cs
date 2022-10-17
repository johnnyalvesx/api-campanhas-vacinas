using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;

namespace VacinasCampanhas.VacinasCampanhas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacinasController : ControllerBase
    {
        private readonly IVacinaManager vacinaManager;

        public VacinasController(IVacinaManager vacinaManager)
        {
            this.vacinaManager = vacinaManager;
        }

        [HttpGet]
        public async Task<IActionResult> PegarVacinasAsync()
        {
            return Ok(await vacinaManager.PegarVacinasAsync());
        }

        [HttpGet("{id}") ]
        public async Task<IActionResult> PegarVacinaPorIdAsync(int id)
        {
            return Ok(await vacinaManager.PegarVacinaPorIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVacinaAsync(Vacina vacina)
        {
            var vacinaInserida = await vacinaManager.CadastrarVacinaAsync(vacina);
            return CreatedAtAction(nameof(PegarVacinasAsync), new { id = vacina.VacinaId }, vacina);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarVacinaAsync(Vacina vacina)
        {
            var vacinaAtualizada = await vacinaManager.AtualizarVacinaAsync(vacina);
            if  (vacinaAtualizada == null)
            {
                return NotFound();
            }
            return Ok(vacinaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarVacinaAsync(int id)
        {
            await vacinaManager.DeletarVacinaAsync(id);
            return NoContent();
        }
    }
}
