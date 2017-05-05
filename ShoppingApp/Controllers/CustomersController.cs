using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace ShoppingApp.Controllers
{
    public class CustomersController : ApiController
    {
        private IRepository<Customer> repository;

        public CustomersController()
        {
            this.repository = new CustomerRepository();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.repository.GetAll().Distinct(); // Distinct hack?
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = this.repository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
