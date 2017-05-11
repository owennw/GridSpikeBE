using ShoppingApp.Models;
using ShoppingApp.Queries;
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
