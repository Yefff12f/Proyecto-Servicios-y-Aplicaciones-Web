using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.conocimiento;

namespace ApiProyecto.Controllers.conocimiento
{
    [Route("api/proyecto")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProyectoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.Proyectos.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _context.Proyectos.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Proyecto item)
        {
            _context.Proyectos.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Proyecto item)
        {
            if (id != item.id) return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpPut("{campo}/{valor}")]
        public async Task<IActionResult> PutPorCampo(string campo, string valor, Proyecto item)
        {
            if (campo.ToLower() != "id" || !int.TryParse(valor, out int id))
                return BadRequest();

            item.id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Proyectos.FindAsync(id);
            if (item == null) return NotFound();

            _context.Proyectos.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }

        [HttpDelete("{campo}/{valor}")]
        public async Task<IActionResult> DeletePorCampo(string campo, string valor)
        {
            if (campo.ToLower() != "id" || !int.TryParse(valor, out int id))
                return BadRequest();

            var item = await _context.Proyectos.FindAsync(id);
            if (item == null) return NotFound();

            _context.Proyectos.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}