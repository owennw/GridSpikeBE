using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System;
using System.Collections.Generic;
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
            var queryDict = this.Request.GetQueryNameValuePairs().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            var queryManager = new QueryManager<Customer>(queryDict);

            queryManager.Add("first_name", c => c.FirstName);
            queryManager.Add("last_name", c => c.LastName);
            queryManager.Add("city", c => c.City);
            queryManager.Add("email_address", c => c.EmailAddress);

            var allCustomers = this.repository.GetAll()
                .Distinct();

            var filteredCustomers = allCustomers;

            foreach (var query in queryManager.Queries)
            {
                filteredCustomers = query.Run(filteredCustomers);
            }

            return Ok(filteredCustomers);
        }
    }
}
