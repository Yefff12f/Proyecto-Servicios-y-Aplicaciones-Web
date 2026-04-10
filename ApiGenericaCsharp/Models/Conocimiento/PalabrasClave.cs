using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Proyecto
{
    [Table("palabras_clave")]
    public class PalabrasClave
    {
        [Key, Column(Order = 0)]
        public int proyecto { get; set; }

        [Key, Column(Order = 1)]
        [MaxLength(30)]
        public string termino_clave { get; set; } = null!;
    }
}