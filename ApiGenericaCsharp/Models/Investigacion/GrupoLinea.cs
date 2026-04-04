using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("grupo_linea")]
public class GrupoLinea
{
    [Key, Column(Order = 0)]
    public int grupo_investigacion { get; set; }

    [Key, Column(Order = 1)]
    public int linea_investigacion { get; set; }
}
