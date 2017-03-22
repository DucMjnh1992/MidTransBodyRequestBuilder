using MidTrans.Core.Models;

namespace MidTrans.Core.Builder
{
    public class InstallmentBuilder : BaseBuilder<Installment>, IBuilder<Installment>
    {
        private bool required;
        private Term term;

        public InstallmentBuilder()
            : base(null)
        {
        }

        public InstallmentBuilder(Installment model)
            : base(model)
        {            
        }

        public static InstallmentBuilder CreateInstance()
        {
            return new InstallmentBuilder();
        }

        public static InstallmentBuilder CreateInstance(Installment model)
        {
            return new InstallmentBuilder(model);
        }

        public InstallmentBuilder SetModel(Installment model)
        {
            this.model = model;

            return this;
        }

        public InstallmentBuilder SetLastName(bool required)
        {
            this.required = required;

            return this;
        }

        public InstallmentBuilder SetFirstName(Term term)
        {
            this.term = term;

            return this;
        }        
        
        public override Installment Build()
        {
            this.model = this.model ?? new Installment();

            this.model.Required = this.required;
            this.model.Term = this.term;

            return this.model;
        }
    }
}
