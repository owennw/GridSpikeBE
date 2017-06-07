using ShoppingApp.DTOs;
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
        public IHttpActionResult GetShop(int id)
        {
            var unitOfWork = new UnitOfWork();
            var purchaseRepo = new Repository<Purchase>(unitOfWork);

            var purchase = purchaseRepo.GetById(id);

            if (purchase == null)
            {
                return NotFound();
            }

            var purchaseItemRepo = new Repository<PurchaseItem>(unitOfWork);

            var allPurchaseItems = purchaseItemRepo.GetAll().Where(pi => pi.Purchase.Id == id);

            return Ok(new Shop
            {
                Customer = purchase.Customer,
                Date = purchase.Date,
                Products = allPurchaseItems //.Select(p => new PurchaseItemDTO(p))
            });
        }
    }
}
