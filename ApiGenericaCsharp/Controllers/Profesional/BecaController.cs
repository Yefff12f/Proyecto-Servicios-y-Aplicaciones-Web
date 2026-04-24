using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Profesional;

namespace ApiProyecto.Controllers.Profesional
{
    [Route("api/beca")]
    [ApiController]
    public class BecaController : BaseController
    {
        private readonly AppDbContext _context;
        public BecaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.Becas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(Beca item)
        {
            _context.Becas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{estudios}")]
        public async Task<IActionResult> Put(int estudios, Beca item)
        {
            var existente = await _context.Becas.FindAsync(estudios);
            if (existente == null) return NotFound();
            existente.tipo = item.tipo;
            existente.institucion = item.institucion;
            existente.fecha_inicio = item.fecha_inicio;
            existente.fecha_fin = item.fecha_fin;
            existente.pais = item.pais;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{estudios}")]
        public async Task<IActionResult> Delete(int estudios)
        {
            var item = await _context.Becas.FindAsync(estudios);
            if (item == null) return NotFound();
            _context.Becas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}