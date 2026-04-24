using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Proyecto;

namespace ApiProyecto.Controllers.Proyecto
{
    [Route("api/proyecto_linea")]
    [ApiController]
    public class ProyectoLineaController : BaseController
    {
        private readonly AppDbContext _context;
        public ProyectoLineaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.ProyectosLinea.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProyectoLinea item)
        {
            _context.ProyectosLinea.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{proyecto}/{linea}")]
        public async Task<IActionResult> Delete(int proyecto, int linea)
        {
            var item = await _context.ProyectosLinea.FindAsync(proyecto, linea);
            if (item == null) return NotFound();
            _context.ProyectosLinea.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}