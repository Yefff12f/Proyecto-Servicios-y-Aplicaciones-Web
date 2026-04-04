using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("ac_linea")]
public class AcLinea
{
    [Key, Column(Order = 0)]
    public int linea_investigacion { get; set; }

    [Key, Column(Order = 1)]
    public int area_conocimiento { get; set; }
}
