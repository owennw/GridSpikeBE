using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;

namespace ShoppingApp.Controllers
{
    public class CustomersController : GenericController<Customer, CustomerDTO>
    {
        public CustomersController(IUnitOfWork unitOfWork) : base(unitOfWork, c => new CustomerDTO(c))
        {
        }
    }
}
