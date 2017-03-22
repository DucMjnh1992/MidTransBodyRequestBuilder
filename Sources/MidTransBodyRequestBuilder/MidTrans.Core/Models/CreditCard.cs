using Newtonsoft.Json;
using System.Collections.Generic;

namespace MidTrans.Core.Models
{
    public class CreditCard
    {
        [JsonProperty("secure")]
        public bool Secure { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("installment")]
        public Installment Installment { get; set; }

        [JsonProperty("whitelist_bins")]
        public IList<string> WhitelistBins { get; set; }
    }
}
