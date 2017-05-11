using ShoppingApp.Models;
using ShoppingApp.Queries.EntityMapper;
using ShoppingApp.Queries.Operators;

namespace ShoppingApp.Queries
{
    public interface IQueryStrategy
    {
        string Key { get; }
        bool Applies(string key);
    }

    public static class QueryStrategyFactory<T> where T : IEntity
    {
        public static IQueryStrategy Create(string key, string value, IEntityQueryMapper<T> queryMapper)
        {
            return OperatorFactory.IsOperator(key) ?
                new OperatorQueryStrategy(key, value) as IQueryStrategy : new EntityQueryStrategy<T>(key, value, queryMapper);
        }
    }
}