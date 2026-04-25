namespace ApiProyecto.Models
{
    public class UsuarioAdminRequest
    {
        public required string Usuario { get; set; }
        public string? Password { get; set; }
        public required string Rol { get; set; }
    }
}
