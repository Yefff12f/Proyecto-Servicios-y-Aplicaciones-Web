using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("estudios_realizados")]
    public class EstudiosRealizados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? titulo { get; set; }

        [MaxLength(50)]
        public string? universidad { get; set; }

        public DateTime? fecha { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }

        [MaxLength(45)]
        public string? ciudad { get; set; }

        public int? docente { get; set; }

        public bool? ins_acreditada { get; set; }

        [MaxLength(45)]
        public string? metodologia { get; set; }

        public string? perfil_egresado { get; set; }

        [MaxLength(45)]
        public string? pais { get; set; }
    }
}