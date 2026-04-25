using ApiProyecto.Data;
using ApiProyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UsuariosController : BaseController
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _context.Usuarios
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    x.Id,
                    x.Usuario,
                    x.Rol
                })
                .ToListAsync();

            return Ok(new { datos = lista });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _context.Usuarios
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Usuario,
                    x.Rol
                })
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioAdminRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Usuario) ||
                string.IsNullOrWhiteSpace(req.Password) ||
                string.IsNullOrWhiteSpace(req.Rol))
            {
                return BadRequest(new { mensaje = "Usuario, contrasena y rol son obligatorios." });
            }

            var usuarioNormalizado = req.Usuario.Trim();
            var rolNormalizado = req.Rol.Trim().ToLowerInvariant();

            var existe = await _context.Usuarios.AnyAsync(x => x.Usuario == usuarioNormalizado);
            if (existe)
            {
                return BadRequest(new { mensaje = "Usuario ya existe." });
            }

            var user = new Usuarios
            {
                Usuario = usuarioNormalizado,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                Rol = rolNormalizado
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario creado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioAdminRequest req)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado." });
            }

            return await ActualizarUsuarioAsync(user, req);
        }

        [HttpPut("{campo}/{valor}")]
        public async Task<IActionResult> PutPorCampo(string campo, string valor, [FromBody] UsuarioAdminRequest req)
        {
            if (!campo.Equals("id", StringComparison.OrdinalIgnoreCase) || !int.TryParse(valor, out var id))
            {
                return BadRequest(new { mensaje = "Clave invalida." });
            }

            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado." });
            }

            return await ActualizarUsuarioAsync(user, req);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado." });
            }

            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario eliminado correctamente" });
        }

        [HttpDelete("{campo}/{valor}")]
        public async Task<IActionResult> DeletePorCampo(string campo, string valor)
        {
            if (!campo.Equals("id", StringComparison.OrdinalIgnoreCase) || !int.TryParse(valor, out var id))
            {
                return BadRequest(new { mensaje = "Clave invalida." });
            }

            return await Delete(id);
        }

        [HttpGet("roles")]
        public ActionResult GetRoles()
        {
            var roles = new[]
            {
                new { id = "admin", nombre = "Admin" },
                new { id = "docente", nombre = "Docente" },
                new { id = "coordinador", nombre = "Coordinador" },
                new { id = "lector", nombre = "Lector" }
            };

            return Ok(new { datos = roles });
        }

        private async Task<IActionResult> ActualizarUsuarioAsync(Usuarios user, UsuarioAdminRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Usuario) || string.IsNullOrWhiteSpace(req.Rol))
            {
                return BadRequest(new { mensaje = "Usuario y rol son obligatorios." });
            }

            var usuarioNormalizado = req.Usuario.Trim();
            var rolNormalizado = req.Rol.Trim().ToLowerInvariant();

            var existe = await _context.Usuarios.AnyAsync(x => x.Id != user.Id && x.Usuario == usuarioNormalizado);
            if (existe)
            {
                return BadRequest(new { mensaje = "Ya existe otro usuario con ese nombre." });
            }

            user.Usuario = usuarioNormalizado;
            user.Rol = rolNormalizado;

            if (!string.IsNullOrWhiteSpace(req.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
            }

            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario actualizado correctamente" });
        }
    }
}
