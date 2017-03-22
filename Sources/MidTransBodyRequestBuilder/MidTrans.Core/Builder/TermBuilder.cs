using MidTrans.Core.Models;
using System.Collections.Generic;

namespace MidTrans.Core.Builder
{
    public class TermBuilder : BaseBuilder<Term>, IBuilder<Term>
    {
        private IList<string> bnis;
        private IList<string> mandiris;
        private IList<string> cimbs;
        private IList<string> bcas;
        private IList<string> offlines;

        public TermBuilder()
            : base(null)
        {
        }

        public TermBuilder(Term model)
            : base(model)
        {            
        }

        public static TermBuilder CreateInstance()
        {
            return new TermBuilder();
        }

        public static TermBuilder CreateInstance(Term model)
        {
            return new TermBuilder(model);
        }

        public TermBuilder SetModel(Term model)
        {
            this.model = model;

            return this;
        }

        public TermBuilder SetBnis(IList<string> bnis)
        {
            this.bnis = bnis;

            return this;
        }

        public TermBuilder SetMandiris(IList<string> mandiris)
        {
            this.mandiris = mandiris;

            return this;
        }        
        
        public TermBuilder SetCimbs(IList<string> cimbs)
        {
            this.cimbs = cimbs;

            return this;
        }

        public TermBuilder SetBcas(IList<string> bcas)
        {
            this.bcas = bcas;

            return this;
        }

        public TermBuilder SetOfflines(IList<string> offlines)
        {
            this.offlines = offlines;

            return this;
        }

        public override Term Build()
        {
            this.model = this.model ?? new Term();

            this.model.Bnis = this.bnis;
            this.model.Mandiris = this.bnis;
            this.model.Cimbs = this.cimbs;
            this.model.Bcas = this.bcas;
            this.model.Offlines = this.offlines;

            return this.model;
        }
    }
}
