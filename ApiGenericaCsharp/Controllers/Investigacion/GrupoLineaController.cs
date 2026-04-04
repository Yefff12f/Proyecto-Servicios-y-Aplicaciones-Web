using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.investigacion;

namespace ApiProyecto.Controllers
{
    [Route("api/grupo_linea")]
    [ApiController]
    public class GrupoLineaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GrupoLineaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.GrupoLineas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(GrupoLinea item)
        {
            _context.GrupoLineas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{grupo}/{linea}")]
        public async Task<IActionResult> Delete(int grupo, int linea)
        {
            var item = await _context.GrupoLineas.FindAsync(grupo, linea);
            if (item == null) return NotFound();
            _context.GrupoLineas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}