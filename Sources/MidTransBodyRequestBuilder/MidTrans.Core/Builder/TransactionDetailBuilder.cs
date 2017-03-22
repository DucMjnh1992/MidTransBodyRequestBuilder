using MidTrans.Core.Models;

namespace MidTrans.Core.Builder
{
    public class TransactionDetailBuilder : BaseBuilder<TransactionDetail>, IBuilder<TransactionDetail>
    {
        private string orderId;
        private int grossAmount;

        public TransactionDetailBuilder()
            : base(null)
        {
        }
        
        public TransactionDetailBuilder(TransactionDetail model)
            : base(model)
        {            
        }

        public static TransactionDetailBuilder CreateInstance()
        {
            return new TransactionDetailBuilder();
        }

        public static TransactionDetailBuilder CreateInstance(TransactionDetail model)
        {
            return new TransactionDetailBuilder(model);
        }

        public TransactionDetailBuilder SetModel(TransactionDetail model)
        {
            this.model = model;

            return this;
        }

        public TransactionDetailBuilder SetOrderId(string orderId)
        {
            this.orderId = orderId;

            return this;
        }

        public TransactionDetailBuilder SetGrossAmount(int grossAmount)
        {
            this.grossAmount = grossAmount;

            return this;
        }

        public override TransactionDetail Build()
        {
            this.model = this.model ?? new TransactionDetail();

            this.model.OrderId = this.orderId;
            this.model.GrossAmount = this.grossAmount;

            return this.model;
        }
    }
}
