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
        
        public TermBuilder AddItemToBnis(string item)
        {
            this.AddToCollection<string>(this.bnis, item);

            return this;
        }

        public TermBuilder AddItemToBnisUnique(string item)
        {
            this.AddToCollectionUnique<string>(this.bnis, item, this.StringEquals);

            return this;
        }

        public TermBuilder SetMandiris(IList<string> mandiris)
        {
            this.mandiris = mandiris;

            return this;
        }

        public TermBuilder AddItemToMandiris(string item)
        {
            this.AddToCollection<string>(this.mandiris, item);

            return this;
        }

        public TermBuilder AddItemToMandirisUnique(string item)
        {
            this.AddToCollectionUnique<string>(this.mandiris, item, this.StringEquals);

            return this;
        }

        public TermBuilder SetCimbs(IList<string> cimbs)
        {
            this.cimbs = cimbs;

            return this;
        }

        public TermBuilder AddItemToCimbs(string item)
        {
            this.AddToCollection<string>(this.cimbs, item);

            return this;
        }

        public TermBuilder AddItemToCimbsUnique(string item)
        {
            this.AddToCollectionUnique<string>(this.cimbs, item, this.StringEquals);

            return this;
        }

        public TermBuilder SetBcas(IList<string> bcas)
        {
            this.bcas = bcas;

            return this;
        }

        public TermBuilder AddItemToBcas(string item)
        {
            this.AddToCollection<string>(this.bcas, item);

            return this;
        }

        public TermBuilder AddItemToBcasUnique(string item)
        {
            this.AddToCollectionUnique<string>(this.bcas, item, this.StringEquals);

            return this;
        }

        public TermBuilder SetOfflines(IList<string> offlines)
        {
            this.offlines = offlines;

            return this;
        }

        public TermBuilder AddItemToOfflines(string item)
        {
            this.AddToCollection<string>(this.offlines, item);

            return this;
        }

        public TermBuilder AddItemToOfflinesUnique(string item)
        {
            this.AddToCollectionUnique<string>(this.offlines, item, this.StringEquals);

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
