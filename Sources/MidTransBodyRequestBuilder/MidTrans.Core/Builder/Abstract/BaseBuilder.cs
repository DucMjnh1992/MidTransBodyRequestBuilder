using System;
using System.Collections.Generic;
using System.Linq;
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

        protected IList<V> AddToCollection<V>(IList<V> collection, V item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            collection = collection ?? new List<V>();

            collection.Add(item);

            return collection;
        }

        protected IList<V> AddToCollectionUnique<V>(IList<V> collection, V item, Func<V, V, bool> isMatchExpression)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if(isMatchExpression == null)
            {
                throw new ArgumentNullException(nameof(isMatchExpression));
            }

            collection = collection ?? new List<V>();

            if (!collection.Any(m => isMatchExpression(m, item)))
            {
                collection.Add(item);

                return collection;
            }

            IEnumerable<V> duplicateItems = collection.Where(m => isMatchExpression(m, item));
            const int DEFAULT_POSITION_OF_FIRST_ITEM = -1;
            int positionOfFirstItem = DEFAULT_POSITION_OF_FIRST_ITEM;

            for (int i = 0; i < collection.Count; i++)
            {
                if (!isMatchExpression(collection[i], item))
                {
                    continue;
                }

                positionOfFirstItem = i;
            }

            foreach (V tempItem in duplicateItems)
            {
                collection.Remove(tempItem);
            }

            collection.Insert(positionOfFirstItem, item);

            return collection;
        }

        protected void RemoveAllWhenMatchExpression<V>(IList<V> collection, V item, Func<V, V, bool> isMatchExpression)
        {
            if (collection == null
                || item == null)
            {
                return;
            }

            if (isMatchExpression == null)
            {
                throw new ArgumentNullException(nameof(isMatchExpression));
            }

            for (int i = collection.Count - 1; i >= 0; )
            {
                V tempItem = collection[i];

                if (!isMatchExpression(tempItem, item))
                {
                    continue;
                }

                collection.Remove(tempItem);
            }
        }

        protected void RemoveAllWhenMatchExpression<V>(IList<V> collection, IList<V> items, Func<V, V, bool> isMatchExpression)
        {
            if (collection == null
                || items == null)
            {
                return;
            }

            if (isMatchExpression == null)
            {
                throw new ArgumentNullException(nameof(isMatchExpression));
            }

            foreach (V item in collection)
            {
                this.Remove(collection, item, isMatchExpression);
            }
        }
    }
}
