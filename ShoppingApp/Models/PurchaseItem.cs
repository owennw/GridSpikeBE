namespace ShoppingApp.Models
{
    public class PurchaseItem: IEntity
    {
        public virtual int Id { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }

        public decimal Price
        {
            get { return this.Product.Price * this.Quantity; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as PurchaseItem;

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Purchase == other.Purchase && this.Product == other.Product;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ Purchase.GetHashCode();
                hash = (hash * 31) ^ Product.GetHashCode();

                return hash;
            }
        }
    }
}