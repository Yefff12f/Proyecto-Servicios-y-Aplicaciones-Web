using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.conocimiento;

namespace ApiProyecto.Controllers.conocimiento
{
    [Route("api/aliado_proyecto")]
    [ApiController]
    public class AliadoProyectoController : BaseController
    {
        private readonly AppDbContext _context;
        public AliadoProyectoController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.AliadoProyectos.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(AliadoProyecto item)
        {
            _context.AliadoProyectos.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{aliado}/{proyecto}")]
        public async Task<IActionResult> Delete(int aliado, int proyecto)
        {
            var item = await _context.AliadoProyectos.FindAsync(aliado, proyecto);
            if (item == null) return NotFound();
            _context.AliadoProyectos.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}