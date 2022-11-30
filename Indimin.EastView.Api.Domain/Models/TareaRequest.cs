using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Indimin.EastView.Domain.Models
{
    public class TareaRequest
    {
        [JsonProperty("descripcion")]
        [Required(ErrorMessage = "La descripcion es un campo requerido")]
        public string Descripcion { get; set; }

        [JsonProperty("fecha")]
        [Required(ErrorMessage = "La fecha es un campo requerido")]
        public DateTime Fecha { get; set; }

        [JsonProperty("cuidadanoId")]
        public int CuidadanoId { get; set; }
    }
}
