using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("red_docente")]
    public class RedDocente
    {
        [Key, Column(Order = 0)]
        public int red { get; set; }

        [Key, Column(Order = 1)]
        public int docente { get; set; }

        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }

        public string? act_destacadas { get; set; }
    }
}