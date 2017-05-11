namespace ShoppingApp.Queries.Operators
{
    public class NoOpOperator : IOperator
    {
        public bool Run(bool result)
        {
            return result;
        }
    }
}