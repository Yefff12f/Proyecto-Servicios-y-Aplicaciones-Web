using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Caracterizacion
{
    [Table("objetivos_desarrollo_sostenible")]
    public class ObjetivoDesarrolloSostenible
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(60)]
        public string? nombre { get; set; }

        [MaxLength(256)]
        public string? descripcion { get; set; }
    }
}