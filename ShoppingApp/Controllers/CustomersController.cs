using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ShoppingApp.Controllers
{
    public class CustomersController : ApiController
    {
        [EnableQuery]
        public IQueryable<Customer> GetAllCustomers()
        {
            var unitOfWork = new UnitOfWork();
            var repo = new CustomerRepository(unitOfWork);
            return repo.GetAll(); //.Select(c => new CustomerDTO(c));
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var unitOfWork = new UnitOfWork();
            var repo = new CustomerRepository(unitOfWork);

            var customer = repo.GetById(id);
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
                var unitOfWork = new UnitOfWork();
                var repo = new CustomerRepository(unitOfWork);
                repo.Add(customer);

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
                var unitOfWork = new UnitOfWork();
                var repo = new CustomerRepository(unitOfWork);

                repo.Delete(customer);

                return Ok(customer);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
