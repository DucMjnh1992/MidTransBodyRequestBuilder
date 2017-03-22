using Newtonsoft.Json;

namespace MidTrans.Core.Models
{
    public class CustomerDetail
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("billing_address")]
        public AddressDetail BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public AddressDetail ShippingAddress { get; set; }
    }
}
