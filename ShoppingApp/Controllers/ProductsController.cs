using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ShoppingApp.Controllers
{
    public class ProductsController : ApiController
    {
        [EnableQuery]
        public IQueryable<Product> GetAllProducts()
        {
            var unitOfWork = new UnitOfWork();
            var repo = new Repository<Product>(unitOfWork);
            return repo.GetAll(); //.Select(p => new ProductDTO(p));
        }

        public IHttpActionResult GetProduct(int id)
        {
            var unitOfWork = new UnitOfWork();
            var repo = new Repository<Product>(unitOfWork);
            var product = repo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
