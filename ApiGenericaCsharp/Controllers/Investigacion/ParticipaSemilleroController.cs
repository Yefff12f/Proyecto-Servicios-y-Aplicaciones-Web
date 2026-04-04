using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.investigacion;

namespace ApiProyecto.Controllers
{
    [Route("api/participa_semillero")]
    [ApiController]
    public class ParticipaSemilleroController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ParticipaSemilleroController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.ParticipaSemilleros.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(ParticipaSemillero item)
        {
            _context.ParticipaSemilleros.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{docente}/{semillero}")]
        public async Task<IActionResult> Delete(int docente, int semillero)
        {
            var item = await _context.ParticipaSemilleros.FindAsync(docente, semillero);
            if (item == null) return NotFound();
            _context.ParticipaSemilleros.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}