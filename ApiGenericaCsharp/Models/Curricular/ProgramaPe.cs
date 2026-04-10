using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("programa_pe")]
    public class ProgramaPe
    {
        [Key, Column(Order = 0)]
        public int programa { get; set; }

        [Key, Column(Order = 1)]
        public int practica_estrategia { get; set; }
    }
}