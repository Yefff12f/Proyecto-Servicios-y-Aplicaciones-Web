using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;
using Microsoft.AspNetCore.Authorization;
namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/alianza")]
    [ApiController]
    public class AlianzaController : BaseController
    {
        private readonly AppDbContext _context;
        public AlianzaController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.Alianzas.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(Alianza item)
        {
            _context.Alianzas.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{aliado}/{departamento}")]
        public async Task<IActionResult> Put(int aliado, int departamento, Alianza item)
        {
            var existente = await _context.Alianzas.FindAsync(aliado, departamento);
            if (existente == null) return NotFound();
            existente.fecha_inicio = item.fecha_inicio;
            existente.fecha_fin = item.fecha_fin;
            existente.docente = item.docente;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{aliado}/{departamento}")]
        public async Task<IActionResult> Delete(int aliado, int departamento)
        {
            var item = await _context.Alianzas.FindAsync(aliado, departamento);
            if (item == null) return NotFound();
            _context.Alianzas.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}