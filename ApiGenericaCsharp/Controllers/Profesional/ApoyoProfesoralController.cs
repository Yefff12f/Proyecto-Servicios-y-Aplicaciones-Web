using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Profesional;

namespace ApiProyecto.Controllers.Profesional
{
    [Route("api/apoyo_profesoral")]
    [ApiController]
    public class ApoyoProfesoralController : BaseController
    {
        private readonly AppDbContext _context;
        public ApoyoProfesoralController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.ApoyosProfesoral.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(ApoyoProfesoral item)
        {
            _context.ApoyosProfesoral.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{estudios}")]
        public async Task<IActionResult> Put(int estudios, ApoyoProfesoral item)
        {
            var existente = await _context.ApoyosProfesoral.FindAsync(estudios);
            if (existente == null) return NotFound();
            existente.con_apoyo = item.con_apoyo;
            existente.institucion = item.institucion;
            existente.tipo = item.tipo;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{estudios}")]
        public async Task<IActionResult> Delete(int estudios)
        {
            var item = await _context.ApoyosProfesoral.FindAsync(estudios);
            if (item == null) return NotFound();
            _context.ApoyosProfesoral.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}