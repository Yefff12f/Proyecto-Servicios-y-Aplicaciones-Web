using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;
using Microsoft.AspNetCore.Authorization;
namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/programa_ci")]
    [ApiController]
    public class ProgramaCiController : BaseController
    {
        private readonly AppDbContext _context;
        public ProgramaCiController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.ProgramasCi.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProgramaCi item)
        {
            _context.ProgramasCi.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{programa}/{ci}")]
        public async Task<IActionResult> Delete(int programa, int ci)
        {
            var item = await _context.ProgramasCi.FindAsync(programa, ci);
            if (item == null) return NotFound();
            _context.ProgramasCi.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}