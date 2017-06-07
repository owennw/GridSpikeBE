using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;

namespace ShoppingApp.Controllers
{
    public class ProductsController : GenericController<Product, ProductDTO>
    {
        public ProductsController(IUnitOfWork unitOfWork) : base(unitOfWork, p => new ProductDTO(p))
        {
        }
    }
}
