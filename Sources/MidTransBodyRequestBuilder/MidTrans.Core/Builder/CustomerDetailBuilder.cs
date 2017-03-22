using MidTrans.Core.Models;
using System.Collections.Generic;

namespace MidTrans.Core.Builder
{
    public class CustomerDetailBuilder : BaseBuilder<CustomerDetail>, IBuilder<CustomerDetail>
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private AddressDetail billingAddress;
        private AddressDetail shippingAddress;

        public CustomerDetailBuilder()
            : base(null)
        {
        }
        
        public CustomerDetailBuilder(CustomerDetail model)
            : base(model)
        {            
        }

        public static CustomerDetailBuilder CreateInstance()
        {
            return new CustomerDetailBuilder();
        }

        public static CustomerDetailBuilder CreateInstance(CustomerDetail model)
        {
            return new CustomerDetailBuilder(model);
        }

        public CustomerDetailBuilder SetModel(CustomerDetail model)
        {
            this.model = model;

            return this;
        }

        public CustomerDetailBuilder SetFirstName(string firstName)
        {
            this.firstName = firstName;

            return this;
        }

        public CustomerDetailBuilder SetLastName(string lastName)
        {
            this.lastName = lastName;

            return this;
        }

        public CustomerDetailBuilder SetEmail(string email)
        {
            this.email = email;

            return this;
        }        


        public CustomerDetailBuilder SetPhone(string phone)
        {
            this.phone = phone;

            return this;
        }

        public CustomerDetailBuilder SetBillingAddress(AddressDetail billingAddress)
        {
            this.billingAddress = billingAddress;

            return this;
        }

        public CustomerDetailBuilder SetShippingAddress(AddressDetail shippingAddress)
        {
            this.shippingAddress = shippingAddress;

            return this;
        }

        public override CustomerDetail Build()
        {
            this.model = this.model ?? new CustomerDetail();

            this.model.FirstName = this.firstName;
            this.model.LastName = this.lastName;
            this.model.Email = this.email;
            this.model.Phone = this.phone;
            this.model.BillingAddress = this.billingAddress;
            this.model.ShippingAddress = this.shippingAddress;

            return this.model;
        }
    }
}
