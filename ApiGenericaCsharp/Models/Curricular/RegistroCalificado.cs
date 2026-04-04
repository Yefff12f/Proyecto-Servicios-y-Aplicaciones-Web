using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("registro_calificado")]
    public class RegistroCalificado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? cant_preg { get; set; }

        [MaxLength(45)]
        public string? calif_preg { get; set; }

        [MaxLength(45)]
        public string? h_actv_academica { get; set; }

        public int? programa { get; set; }

        public DateTime? fecha_ini { get; set; }
        public DateTime? fecha_fin { get; set; }

        [MaxLength(45)]
        public string? duracion_anios { get; set; }

        [MaxLength(45)]
        public string? docente_semestres { get; set; }

        [MaxLength(45)]
        public string? metodologia { get; set; }

        [MaxLength(45)]
        public string? tipo_titulacion { get; set; }
    }
}