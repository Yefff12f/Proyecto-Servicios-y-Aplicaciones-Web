using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("evaluacion_docente")]
    public class EvaluacionDocente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public float? calificacion { get; set; }

        [MaxLength(45)]
        public string? semestre { get; set; }

        public int? docente { get; set; }
    }
}