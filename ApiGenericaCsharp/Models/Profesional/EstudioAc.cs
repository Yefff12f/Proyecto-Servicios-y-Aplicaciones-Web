using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Profesional
{
    [Table("estudio_ac")]
    public class EstudioAc
    {
        [Key, Column(Order = 0)]
        public int estudio { get; set; }

        [Key, Column(Order = 1)]
        public int area_conocimiento { get; set; }
    }
}