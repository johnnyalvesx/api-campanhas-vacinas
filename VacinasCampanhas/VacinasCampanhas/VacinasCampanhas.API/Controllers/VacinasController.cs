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
        //private readonly Contexto _contexto;
        private readonly IVacinaManager vacinaManager;

        public VacinasController(IVacinaManager vacinaManager)
        {
            this.vacinaManager = vacinaManager;
        }

        //public VacinasController(Contexto contexto)
        //{
        //    _contexto = contexto;
        //}

        [HttpGet]
        public async Task<IActionResult> PegarVacinasAsync()
        {
            return Ok(await vacinaManager.PegarVacinasAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> PegarVacinaPorIdAsync(int id)
        {
            return Ok(await vacinaManager.PegarVacinaPorIdAsync(id));
        }

        //[HttpPost]
        //public async Task<ActionResult<Vacina>> SalvarVacinaAsync(Vacina vacina)
        //{
        //    await _contexto.Vacinas.AddAsync(vacina);
        //    await _contexto.SaveChangesAsync();

        //    return Ok();
        //}

        //[HttpPut]
        //public async Task<ActionResult> AtualizarVacinaAsync(Vacina vacina)
        //{
        //    _contexto.Vacinas.Update(vacina);
        //    await _contexto.SaveChangesAsync();

        //    return Ok();
        //}

        //[HttpDelete("{vacinaId}")]
        //public async Task<ActionResult> ExcluirVacinaAsync(int vacinaId)
        //{
        //    Vacina vacina = await _contexto.Vacinas.FindAsync(vacinaId);
        //    if (vacina == null)
        //        return NotFound();

        //    _contexto.Remove(vacina);
        //    await _contexto.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
