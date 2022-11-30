using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Indimin.EastView.Domain.Models
{
    public class CuidadanoRequest
    {
        [JsonProperty("nombre")]
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        [Required(ErrorMessage = "El apellido es un campo requerido")]
        public string Apellido { get; set; }
    }
}
