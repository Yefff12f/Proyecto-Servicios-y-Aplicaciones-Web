using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Proyecto;

namespace ApiProyecto.Controllers.Proyecto
{
    [Route("api/palabras_clave")]
    [ApiController]
    public class PalabrasClaveController : BaseController
    {
        private readonly AppDbContext _context;
        public PalabrasClaveController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.PalabrasClave.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(PalabrasClave item)
        {
            _context.PalabrasClave.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{proyecto}/{termino}")]
        public async Task<IActionResult> Delete(int proyecto, string termino)
        {
            var item = await _context.PalabrasClave.FindAsync(proyecto, termino);
            if (item == null) return NotFound();
            _context.PalabrasClave.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}