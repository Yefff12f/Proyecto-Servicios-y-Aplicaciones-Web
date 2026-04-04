using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("aa_proyecto")]
    public class AaProyecto
    {
        [Key, Column(Order = 0)]
        public int proyecto { get; set; }

        [Key, Column(Order = 1)]
        public int area_aplicacion { get; set; }
    }
}