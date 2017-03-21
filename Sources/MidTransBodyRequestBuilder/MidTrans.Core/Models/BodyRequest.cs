using System.Collections.Generic;

namespace MidTrans.Core.Models
{
    public class BodyRequest
    {
        public TransactionDetail TransactionDetail { get; set; }
        public IList<ItemDetail> ItemDetails { get; set; }
        public IList<string> EnabledPayments { get; set; }
        public CreditCard CreditCard { get; set; }
        public CustomerDetail CustomerDetail { get; set; }
        public Expiry Expiry { get; set; }
    }
}
