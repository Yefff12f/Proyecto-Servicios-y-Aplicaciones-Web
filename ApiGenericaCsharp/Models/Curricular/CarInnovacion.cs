using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("car_innovacion")]
    public class CarInnovacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? nombre { get; set; }

        public string? longtext { get; set; }
    }
}