using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("pasantia")]
    public class Pasantia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(60)]
        public string? nombre { get; set; }

        [MaxLength(45)]
        public string? pais { get; set; }

        [MaxLength(60)]
        public string? empresa { get; set; }

        [MaxLength(256)]
        public string? descripcion { get; set; }

        public int? programa { get; set; }
    }
}