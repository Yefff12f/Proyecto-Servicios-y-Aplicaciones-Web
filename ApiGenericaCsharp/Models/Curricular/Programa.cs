using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("programa")]
    public class Programa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(60)]
        public string? nombre { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }

        public DateTime? fecha_creacion { get; set; }

        public int? num_creditos { get; set; }

        public int? cant_semestres { get; set; }

        public DateTime? fecha_actualizacion { get; set; }

        [MaxLength(45)]
        public string? pais { get; set; }

        [MaxLength(45)]
        public string? ciudad { get; set; }

        public int? facultad { get; set; }
    }
}