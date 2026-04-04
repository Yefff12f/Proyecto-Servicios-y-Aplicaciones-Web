using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("linea_investigacion")]
public class LineaInvestigacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
     public int id { get; set; }

    [Required]
    [MaxLength(45)]
    public string nombre { get; set; } = null!;

    [MaxLength(256)]
    public string? descripcion { get; set; }
}
