using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class PurchasesController : ApiController
    {
        private IRepository<Purchase> repository;

        public PurchasesController()
        {
            this.repository = new PurchaseRepository();
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            return this.repository.GetAll();
        }

        public IHttpActionResult GetPurchase(int id)
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
