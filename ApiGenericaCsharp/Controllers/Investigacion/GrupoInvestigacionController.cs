using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.investigacion;

namespace ApiProyecto.Controllers
{
    [Route("api/grupo_investigacion")]
    [ApiController]
    public class GrupoInvestigacionController : BaseController
    {
        private readonly AppDbContext _context;

        public GrupoInvestigacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoInvestigacion>>> GetGrupos()
        {
            return await _context.GruposInvestigacion.ToListAsync();
        }

        // GET ID
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoInvestigacion>> GetGrupo(int id)
        {
            var grupo = await _context.GruposInvestigacion.FindAsync(id);
            if (grupo == null) return NotFound();
            return grupo;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> PostGrupo(GrupoInvestigacion grupo)
        {
            _context.GruposInvestigacion.Add(grupo);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" }); // ✅
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupo(int id, GrupoInvestigacion grupo)
        {
            if (id != grupo.id) return BadRequest();
            _context.Entry(grupo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" }); // ✅
        }

        [HttpPut("{campo}/{valor}")]
public async Task<IActionResult> PutGrupoPorCampo(string campo, string valor, GrupoInvestigacion grupo)
{
    if (campo.ToLower() != "id" || !int.TryParse(valor, out int id)) return BadRequest();
    grupo.id = id;
    _context.Entry(grupo).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return Ok(new { mensaje = "Registro actualizado correctamente" });
}

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupo(int id)
        {
            var grupo = await _context.GruposInvestigacion.FindAsync(id);
            if (grupo == null) return NotFound();
            _context.GruposInvestigacion.Remove(grupo);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" }); // ✅
  
        }

       [HttpDelete("{campo}/{valor}")]
 public async Task<IActionResult> DeleteGrupoPorCampo(string campo, string valor)
   {
    if (campo.ToLower() != "id" || !int.TryParse(valor, out int id))
        return BadRequest();
    
    var grupo = await _context.GruposInvestigacion.FindAsync(id);
    if (grupo == null) return NotFound();
    _context.GruposInvestigacion.Remove(grupo);
    await _context.SaveChangesAsync();
    return Ok(new { mensaje = "Registro eliminado correctamente" });
     }

    }
}