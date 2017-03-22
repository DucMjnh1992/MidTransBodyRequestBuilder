using Newtonsoft.Json;
using System.Collections.Generic;

namespace MidTrans.Core.Models
{
    public class BodyRequest
    {
        [JsonProperty("transaction_details")]
        public TransactionDetail TransactionDetail { get; set; }

        [JsonProperty("item_details")]
        public IList<ItemDetail> ItemDetails { get; set; }

        [JsonProperty("enabled_payments")]
        public IList<string> EnabledPayments { get; set; }

        [JsonProperty("credit_card")]
        public CreditCard CreditCard { get; set; }

        [JsonProperty("customer_details")]
        public CustomerDetail CustomerDetail { get; set; }

        [JsonProperty("expiry")]
        public Expiry Expiry { get; set; }
    }
}
