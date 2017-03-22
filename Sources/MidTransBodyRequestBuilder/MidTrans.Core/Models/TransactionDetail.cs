using Newtonsoft.Json;

namespace MidTrans.Core.Models
{
    public class TransactionDetail
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("gross_amount")]
        public int GrossAmount { get; set; }
    }
}
