namespace MidTrans.Core.Models
{
    public class CustomerDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressDetail BillingAddress { get; set; }
        public AddressDetail ShippingAddress { get; set; }
    }
}
