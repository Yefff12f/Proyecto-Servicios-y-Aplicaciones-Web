using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Data;
using ApiProyecto.Models.Curricular;
using Microsoft.AspNetCore.Authorization;
namespace ApiProyecto.Controllers.Curricular
{
    [Route("api/docente_departamento")]
    [ApiController]
    public class DocenteDepartamentoController : BaseController
    {
        private readonly AppDbContext _context;
        public DocenteDepartamentoController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.DocentesDepartamentos.ToListAsync();
            return Ok(new { datos = lista });
        }

        [HttpPost]
        public async Task<ActionResult> Post(DocenteDepartamento item)
        {
            _context.DocentesDepartamentos.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro creado correctamente" });
        }

        [HttpPut("{docente}/{departamento}")]
        public async Task<IActionResult> Put(int docente, int departamento, DocenteDepartamento item)
        {
            var existente = await _context.DocentesDepartamentos.FindAsync(docente, departamento);
            if (existente == null) return NotFound();
            existente.dedicacion = item.dedicacion;
            existente.modalidad = item.modalidad;
            existente.fecha_ingreso = item.fecha_ingreso;
            existente.fecha_salida = item.fecha_salida;
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado correctamente" });
        }

        [HttpDelete("{docente}/{departamento}")]
        public async Task<IActionResult> Delete(int docente, int departamento)
        {
            var item = await _context.DocentesDepartamentos.FindAsync(docente, departamento);
            if (item == null) return NotFound();
            _context.DocentesDepartamentos.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}