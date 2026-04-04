using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("aspecto_normativo")]
    public class AspectoNormativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? aspecto_norm_ac { get; set; }

        [MaxLength(256)]
        public string? descripcion { get; set; }
    }
}