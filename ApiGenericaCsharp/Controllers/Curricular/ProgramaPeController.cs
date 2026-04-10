using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;

namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/programa_pe")]
    [ApiController]
    public class ProgramaPeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProgramaPeController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.ProgramasPe.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProgramaPe item)
        {
            _context.ProgramasPe.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{programa}/{practica}")]
        public async Task<IActionResult> Delete(int programa, int practica)
        {
            var item = await _context.ProgramasPe.FindAsync(programa, practica);
            if (item == null) return NotFound();
            _context.ProgramasPe.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}