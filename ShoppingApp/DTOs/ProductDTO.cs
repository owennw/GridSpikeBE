using ShoppingApp.Models;

namespace ShoppingApp.DTOs
{
    public class ProductDTO : EntityDTO
    {
        public ProductDTO(Product product) : base(product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }
    }
}