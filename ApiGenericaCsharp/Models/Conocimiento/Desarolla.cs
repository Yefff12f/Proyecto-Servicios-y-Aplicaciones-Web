using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("desarrolla")]
    public class Desarrolla
    {
        [Key, Column(Order = 0)]
        public int docente { get; set; }

        [Key, Column(Order = 1)]
        public int proyecto { get; set; }

        [MaxLength(45)]
        public string? rol { get; set; }

        [MaxLength(256)]
        public string? descripcion { get; set; }
    }
}