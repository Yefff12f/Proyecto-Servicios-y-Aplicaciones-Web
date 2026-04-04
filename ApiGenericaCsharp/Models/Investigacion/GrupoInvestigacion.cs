using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("grupo_investigacion")]
public class GrupoInvestigacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int id { get; set; }

    [Required]
    [MaxLength(60)]
    public string nombre { get; set; } = null!;

    [MaxLength(128)]
    public string? url_grupLAC { get; set; }

    [MaxLength(10)]
    public string? categoria { get; set; }

    [MaxLength(10)]
    public string? convocatoria { get; set; }

    public DateTime? fecha_fundacion { get; set; }

    public int? universidad { get; set; }

    public bool? interno { get; set; }

    [MaxLength(45)]
    public string? ambito { get; set; }
}
