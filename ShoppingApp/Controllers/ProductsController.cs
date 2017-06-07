using ShoppingApp.Models;
using ShoppingApp.Repositories;

namespace ShoppingApp.Controllers
{
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
