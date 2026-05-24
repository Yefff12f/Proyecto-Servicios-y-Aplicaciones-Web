using ApiProyecto.Data;
using ApiProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        // 🔐 LOGIN
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            var user = _db.Usuarios
                .FirstOrDefault(x => x.Usuario == req.Usuario);

            if (user == null)
                return Unauthorized(new { mensaje = "Usuario no existe" });

            bool ok = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);

            if (!ok)
                return Unauthorized(new { mensaje = "Contraseña incorrecta" });

            var token = GenerarJwt(user);

            return Ok(new
            {
                token,
                usuario = user.Usuario,
                rol = user.Rol
            });
        }

        // 🧾 REGISTER (automático: primer usuario admin)
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginRequest req)
        {
            var existingUser = _db.Usuarios.FirstOrDefault(x => x.Usuario == req.Usuario);

            if (existingUser != null)
                return BadRequest(new { mensaje = "Usuario ya existe" });

            // Si no hay usuarios → es admin
            var rolAsignado = !_db.Usuarios.Any() ? "admin" : "usuario";

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(req.Password);

            var user = new Usuarios
            {
                Usuario = req.Usuario,
                Password = hashedPassword,
                Rol = rolAsignado
            };

            _db.Usuarios.Add(user);
            _db.SaveChanges();

            var token = GenerarJwt(user);

            return Ok(new
            {
                token,
                usuario = user.Usuario,
                rol = user.Rol
            });
        }

        // 👑 SOLO ADMIN CREA USUARIOS CON ROL
        [HttpPost("register-admin")]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterConRol([FromBody] RegisterRequest req)
        {
            var existingUser = _db.Usuarios.FirstOrDefault(x => x.Usuario == req.Usuario);

            if (existingUser != null)
                return BadRequest(new { mensaje = "Usuario ya existe" });

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(req.Password);

            var user = new Usuarios
            {
                Usuario = req.Usuario,
                Password = hashedPassword,
                Rol = req.Rol // admin, editor, usuario
            };

            _db.Usuarios.Add(user);
            _db.SaveChanges();

            return Ok(new { mensaje = "Usuario creado correctamente" });
        }

        // 🔐 GENERAR JWT
        private string GenerarJwt(Usuarios user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Usuario),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim("id", user.Id.ToString())
            };

            var jwtKey = _configuration["Jwt:Key"] ?? "CLAVE_SUPER_SECRETA_123";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("hash")]
        public IActionResult GetHash([FromBody] LoginRequest req)
       {
         var hash = BCrypt.Net.BCrypt.HashPassword(req.Password);
         return Ok(new { hash });
        }
      }
  }
