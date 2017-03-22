using Newtonsoft.Json;

namespace MidTrans.Core.Models
{
    public class Installment
    {
        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("terms")]
        public Term Term { get; set; }
    }
}
