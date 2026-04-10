using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("reconocimiento")]
    public class Reconocimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }

        public DateTime? fecha { get; set; }

        [MaxLength(45)]
        public string? institucion { get; set; }

        [MaxLength(45)]
        public string? nombre { get; set; }

        [MaxLength(45)]
        public string? ambito { get; set; }

        public int? docente { get; set; }
    }
}