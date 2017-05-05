using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class ProductsController : ApiController
    {
        private IRepository<Product> repository;

        public ProductsController()
        {
            this.repository = new ProductRepository();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.repository.GetAll();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = this.repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
