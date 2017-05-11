using ShoppingApp.Models;
using ShoppingApp.Queries.EntityMapper;
using ShoppingApp.Queries.Operators;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingApp.Queries
{
    public class QueryManager<T> where T : IEntity
    {
        public QueryManager(IDictionary<string, string> queryDict)
        {
            var sortedQueries = SortQueries(queryDict);

            this.Queries = sortedQueries.Select(fq => new Query<T>(collection => collection.Where(fq.Selector)));
        }

        public IEnumerable<IQuery<T>> Queries { get; private set; }

        public static IEnumerable<EntityQueryStrategy<T>> SortQueries(IDictionary<string, string> queries)
        {
            var queryMapper = EntityQueryMapperFactory.Build<T>();

            var sortedQueries = queries
                .Select(q => QueryStrategyFactory<T>.Create(q.Key, q.Value, queryMapper))
                .ToArray();

            var filterQueries = sortedQueries.OfType<EntityQueryStrategy<T>>();

            foreach (var operatorQuery in sortedQueries.OfType<OperatorQueryStrategy>())
            {
                var filterQuery = filterQueries.OfType<EntityQueryStrategy<T>>().Single(fq => $"{fq.Key}_operator" == operatorQuery.Key);
                filterQuery.AddOperator(operatorQuery.Operator);
            }

            return filterQueries;
        }
    }
}