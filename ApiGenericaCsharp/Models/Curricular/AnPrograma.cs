using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Curricular
{
    [Table("an_programa")]
    public class AnPrograma
    {
        [Key, Column(Order = 0)]
        public int aspecto_normativo { get; set; }

        [Key, Column(Order = 1)]
        public int programa { get; set; }
    }
}