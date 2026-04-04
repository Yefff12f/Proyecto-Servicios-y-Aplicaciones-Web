using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.conocimiento;  

namespace ApiProyecto.Controllers.conocimiento
{
    [Route("api/aa_proyecto")]
    [ApiController]
    public class AaProyectoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AaProyectoController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.AaProyectos.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(AaProyecto item)
        {
            _context.AaProyectos.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{proyecto}/{area}")]
        public async Task<IActionResult> Delete(int proyecto, int area)
        {
            var item = await _context.AaProyectos.FindAsync(proyecto, area);
            if (item == null) return NotFound();
            _context.AaProyectos.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}