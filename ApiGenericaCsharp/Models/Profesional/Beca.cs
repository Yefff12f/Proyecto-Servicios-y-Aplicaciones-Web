using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("beca")]
    public class Beca
    {
        [Key, Column(Order = 0)]
        public int estudios { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }

        [MaxLength(80)]
        public string? institucion { get; set; }

        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }

        [MaxLength(45)]
        public string? pais { get; set; }
    }
}