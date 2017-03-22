using System.Collections.Generic;

namespace MidTrans.Core.Models
{
    public class Term
    {
        public IList<string> Bnis { get; set; }
        public IList<string> Mandiris { get; set; }
        public IList<string> Cimbs { get; set; }
        public IList<string> Bcas { get; set; }
        public IList<string> Offlines { get; set; }
    }
}
