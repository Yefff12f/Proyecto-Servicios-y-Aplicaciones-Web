using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("programa_ci")]
    public class ProgramaCi
    {
        [Key, Column(Order = 0)]
        public int programa { get; set; }

        [Key, Column(Order = 1)]
        public int car_innovacion { get; set; }
    }
}