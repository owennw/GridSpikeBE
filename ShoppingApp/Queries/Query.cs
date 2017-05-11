using ShoppingApp.Models;
using System;
using System.Collections.Generic;

namespace ShoppingApp.Queries
{
    public interface IQuery<T> where T : IEntity
    {
        IEnumerable<T> Run(IEnumerable<T> collection);
    }

    public class Query<T> : IQuery<T> where T : IEntity
    {
        private readonly Func<IEnumerable<T>, IEnumerable<T>> query;

        public Query(Func<IEnumerable<T>, IEnumerable<T>> query)
        {
            this.query = query;
        }

        public IEnumerable<T> Run(IEnumerable<T> collection)
        {
            return this.query(collection);
        }
    }
}