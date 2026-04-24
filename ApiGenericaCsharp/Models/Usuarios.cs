namespace ApiProyecto.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public required string Usuario { get; set; }
        public required string Password { get; set; }
        public required string Rol { get; set; }
    }
}
