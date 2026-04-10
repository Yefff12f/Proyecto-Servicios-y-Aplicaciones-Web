using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("programa_ac")]
    public class ProgramaAc
    {
        [Key, Column(Order = 0)]
        public int programa { get; set; }

        [Key, Column(Order = 1)]
        public int area_conocimiento { get; set; }
    }
}