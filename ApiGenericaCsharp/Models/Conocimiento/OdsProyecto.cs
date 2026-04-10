using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Proyecto
{
    [Table("ods_proyecto")]
    public class OdsProyecto
    {
        [Key, Column(Order = 0)]
        public int proyecto { get; set; }

        [Key, Column(Order = 1)]
        public int ods { get; set; }
    }
}