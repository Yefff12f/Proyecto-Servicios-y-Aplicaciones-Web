using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("semillero")]
public class Semillero
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    [MaxLength(60)]
    public string nombre { get; set; } = null!;

    public DateTime? fecha_fundacion { get; set; }

    public int? universidad { get; set; }
}
