using ShoppingApp.Models;
using ShoppingApp.Repositories;

namespace ShoppingApp.Controllers
{
    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
