using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("docente_producto")]
    public class DocenteProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? docente { get; set; }

        public int? producto { get; set; }
    }
}