namespace ShoppingApp.Queries.Operators
{
    public static class OperatorFactory
    {
        public static IOperator Build(string valueOperator)
        {
            switch (valueOperator.ToUpperInvariant())
            {
                case "NOT":
                    return new NotOperator();
                default:
                    return new NoOpOperator();
            }
        }

        public static IOperator Default()
        {
            return new NoOpOperator();
        }

        public static bool IsOperator(string key)
        {
            return key.EndsWith("_operator");
        }
    }
}