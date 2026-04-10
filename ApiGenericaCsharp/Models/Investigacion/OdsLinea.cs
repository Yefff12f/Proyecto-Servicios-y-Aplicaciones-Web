using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Investigacion
{
    [Table("ods_linea")]
    public class OdsLinea
    {
        [Key, Column(Order = 0)]
        public int linea_investigacion { get; set; }

        [Key, Column(Order = 1)]
        public int ods { get; set; }
    }
}