using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Caracterizacion
{
    [Table("area_conocimiento")]
    public class AreaConocimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(60)]
        public string? gran_area { get; set; }

        [MaxLength(60)]
        public string? area { get; set; }

        [MaxLength(60)]
        public string? disciplina { get; set; }
    }
}