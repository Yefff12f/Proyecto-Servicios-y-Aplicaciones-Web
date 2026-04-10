using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("intereses_futuros")]
    public class InteresesFuturos
    {
        [Key, Column(Order = 0)]
        public int docente { get; set; }

        [Key, Column(Order = 1)]
        [MaxLength(30)]
        public string termino_clave { get; set; } = null!;
    }
}