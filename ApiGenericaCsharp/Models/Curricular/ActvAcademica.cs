using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("actv_academica")]
    public class ActvAcademica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? num_creditos { get; set; }

        [MaxLength(45)]
        public string? tipo { get; set; }

        [MaxLength(45)]
        public string? area_formacion { get; set; }
         
        [MaxLength(45)]
        public string? idioma { get; set; }

        public int? h_acomp { get; set; }
        public int? h_indep{ get; set; }

        [MaxLength(45)]
        public string? diploma { get; set; }

        [MaxLength(45)]
        public string? entidad_Espejo { get; set; }

        [MaxLength(45)]
        public string? pais_apoyo { get; set; }

        public int? dinero { get; set; }
    }
}