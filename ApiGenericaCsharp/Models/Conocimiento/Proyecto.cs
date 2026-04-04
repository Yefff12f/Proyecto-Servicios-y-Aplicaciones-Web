using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("proyecto")]
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(150)]
        public string? nombre { get; set; }

        public DateTime? fecha_inicio { get; set; }

        public DateTime? fecha_fin { get; set; }
    }
}