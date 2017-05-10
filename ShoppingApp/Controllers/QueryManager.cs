using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingApp.Controllers
{
    public interface IQuery<T> where T : IEntity
    {
        IEnumerable<T> Run(IEnumerable<T> collection);
    }

    public interface IOperator
    {
        bool Run(bool result);
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

    public class Not : IOperator
    {
        public bool Run(bool result)
        {
            return !result;
        }
    }

    public class NoOp : IOperator
    {
        public bool Run(bool result)
        {
            return result;
        }
    }

    public class QueryManager<T> where T : IEntity
    {
        private readonly IDictionary<string, string> queryDict;

        private readonly IList<IQuery<T>> queries = new List<IQuery<T>>();

        public QueryManager(IDictionary<string, string> queryDict)
        {
            this.queryDict = queryDict;
        }

        public IEnumerable<IQuery<T>> Queries
        {
            get { return this.queries; }
        }

        public void Add(string key, Func<T, string> selector)
        {
            string value = null;
            if (this.queryDict.TryGetValue(key, out value))
            {
                string valueOperator = null;
                IOperator operation = new NoOp();
                if (this.queryDict.TryGetValue($"{key}_operator", out valueOperator))
                {
                    switch (valueOperator.ToUpperInvariant())
                    {
                        case "NOT":
                            operation = new Not();

                            break;
                        default:
                            break;
                    }
                }

                var query = new Query<T>(collection =>
                    collection.Where(item => operation.Run(selector(item).ToLowerInvariant().Contains(value.ToLowerInvariant()))));

                this.queries.Add(query);
            }
        }
    }
}