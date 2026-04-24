using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.conocimiento;

namespace ApiProyecto.Controllers.conocimiento
{
    [Route("api/termino_clave")]
    [ApiController]
    public class TerminoClaveController : BaseController
    {
        private readonly AppDbContext _context;
        public TerminoClaveController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.TerminosClave.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(TerminoClave item)
        {
            _context.TerminosClave.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{termino}")]
        public async Task<IActionResult> Put(string termino, TerminoClave item)
        {
            var existente = await _context.TerminosClave.FindAsync(termino);
            if (existente == null) return NotFound();
            existente.termino_ingles = item.termino_ingles;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{termino}")]
        public async Task<IActionResult> Delete(string termino)
        {
            var item = await _context.TerminosClave.FindAsync(termino);
            if (item == null) return NotFound();
            _context.TerminosClave.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}