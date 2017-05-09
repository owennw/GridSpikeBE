using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class CustomerSearchController : ApiController
    {
        private IRepository<Customer> repository;

        public CustomerSearchController()
        {
            this.repository = new CustomerRepository();
        }

        [HttpGet]
        public IHttpActionResult Search()
        {
            var queryStringKeyValuePairs = this.Request.GetQueryNameValuePairs().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            var nameSearch = queryStringKeyValuePairs["query"];

            var customers = this.repository.GetAll()
                .Distinct()
                .Where(c => c.FirstName.Contains(nameSearch) || c.LastName.Contains(nameSearch));

            if (customers.Any())
            {
                return Ok(customers);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
