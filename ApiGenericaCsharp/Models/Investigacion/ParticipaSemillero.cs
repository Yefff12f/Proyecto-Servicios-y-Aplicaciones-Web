using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("participa_semillero")]
public class ParticipaSemillero
{
    [Key, Column(Order = 0)]
    public int docente { get; set; }

    [Key, Column(Order = 1)]
    public int semillero { get; set; }

    [MaxLength(45)]
    public string? rol { get; set; }

    public DateTime? fecha_ini { get; set; }
    public DateTime? fecha_fin { get; set; }
}
