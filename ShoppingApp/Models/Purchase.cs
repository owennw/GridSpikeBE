namespace ShoppingApp.Models
{
    public class Purchase
    {
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
    }
}