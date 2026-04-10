using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("red")]
    public class Red
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idr { get; set; }

        [MaxLength(45)]
        public string? nombre { get; set; }

        [MaxLength(45)]
        public string? uri { get; set; }

        [MaxLength(45)]
        public string? pas { get; set; }
    }
}