using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;
using Microsoft.AspNetCore.Authorization;
namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/an_programa")]
    [ApiController]
    public class AnProgramaController : BaseController
    {
        private readonly AppDbContext _context;
        public AnProgramaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.AnProgramas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(AnPrograma item)
        {
            _context.AnProgramas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpDelete("{aspecto}/{programa}")]
        public async Task<IActionResult> Delete(int aspecto, int programa)
        {
            var item = await _context.AnProgramas.FindAsync(aspecto, programa);
            if (item == null) return NotFound();
            _context.AnProgramas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}