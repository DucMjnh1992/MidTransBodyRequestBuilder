using System.Collections.Generic;

namespace MidTrans.Core.Models
{
    public class CreditCard
    {
        public bool Secure { get; set; }
        public string Channel { get; set; }
        public string Bank { get; set; }
        public Installment Installment { get; set; }
        public IList<string> WhitelistBins { get; set; }
    }
}
