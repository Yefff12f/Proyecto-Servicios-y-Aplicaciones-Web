using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("universidad")]
    public class Universidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(60)]
        public string? nombre { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }

        [MaxLength(45)]
        public string? ciudad { get; set; }
    }
}