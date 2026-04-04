using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("aliado_proyecto")]
    public class AliadoProyecto
    {
        [Key, Column(Order = 0)]
        public int aliado { get; set; }

        [Key, Column(Order = 1)]
        public int proyecto { get; set; }
    }
}