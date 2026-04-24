using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.conocimiento;

namespace ApiProyecto.Controllers.Conocimiento
{
    [Route("api/ac_proyecto")]
    [ApiController]
    public class AcProyectoController : BaseController
    {
        private readonly AppDbContext _context;
        public AcProyectoController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.AcProyectos.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(AcProyecto item)
        {
            _context.AcProyectos.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{proyecto}/{area}")]
        public async Task<IActionResult> Delete(int proyecto, int area)
        {
            var item = await _context.AcProyectos.FindAsync(proyecto, area);
            if (item == null) return NotFound();
            _context.AcProyectos.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}