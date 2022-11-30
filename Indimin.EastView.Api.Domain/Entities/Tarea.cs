using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indimin.EastView.Domain.Entities
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TareaId { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public int CuidadanoId { get; set; }

        [ForeignKey("CuidadanoId")]
        public virtual Cuidadano Cuidadano { get; set; }
    }
}
