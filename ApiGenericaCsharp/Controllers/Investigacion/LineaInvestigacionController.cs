using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.investigacion;

namespace ApiProyecto.Controllers
{
    [Route("api/Linea_Investigacion")]
    [ApiController]
    public class LineaInvestigacionController : BaseController
    {
        private readonly AppDbContext _context;

        public LineaInvestigacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LineaInvestigacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineaInvestigacion>>> GetLineas()
        {
            return await _context.LineasInvestigacion.ToListAsync();
        }

        // GET: api/LineaInvestigacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineaInvestigacion>> GetLinea(int id)
        {
            var linea = await _context.LineasInvestigacion.FindAsync(id);
            if (linea == null) return NotFound();
            return linea;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> PostLinea(LineaInvestigacion linea)
        {
            _context.LineasInvestigacion.Add(linea);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" }); // ✅
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinea(int id, LineaInvestigacion linea)
        {
            if (id != linea.id) return BadRequest();
            _context.Entry(linea).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" }); // ✅
        }
     [HttpPut("{campo}/{valor}")]
public async Task<IActionResult> PutLineaPorCampo(string campo, string valor, LineaInvestigacion linea)
{
    if (campo.ToLower() != "id" || !int.TryParse(valor, out int id)) return BadRequest();
    linea.id = id;
    _context.Entry(linea).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return Ok(new { mensaje = "Registro actualizado correctamente" });
}

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinea(int id)
        {
            var linea = await _context.LineasInvestigacion.FindAsync(id);
            if (linea == null) return NotFound();
            _context.LineasInvestigacion.Remove(linea);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" }); // ✅
        }
[HttpDelete("{campo}/{valor}")]
public async Task<IActionResult> DeleteLineaPorCampo(string campo, string valor)
{
    if (campo.ToLower() != "id" || !int.TryParse(valor, out int id)) return BadRequest();
    var linea = await _context.LineasInvestigacion.FindAsync(id);
    if (linea == null) return NotFound();
    _context.LineasInvestigacion.Remove(linea);
    await _context.SaveChangesAsync();
    return Ok(new { mensaje = "Registro eliminado correctamente" });
}
    }
}