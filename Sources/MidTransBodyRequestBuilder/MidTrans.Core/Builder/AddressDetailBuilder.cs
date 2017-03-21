using System;
using MidTrans.Core.Models;

namespace MidTrans.Core.Builder
{
    public class AddressDetailBuilder : BaseBuilder<AddressDetail>, IBuilder<AddressDetail>
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private string city;
        private string postalCode;
        private string countryCode;

        public AddressDetailBuilder()
            : base(null)
        {
        }

        public AddressDetailBuilder(AddressDetail model)
            : base(model)
        {            
        }

        public static AddressDetailBuilder CreateInstance()
        {
            return new AddressDetailBuilder();
        }

        public static AddressDetailBuilder CreateInstance(AddressDetail model)
        {
            return new AddressDetailBuilder(model);
        }

        public AddressDetailBuilder SetModel(AddressDetail model)
        {
            this.model = model;

            return this;
        }

        public AddressDetailBuilder SetLastName(string lastName)
        {
            this.lastName = lastName;

            return this;
        }

        public AddressDetailBuilder SetFirstName(string firstName)
        {
            this.firstName = firstName;

            return this;
        }        


        public AddressDetailBuilder Set(string email)
        {
            this.email = email;

            return this;
        }

        public AddressDetailBuilder SetPhone(string phone)
        {
            this.phone = phone;

            return this;
        }

        public AddressDetailBuilder SetAddress(string address)
        {
            this.address = address;

            return this;
        }

        public AddressDetailBuilder SetCity(string city)
        {
            this.city = city;

            return this;
        }

        public AddressDetailBuilder SetPostal(string postalCode)
        {
            this.postalCode = postalCode;

            return this;
        }

        public AddressDetailBuilder SetCountryCode(string countryCode)
        {
            this.countryCode = countryCode;

            return this;
        }

        public override AddressDetail Build()
        {
            this.model = this.model ?? new AddressDetail();

            this.model.FirstName = this.firstName;
            this.model.LastName = this.lastName;
            this.model.Email = this.email;
            this.model.Phone = this.phone;
            this.model.Address = this.address;
            this.model.City = this.city;
            this.model.PostalCode = this.postalCode;
            this.model.CountryCode = this.countryCode;

            return this.model;
        }
    }
}
