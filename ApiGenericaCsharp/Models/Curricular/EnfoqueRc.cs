using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("enfoque_rc")]
    public class EnfoqueRc
    {
        [Key, Column(Order = 0)]
        public int enfoque { get; set; }

        [Key, Column(Order = 1)]
        public int registro_calificado { get; set; }
    }
}