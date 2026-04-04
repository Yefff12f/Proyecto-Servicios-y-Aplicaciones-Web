using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.conocimiento;

namespace ApiProyecto.Controllers.conocimiento
{
    [Route("api/desarrolla")]
    [ApiController]
    public class DesarrollaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DesarrollaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.Desarrollas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(Desarrolla item)
        {
            _context.Desarrollas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{docente}/{proyecto}")]
        public async Task<IActionResult> Put(int docente, int proyecto, Desarrolla item)
        {
            var existente = await _context.Desarrollas.FindAsync(docente, proyecto);
            if (existente == null) return NotFound();
            existente.rol = item.rol;
            existente.descripcion = item.descripcion;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{docente}/{proyecto}")]
        public async Task<IActionResult> Delete(int docente, int proyecto)
        {
            var item = await _context.Desarrollas.FindAsync(docente, proyecto);
            if (item == null) return NotFound();
            _context.Desarrollas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}