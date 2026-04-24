using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.investigacion;

namespace ApiProyecto.Controllers
{
    [Route("api/as_linea")]
    [ApiController]
    public class AsLineaController : BaseController
    {
        private readonly AppDbContext _context;
        public AsLineaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.AsLineas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(AsLinea item)
        {
            _context.AsLineas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{linea}/{area}")]
        public async Task<IActionResult> Delete(int linea, int area)
        {
            var item = await _context.AsLineas.FindAsync(linea, area);
            if (item == null) return NotFound();
            _context.AsLineas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}