using Indimin.EastView.Domain.Entities;
using Newtonsoft.Json;

namespace Indimin.EastView.Domain.Models
{
    public class CuidadanoModel : CuidadanoRequest
    {
        [JsonProperty("cuidadanoId")]
        public int CuidadanoId { get; set; }

        [JsonProperty("tareas")]
        public IList<TareaModel> Tareas { get; set; }
    }
}
