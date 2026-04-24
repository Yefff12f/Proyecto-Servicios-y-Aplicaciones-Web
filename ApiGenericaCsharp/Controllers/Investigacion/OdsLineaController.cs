using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Investigacion;

namespace ApiProyecto.Controllers.Investigacion
{
    [Route("api/ods_linea")]
    [ApiController]
    public class OdsLineaController : BaseController
    {
        private readonly AppDbContext _context;
        public OdsLineaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.OdsLineas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(OdsLinea item)
        {
            _context.OdsLineas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{linea}/{ods}")]
        public async Task<IActionResult> Delete(int linea, int ods)
        {
            var item = await _context.OdsLineas.FindAsync(linea, ods);
            if (item == null) return NotFound();
            _context.OdsLineas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}