using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("docente")]
    public class Docente
    {
        [Key]
        public int cedula { get; set; }

        [MaxLength(60)]
        public string? nombres { get; set; }

        [MaxLength(60)]
        public string? apellidos { get; set; }

        [MaxLength(12)]
        public string? genero { get; set; }

        [MaxLength(30)]
        public string? cargo { get; set; }

        public DateTime? fecha_nacimiento { get; set; }

        [MaxLength(70)]
        public string? correo { get; set; }

        [MaxLength(20)]
        public string? telefono { get; set; }

        [MaxLength(128)]
        public string? url_cvlac { get; set; }

        public DateTime? fecha_actualizacion { get; set; }

        [MaxLength(45)]
        public string? escalafon { get; set; }

        public string? perfil { get; set; }

        [MaxLength(45)]
        public string? cat_minciencia { get; set; }

        [MaxLength(45)]
        public string? conv_minciencia { get; set; }

        [MaxLength(45)]
        public string? nacionalidad { get; set; }

        public int? linea_investigacion_principal { get; set; }
    }
}