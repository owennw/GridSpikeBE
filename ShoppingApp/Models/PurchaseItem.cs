namespace ShoppingApp.Models
{
    public class PurchaseItem
    {
        public virtual Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }

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