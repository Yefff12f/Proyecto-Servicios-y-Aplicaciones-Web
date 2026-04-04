using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.investigacion;

namespace ApiProyecto.Controllers
{
    [Route("api/ac_linea")]
    [ApiController]
    public class AcLineaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AcLineaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.AcLineas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(AcLinea item)
        {
            _context.AcLineas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{linea}/{area}")]
        public async Task<IActionResult> Delete(int linea, int area)
        {
            var item = await _context.AcLineas.FindAsync(linea, area);
            if (item == null) return NotFound();
            _context.AcLineas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}