using MidTrans.Core.Models;
using System.Collections.Generic;

namespace MidTrans.Core.Builder
{
    public class BodyRequestBuilder : BaseBuilder<BodyRequest>, IBuilder<BodyRequest>
    {
        private TransactionDetail transactionDetail;
        private IList<ItemDetail> itemDetails;
        private IList<string> enabledPayments;
        private CreditCard creditCard;
        private CustomerDetail customerDetail;
        private Expiry expiry;

        public BodyRequestBuilder()
            : base(null)
        {
        }
        
        public BodyRequestBuilder(BodyRequest model)
            : base(model)
        {            
        }

        public static BodyRequestBuilder CreateInstance()
        {
            return new BodyRequestBuilder();
        }

        public static BodyRequestBuilder CreateInstance(BodyRequest model)
        {
            return new BodyRequestBuilder(model);
        }

        public BodyRequestBuilder SetModel(BodyRequest model)
        {
            this.model = model;

            return this;
        }

        public BodyRequestBuilder SetTransactionDetail(TransactionDetail transactionDetail)
        {
            this.transactionDetail = transactionDetail;

            return this;
        }

        public BodyRequestBuilder SetItemDetails(IList<ItemDetail> itemDetails)
        {
            this.itemDetails = itemDetails;

            return this;
        }

        public BodyRequestBuilder AddItemToItemDetails(ItemDetail item)
        {
            this.AddToCollection<ItemDetail>(this.itemDetails, item);

            return this;
        }

        public BodyRequestBuilder AddItemToItemDetailsUnique(ItemDetail item)
        {
            this.AddToCollectionUnique<ItemDetail>(this.itemDetails, item, this.ItemDetailEquals);

            return this;
        }

        private bool ItemDetailEquals(ItemDetail item1, ItemDetail item2)
        {
            if (item1 == null
                || item2 == null)
            {
                return false;
            }

            return item1.Id == item2.Id;
        }

        public BodyRequestBuilder SetEnabledPayments(IList<string> enabledPayments)
        {
            this.enabledPayments = enabledPayments;

            return this;
        }

        public BodyRequestBuilder AddItemToEnabledPayments(string item)
        {
            this.AddToCollection<string>(this.enabledPayments, item);

            return this;
        }

        public BodyRequestBuilder AddItemToEnabledPaymentsUnique(string item)
        {
            this.AddToCollectionUnique<string>(this.enabledPayments, item, this.StringEquals);

            return this;
        }

        public BodyRequestBuilder SetCreditCard(CreditCard creditCard)
        {
            this.creditCard = creditCard;

            return this;
        }

        public BodyRequestBuilder SetCustomerDetail(CustomerDetail customerDetail)
        {
            this.customerDetail = customerDetail;

            return this;
        }

        public BodyRequestBuilder SetExpiry(Expiry expiry)
        {
            this.expiry = expiry;

            return this;
        }

        public override BodyRequest Build()
        {
            this.model = this.model ?? new BodyRequest();

            this.model.TransactionDetail = this.transactionDetail;
            this.model.ItemDetails = this.itemDetails;
            this.model.EnabledPayments = this.enabledPayments;
            this.model.CreditCard = this.creditCard;
            this.model.CustomerDetail = this.customerDetail;
            this.model.Expiry = this.expiry;

            return this.model;
        }
    }
}
