using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;
using Microsoft.AspNetCore.Authorization;
namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/aa_rc")]
    [ApiController]
    public class AaRcController : BaseController
    {
        private readonly AppDbContext _context;
        public AaRcController(AppDbContext context) { _context = context; }
        

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.AaRcs.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public async Task<ActionResult> Post(AaRc item)
        {
            _context.AaRcs.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{actv}/{rc}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(int actv, int rc, AaRc item)
        {
            var existente = await _context.AaRcs.FindAsync(actv, rc);
            if (existente == null) return NotFound();
            existente.componente = item.componente;
            existente.semestre = item.semestre;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{actv}/{rc}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int actv, int rc)
        {
            var item = await _context.AaRcs.FindAsync(actv, rc);
            if (item == null) return NotFound();
            _context.AaRcs.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}