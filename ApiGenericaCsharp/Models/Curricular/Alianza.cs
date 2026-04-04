using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("alianza")]
    public class Alianza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? departamento { get; set; }
        public int? aliado { get; set; }
        public int? docente { get; set; }

        public DateTime? fecha_ini { get; set; }
        public DateTime? fecha_fin { get; set; }
    }
}