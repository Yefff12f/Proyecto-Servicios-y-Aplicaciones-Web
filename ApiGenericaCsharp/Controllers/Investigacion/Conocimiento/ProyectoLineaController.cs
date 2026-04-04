using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.conocimiento;

namespace ApiProyecto.Controllers.conocimiento
{
    [Route("api/proyecto_linea")]
    [ApiController]
    public class ProyectoLineaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProyectoLineaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get() => Ok(new { datos = await _context.ProyectoLineas.ToListAsync() });

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _context.ProyectoLineas.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProyectoLinea item)
        {
            _context.ProyectoLineas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProyectoLinea item)
        {
            if (id != item.id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpPut("{campo}/{valor}")]
        public async Task<IActionResult> PutPorCampo(string campo, string valor, ProyectoLinea item)
        {
            if (campo.ToLower() != "id" || !int.TryParse(valor, out int id)) return BadRequest();
            item.id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ProyectoLineas.FindAsync(id);
            if (item == null) return NotFound();
            _context.ProyectoLineas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }

        [HttpDelete("{campo}/{valor}")]
        public async Task<IActionResult> DeletePorCampo(string campo, string valor)
        {
            if (campo.ToLower() != "id" || !int.TryParse(valor, out int id)) return BadRequest();
            var item = await _context.ProyectoLineas.FindAsync(id);
            if (item == null) return NotFound();
            _context.ProyectoLineas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}