using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Profesional;

namespace ApiProyecto.Controllers.Profesional
{
    [Route("api/red_docente")]
    [ApiController]
    public class RedDocenteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RedDocenteController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.RedDocentes.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(RedDocente item)
        {
            _context.RedDocentes.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{red}/{docente}")]
        public async Task<IActionResult> Put(int red, int docente, RedDocente item)
        {
            var existente = await _context.RedDocentes.FindAsync(red, docente);
            if (existente == null) return NotFound();
            existente.fecha_inicio = item.fecha_inicio;
            existente.fecha_fin = item.fecha_fin;
            existente.act_destacadas = item.act_destacadas;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{red}/{docente}")]
        public async Task<IActionResult> Delete(int red, int docente)
        {
            var item = await _context.RedDocentes.FindAsync(red, docente);
            if (item == null) return NotFound();
            _context.RedDocentes.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}