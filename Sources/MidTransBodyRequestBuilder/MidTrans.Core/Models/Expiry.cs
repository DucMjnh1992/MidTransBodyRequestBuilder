using Newtonsoft.Json;

namespace MidTrans.Core.Models
{
    public class Expiry
    {
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
}
