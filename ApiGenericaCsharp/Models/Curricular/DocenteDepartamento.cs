using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("docente_departamento")]
    public class DocenteDepartamento
    {
        [Key, Column(Order = 0)]
        public int docente { get; set; }

        [Key, Column(Order = 1)]
        public int departamento { get; set; }

        [MaxLength(15)]
        public string? dedicacion { get; set; }

        [MaxLength(45)]
        public string? modalidad { get; set; }

        public DateTime? fecha_ingreso { get; set; }
        public DateTime? fecha_salida { get; set; }
    }
}