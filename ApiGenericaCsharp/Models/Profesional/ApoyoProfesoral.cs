using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("apoyo_profesoral")]
    public class ApoyoProfesoral
    {
        [Key, Column(Order = 0)]
        public int estudios { get; set; }

        public bool? con_apoyo { get; set; }

        [MaxLength(45)]
        public string? institucion { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }
    }
}