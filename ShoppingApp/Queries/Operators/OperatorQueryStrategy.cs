namespace ShoppingApp.Queries.Operators
{
    public class OperatorQueryStrategy : IQueryStrategy
    {
        public OperatorQueryStrategy(string key, string value)
        {
            this.Key = key;
            this.Operator = OperatorFactory.Build(value);
        }

        public IOperator Operator { get; private set; }

        public string Key { get; private set; }

        public bool Applies(string key)
        {
            return OperatorFactory.IsOperator(key);
        }
    }
}