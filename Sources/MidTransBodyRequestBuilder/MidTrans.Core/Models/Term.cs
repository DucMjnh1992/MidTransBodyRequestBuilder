using System.Collections.Generic;

namespace MidTrans.Core.Models
{
    public class Term
    {
        public IList<string> Bni { get; set; }
        public IList<string> Mandiri { get; set; }
        public IList<string> Cimb { get; set; }
        public IList<string> Bca { get; set; }
        public IList<string> Offline { get; set; }
    }
}
