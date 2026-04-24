using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.investigacion;

namespace ApiProyecto.Controllers
{
    [Route("api/semillero_linea")]
    [ApiController]
    public class SemilleroLineaController : BaseController
    {
        private readonly AppDbContext _context;
        public SemilleroLineaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.SemilleroLineas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpGet("{semillero}/{linea}")]
        public async Task<ActionResult> Get(int semillero, int linea)
        {
            var item = await _context.SemilleroLineas.FindAsync(semillero, linea);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post(SemilleroLinea item)
        {
            _context.SemilleroLineas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{semillero}/{linea}")]
        public async Task<IActionResult> Delete(int semillero, int linea)
        {
            var item = await _context.SemilleroLineas.FindAsync(semillero, linea);
            if (item == null) return NotFound();
            _context.SemilleroLineas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}