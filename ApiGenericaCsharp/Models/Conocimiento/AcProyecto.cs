using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("ac_proyecto")]
    public class AcProyecto
    {
        [Key, Column(Order = 0)]
        public int proyecto { get; set; }

        [Key, Column(Order = 1)]
        public int area_conocimiento { get; set; }
    }
}