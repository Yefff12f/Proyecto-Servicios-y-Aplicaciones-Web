using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;
using Microsoft.AspNetCore.Authorization;
namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/enfoque_rc")]
    [ApiController]
    public class EnfoqueRcController : BaseController
    {
        private readonly AppDbContext _context;
        public EnfoqueRcController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.EnfoquesRc.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(EnfoqueRc item)
        {
            _context.EnfoquesRc.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{enfoque}/{rc}")]
        public async Task<IActionResult> Delete(int enfoque, int rc)
        {
            var item = await _context.EnfoquesRc.FindAsync(enfoque, rc);
            if (item == null) return NotFound();
            _context.EnfoquesRc.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}