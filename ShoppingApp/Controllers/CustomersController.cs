using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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

        [AcceptVerbs("POST", "PUT")]
        public IHttpActionResult Add(Customer customer)
        {
            try
            {
                this.repository.Add(customer);

                return Ok(customer);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Delete(Customer customer)
        {
            try
            {
                this.repository.Delete(customer);

                return Ok(customer);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
