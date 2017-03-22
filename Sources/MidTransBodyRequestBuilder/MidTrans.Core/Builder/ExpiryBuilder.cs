using MidTrans.Core.Models;

namespace MidTrans.Core.Builder
{
    public class ExpiryBuilder : BaseBuilder<Expiry>, IBuilder<Expiry>
    {
        private string startTime;
        private string unit;
        private int duration;

        public ExpiryBuilder()
            : base(null)
        {
        }
        
        public ExpiryBuilder(Expiry model)
            : base(model)
        {            
        }

        public static ExpiryBuilder CreateInstance()
        {
            return new ExpiryBuilder();
        }

        public static ExpiryBuilder CreateInstance(Expiry model)
        {
            return new ExpiryBuilder(model);
        }

        public ExpiryBuilder SetModel(Expiry model)
        {
            this.model = model;

            return this;
        }

        public ExpiryBuilder SetStartTime(string startTime)
        {
            this.startTime = startTime;

            return this;
        }

        public ExpiryBuilder SetUnit(string unit)
        {
            this.unit = unit;

            return this;
        }

        public ExpiryBuilder SetDuration(int duration)
        {
            this.duration = duration;

            return this;
        }

        public override Expiry Build()
        {
            this.model = this.model ?? new Expiry();

            this.model.StartTime = this.startTime;
            this.model.Unit = this.unit;
            this.model.Duration = this.duration;

            return this.model;
        }
    }
}
