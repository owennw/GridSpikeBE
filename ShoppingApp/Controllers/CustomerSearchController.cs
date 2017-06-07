using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Queries;
using ShoppingApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class CustomerSearchController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Search()
        {
            var queryDict = this.Request.GetQueryNameValuePairs().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            var queryManager = new QueryManager<Customer>(queryDict);

            var unitOfWork = new UnitOfWork();
            var repo = new Repository<Customer>(unitOfWork);

            var allCustomers = repo.GetAll();

            IEnumerable<Customer> filteredCustomers = allCustomers;

            foreach (var query in queryManager.Queries)
            {
                filteredCustomers = query.Run(filteredCustomers);
            }

            return Ok(filteredCustomers); //.Select(c => new CustomerDTO(c)));
        }
    }
}
