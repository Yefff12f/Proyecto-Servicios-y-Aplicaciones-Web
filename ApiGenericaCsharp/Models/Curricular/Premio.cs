using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("premio")]
    public class Premio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(60)]
        public string? nombre { get; set; }

        [MaxLength(256)]
        public string? descripcion { get; set; }

        [MaxLength(45)]
        public string? entidad_otorgante { get; set; }

        public double? valor { get; set; }

        [MaxLength(45)]
        public string? pais { get; set; }

        public DateTime? fecha { get; set; }

        public int? programa { get; set; }
    }
}