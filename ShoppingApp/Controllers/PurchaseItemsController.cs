using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Linq;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class PurchaseItemsController : ApiController
    {
        public IQueryable<PurchaseItem> GetAllPurchaseItems()
        {
            var unitOfWork = new UnitOfWork();
            var repo = new Repository<PurchaseItem>(unitOfWork);

            return repo.GetAll(); //.Select(pi => new PurchaseItemDTO(pi));
        }

        public IHttpActionResult GetPurchaseItem(int id)
        {
            var unitOfWork = new UnitOfWork();
            var repo = new Repository<PurchaseItem>(unitOfWork);

            var purchaseItem = repo.GetById(id);
            if (purchaseItem == null)
            {
                return NotFound();
            }

            return Ok(purchaseItem);
        }
    }
}
