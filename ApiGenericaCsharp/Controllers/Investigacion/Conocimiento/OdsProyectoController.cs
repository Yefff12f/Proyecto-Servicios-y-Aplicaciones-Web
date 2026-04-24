using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Proyecto;

namespace ApiProyecto.Controllers.Proyecto
{
    [Route("api/ods_proyecto")]
    [ApiController]
    public class OdsProyectoController : BaseController
    {
        private readonly AppDbContext _context;
        public OdsProyectoController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.OdsProyectos.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(OdsProyecto item)
        {
            _context.OdsProyectos.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{proyecto}/{ods}")]
        public async Task<IActionResult> Delete(int proyecto, int ods)
        {
            var item = await _context.OdsProyectos.FindAsync(proyecto, ods);
            if (item == null) return NotFound();
            _context.OdsProyectos.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}