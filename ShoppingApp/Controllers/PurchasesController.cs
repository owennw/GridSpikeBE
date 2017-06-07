using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    [DataContract(IsReference = true)]
    public class PurchasesController : ApiController
    {
        public IQueryable<Purchase> GetAllPurchases()
        {
            var unitOfWork = new UnitOfWork();
            var repo = new Repository<Purchase>(unitOfWork);

            return repo.GetAll(); //.Select(p => new PurchaseDTO(p)); ;
        }

        public IHttpActionResult GetPurchase(int id)
        {
            var unitOfWork = new UnitOfWork();
            var repo = new Repository<Purchase>(unitOfWork);

            var purchase = repo.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }
    }
}
