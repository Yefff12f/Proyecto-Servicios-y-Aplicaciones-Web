using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("aliado")]
    public class Aliado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(60)]
        public string? nombre { get; set; }

        [MaxLength(60)]
        public string? apellidos { get; set; }

        [MaxLength(60)]
        public string? empresa { get; set; }

        [MaxLength(256)]
        public string? descripcion { get; set; }

        [MaxLength(70)]
        public string? correo { get; set; }

        [MaxLength(60)]
        public string? contacto { get; set; }

        [MaxLength(45)]
        public string? ciudad { get; set; }
    }
}