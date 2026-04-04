using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("acreditacion")]
    public class Acreditacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(45)]
        public string? codigo { get; set; }

        [MaxLength(45)]
        public string? resolucion { get; set; }

        [MaxLength(45)]
        public string? tipo_situacion { get; set; }

        [MaxLength(45)]
        public string? tipo_titulacion { get; set; }

        [MaxLength(45)]
        public string? hora_accion { get; set; }

        public DateTime? fecha_ini { get; set; }
        public DateTime? fecha_fin { get; set; }

        public int? programa { get; set; }
    }
}
