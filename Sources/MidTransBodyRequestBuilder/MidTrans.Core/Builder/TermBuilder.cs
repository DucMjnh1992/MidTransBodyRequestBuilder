using MidTrans.Core.Models;
using System.Collections.Generic;

namespace MidTrans.Core.Builder
{
    public class TermBuilder : BaseBuilder<Term>, IBuilder<Term>
    {
        private IList<int> bnis;
        private IList<int> mandiris;
        private IList<int> cimbs;
        private IList<int> bcas;
        private IList<int> offlines;

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

        public TermBuilder SetBnis(IList<int> bnis)
        {
            this.bnis = bnis;

            return this;
        }
        
        public TermBuilder AddItemToBnis(int item)
        {
            this.bnis = this.AddToCollection<int>(this.bnis, item);

            return this;
        }

        public TermBuilder AddItemToBnisUnique(int item)
        {
            this.bnis = this.AddToCollectionUnique<int>(this.bnis, item, this.IntEquals);

            return this;
        }

        public TermBuilder SetMandiris(IList<int> mandiris)
        {
            this.mandiris = mandiris;

            return this;
        }

        public TermBuilder AddItemToMandiris(int item)
        {
            this.mandiris = this.AddToCollection<int>(this.mandiris, item);

            return this;
        }

        public TermBuilder AddItemToMandirisUnique(int item)
        {
            this.mandiris = this.AddToCollectionUnique<int>(this.mandiris, item, this.IntEquals);

            return this;
        }

        public TermBuilder SetCimbs(IList<int> cimbs)
        {
            this.cimbs = cimbs;

            return this;
        }

        public TermBuilder AddItemToCimbs(int item)
        {
            this.cimbs = this.AddToCollection<int>(this.cimbs, item);

            return this;
        }

        public TermBuilder AddItemToCimbsUnique(int item)
        {
            this.cimbs = this.AddToCollectionUnique<int>(this.cimbs, item, this.IntEquals);

            return this;
        }

        public TermBuilder SetBcas(IList<int> bcas)
        {
            this.bcas = bcas;

            return this;
        }

        public TermBuilder AddItemToBcas(int item)
        {
            this.bcas = this.AddToCollection<int>(this.bcas, item);

            return this;
        }

        public TermBuilder AddItemToBcasUnique(int item)
        {
            this.bcas = this.AddToCollectionUnique<int>(this.bcas, item, this.IntEquals);

            return this;
        }

        public TermBuilder SetOfflines(IList<int> offlines)
        {
            this.offlines = offlines;

            return this;
        }

        public TermBuilder AddItemToOfflines(int item)
        {
            this.offlines = this.AddToCollection<int>(this.offlines, item);

            return this;
        }

        public TermBuilder AddItemToOfflinesUnique(int item)
        {
            this.offlines = this.AddToCollectionUnique<int>(this.offlines, item, this.IntEquals);

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
