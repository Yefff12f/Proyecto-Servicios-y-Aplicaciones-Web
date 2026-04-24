namespace ApiProyecto.Models{ 
public class RegisterRequest
{
    public required string Usuario { get; set; }
    public required string Password { get; set; }
    public required string Rol { get; set; }
}
}