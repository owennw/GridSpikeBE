using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class PurchaseItemsController : ApiController
    {
        private IRepository<PurchaseItem> repository;

        public PurchaseItemsController()
        {
            this.repository = new PurchaseItemRepository();
        }

        public IEnumerable<PurchaseItem> GetAllPurchaseItems()
        {
            return this.repository.GetAll();
        }

        public IHttpActionResult GetPurchaseItem(int id)
        {
            var purchase = this.repository.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }
    }
}
