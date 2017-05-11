namespace ShoppingApp.Queries.Operators
{
    public class NotOperator : IOperator
    {
        public bool Run(bool result)
        {
            return !result;
        }
    }
}