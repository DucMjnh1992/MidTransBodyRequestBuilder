using System;

namespace MidTrans.Core.Builder
{
    public abstract class BaseBuilder<T> : IBuilder<T>
    {
        protected T model;

        public BaseBuilder()
            : this(default(T))
        {
        }

        public BaseBuilder(T model)
        {
            this.model = model;
        }

        public abstract T Build();
    }
}
