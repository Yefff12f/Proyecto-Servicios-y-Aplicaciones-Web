using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.conocimiento
{
    [Table("termino_clave")]
    public class TerminoClave
    {
        [Key, Column(Order = 0)]
        [MaxLength(30)]
        public string termino { get; set; } = null!;

        [MaxLength(30)]
        public string? termino_ingles { get; set; }
    }
}