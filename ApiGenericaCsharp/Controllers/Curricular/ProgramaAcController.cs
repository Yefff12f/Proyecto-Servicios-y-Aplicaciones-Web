using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;

namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/programa_ac")]
    [ApiController]
    public class ProgramaAcController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProgramaAcController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.ProgramasAc.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProgramaAc item)
        {
            _context.ProgramasAc.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{programa}/{area}")]
        public async Task<IActionResult> Delete(int programa, int area)
        {
            var item = await _context.ProgramasAc.FindAsync(programa, area);
            if (item == null) return NotFound();
            _context.ProgramasAc.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}