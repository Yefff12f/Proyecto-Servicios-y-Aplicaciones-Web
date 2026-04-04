using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("as_linea")]
public class AsLinea
{
    [Key, Column(Order = 0)]
    public int linea_investigacion { get; set; }

    [Key, Column(Order = 1)]
    public int area_aplicacion { get; set; }
}
