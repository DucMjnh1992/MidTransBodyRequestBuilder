using Newtonsoft.Json;

namespace MidTrans.Core.Models
{
    public class ItemDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
