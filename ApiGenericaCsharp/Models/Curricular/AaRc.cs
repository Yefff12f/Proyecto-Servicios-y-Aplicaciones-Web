using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("aa_rc")]
    public class AaRc
    {
        [Key, Column(Order = 0)]
        public int actv_academicas_idcurso { get; set; }

        [Key, Column(Order = 1)]
        public int registro_calificado_codigo { get; set; }

        [MaxLength(45)]
        public string? componente { get; set; }

        [MaxLength(45)]
        public string? semestre { get; set; }
    }
}