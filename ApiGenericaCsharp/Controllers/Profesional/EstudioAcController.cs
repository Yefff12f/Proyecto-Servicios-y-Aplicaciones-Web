using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Profesional;

namespace ApiProyecto.Controllers.Profesional
{
    [Route("api/estudio_ac")]
    [ApiController]
    public class EstudioAcController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudioAcController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.EstudiosAc.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(EstudioAc item)
        {
            _context.EstudiosAc.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{estudio}/{area}")]
        public async Task<IActionResult> Delete(int estudio, int area)
        {
            var item = await _context.EstudiosAc.FindAsync(estudio, area);
            if (item == null) return NotFound();
            _context.EstudiosAc.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}