using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Profesional;

namespace ApiProyecto.Controllers.Profesional
{
    [Route("api/docente")]
    [ApiController]
    public class DocenteController : BaseController
    {
        private readonly AppDbContext _context;
        public DocenteController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.Docentes.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpGet("{cedula}")]
        public async Task<ActionResult> Get(int cedula)
        {
            var item = await _context.Docentes.FindAsync(cedula);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Docente item)
        {
            _context.Docentes.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{cedula}")]
        public async Task<IActionResult> Put(int cedula, Docente item)
        {
            if (cedula != item.cedula) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpPut("{campo}/{valor}")]
        public async Task<IActionResult> PutPorCampo(string campo, string valor, Docente item)
        {
            if (campo.ToLower() != "cedula" || !int.TryParse(valor, out int cedula)) return BadRequest();
            item.cedula = cedula;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{cedula}")]
        public async Task<IActionResult> Delete(int cedula)
        {
            var item = await _context.Docentes.FindAsync(cedula);
            if (item == null) return NotFound();
            _context.Docentes.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }

        [HttpDelete("{campo}/{valor}")]
        public async Task<IActionResult> DeletePorCampo(string campo, string valor)
        {
            if (campo.ToLower() != "cedula" || !int.TryParse(valor, out int cedula)) return BadRequest();
            var item = await _context.Docentes.FindAsync(cedula);
            if (item == null) return NotFound();
            _context.Docentes.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}