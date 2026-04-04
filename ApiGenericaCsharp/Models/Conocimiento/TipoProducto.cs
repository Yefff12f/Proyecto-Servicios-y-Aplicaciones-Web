using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("tipo_producto")]
    public class TipoProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? categoria { get; set; }

        [MaxLength(45)]
        public string? clase { get; set; }

        [MaxLength(45)]
        public string? nombre { get; set; }

        [MaxLength(45)]
        public string? tipologia { get; set; }
    }
}