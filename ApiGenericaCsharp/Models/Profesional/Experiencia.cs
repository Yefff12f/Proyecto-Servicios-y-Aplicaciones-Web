using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("experiecia")]
    public class Experiecia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? nombre_cargo { get; set; }

        [MaxLength(45)]
        public string? institucion { get; set; }

        [MaxLength(45)]
        public string? nombre { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }

        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }

        public int? docente { get; set; }
    }
}