using ShoppingApp.Models;

namespace ShoppingApp.DTOs
{
    public class PurchaseItemDTO : EntityDTO
    {
        public PurchaseItemDTO(PurchaseItem purchaseItem) : base(purchaseItem)
        {
            this.Product = purchaseItem.Product;
            this.Purchase = purchaseItem.Purchase;
            this.Quantity = purchaseItem.Quantity;
        }

        public Purchase Purchase { get; private set; }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price
        {
            get { return this.Product.Price * this.Quantity; }
        }
    }
}