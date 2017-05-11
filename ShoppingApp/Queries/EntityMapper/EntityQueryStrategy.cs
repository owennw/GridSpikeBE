using ShoppingApp.Models;
using ShoppingApp.Queries.Operators;
using System;

namespace ShoppingApp.Queries.EntityMapper
{
    public class EntityQueryStrategy<T> : IQueryStrategy where T : IEntity
    {
        private Func<T, string> entityPropertySelector;

        private IOperator operation;

        private string value;

        public EntityQueryStrategy(string key, string value, IEntityQueryMapper<T> queryMapper)
        {
            this.Key = key;
            this.value = value;
            this.entityPropertySelector = queryMapper.GetSelector(key);
            this.operation = OperatorFactory.Default();
        }

        public Func<T, bool> Selector
        {
            get { return item => this.operation.Run(this.entityPropertySelector(item).ToLowerInvariant().Contains(this.value.ToLowerInvariant())); }
        }

        public string Key { get; private set; }

        public void AddOperator(IOperator op)
        {
            this.operation = op;
        }

        public bool Applies(string key)
        {
            return !OperatorFactory.IsOperator(key);
        }
    }
}