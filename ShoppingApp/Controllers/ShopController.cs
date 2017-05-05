using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class Shop
    {
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<PurchaseItem> Products { get; set; }
    }

    public class ShopController : ApiController
    {
        private IRepository<Purchase> purchaseRepository;
        private IRepository<PurchaseItem> purchaseItemRepository;

        public ShopController()
        {
            this.purchaseRepository = new PurchaseRepository();
            this.purchaseItemRepository = new PurchaseItemRepository();
        }

        public IHttpActionResult GetShop(int id)
        {
            var purchase = this.purchaseRepository.GetById(id);

            if (purchase == null)
            {
                return NotFound();
            }

            var allPurchaseItems = this.purchaseItemRepository.GetAll().Where(pi => pi.Purchase.Id == id);

            return Ok(new Shop
            {
                Customer = purchase.Customer,
                Date = purchase.Date,
                Products = allPurchaseItems
            });
        }
    }
}
