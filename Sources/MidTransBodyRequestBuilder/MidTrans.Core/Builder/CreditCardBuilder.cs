using MidTrans.Core.Models;
using System.Collections.Generic;

namespace MidTrans.Core.Builder
{
    public class CreditCardBuilder : BaseBuilder<CreditCard>, IBuilder<CreditCard>
    {
        private bool secure;
        private string channel;
        private string bank;
        private Installment installment;
        private IList<string> whitelistBins;

        public CreditCardBuilder()
            : base(null)
        {
        }
        
        public CreditCardBuilder(CreditCard model)
            : base(model)
        {            
        }

        public static CreditCardBuilder CreateInstance()
        {
            return new CreditCardBuilder();
        }

        public static CreditCardBuilder CreateInstance(CreditCard model)
        {
            return new CreditCardBuilder(model);
        }

        public CreditCardBuilder SetModel(CreditCard model)
        {
            this.model = model;

            return this;
        }

        public CreditCardBuilder SetSecure(bool secure)
        {
            this.secure = secure;

            return this;
        }

        public CreditCardBuilder SetChannel(string channel)
        {
            this.channel = channel;

            return this;
        }

        public CreditCardBuilder SetBank(string bank)
        {
            this.bank = bank;

            return this;
        }        


        public CreditCardBuilder SetInstallment(Installment installment)
        {
            this.installment = installment;

            return this;
        }

        public CreditCardBuilder SetWhitelistBins(IList<string> whitelistBins)
        {
            this.whitelistBins = whitelistBins;

            return this;
        }

        public CreditCardBuilder AddItemToWhitelistBins(string item)
        {
            this.AddToCollection<string>(this.whitelistBins, item);

            return this;
        }

        public CreditCardBuilder AddItemToWhitelistBinsUnique(string item)
        {
            this.AddToCollectionUnique<string>(this.whitelistBins, item, this.StringEquals);

            return this;
        }

        public override CreditCard Build()
        {
            this.model = this.model ?? new CreditCard();

            this.model.Secure = this.secure;
            this.model.Channel = this.channel;
            this.model.Bank = this.bank;
            this.model.Installment = this.installment;
            this.model.WhitelistBins = this.whitelistBins;

            return this.model;
        }
    }
}
