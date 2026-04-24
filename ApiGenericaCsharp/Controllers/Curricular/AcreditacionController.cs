using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;
using Microsoft.AspNetCore.Authorization;
namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/acreditacion")]
    [ApiController]
    public class AcreditacionController : BaseController
    {
        private readonly AppDbContext _context;
        public AcreditacionController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.Acreditaciones.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _context.Acreditaciones.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
[Authorize(Roles = "admin, user")]
        [HttpPost]
        public async Task<ActionResult> Post(Acreditacion item)
        {
            _context.Acreditaciones.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }
       [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Acreditacion item)
        {
            if (id != item.id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpPut("{campo}/{valor}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutPorCampo(string campo, string valor, Acreditacion item)
        {
            if (campo.ToLower() != "id" || !int.TryParse(valor, out int id)) return BadRequest();
            item.id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Acreditaciones.FindAsync(id);
            if (item == null) return NotFound();
            _context.Acreditaciones.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }

        [HttpDelete("{campo}/{valor}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletePorCampo(string campo, string valor)
        {
            if (campo.ToLower() != "id" || !int.TryParse(valor, out int id)) return BadRequest();
            var item = await _context.Acreditaciones.FindAsync(id);
            if (item == null) return NotFound();
            _context.Acreditaciones.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}