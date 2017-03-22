using Newtonsoft.Json;
using System.Collections.Generic;

namespace MidTrans.Core.Models
{
    public class Term
    {
        [JsonProperty("bni")]
        public IList<int> Bnis { get; set; }

        [JsonProperty("mandiri")]
        public IList<int> Mandiris { get; set; }

        [JsonProperty("cimb")]
        public IList<int> Cimbs { get; set; }

        [JsonProperty("bca")]
        public IList<int> Bcas { get; set; }

        [JsonProperty("offline")]
        public IList<int> Offlines { get; set; }
    }
}
