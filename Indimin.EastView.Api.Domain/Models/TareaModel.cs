using Newtonsoft.Json;

namespace Indimin.EastView.Domain.Models
{
    public class TareaModel : TareaRequest
    {
        [JsonProperty("tareaId")]
        public int TareaId { get; set; }
    }
}
