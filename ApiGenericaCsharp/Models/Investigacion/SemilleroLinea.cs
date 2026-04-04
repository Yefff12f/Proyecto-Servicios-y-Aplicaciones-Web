using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.investigacion;

[Table("semillero_linea")]
public class SemilleroLinea
{
    [Key, Column(Order = 0)]
    public int semillero { get; set; }

    [Key, Column(Order = 1)]
    public int linea_investigacion { get; set; }
}
