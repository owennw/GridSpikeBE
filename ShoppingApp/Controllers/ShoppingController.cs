using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShoppingApp.Controllers
{
    public class Shopping
    {
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class ShoppingController : ApiController
    {
        private IRepository<Purchase> purchaseRepository;
        private IRepository<PurchaseItem> purchaseItemRepository;

        public ShoppingController()
        {
            this.purchaseRepository = new PurchaseRepository();
            this.purchaseItemRepository = new PurchaseItemRepository();
        }

        public IEnumerable<Shopping> GetAllShopping()
        {
            var purchases = this.purchaseRepository.GetAll();
            var allPurchaseItems = this.purchaseItemRepository.GetAll();

            return purchases.Select(p =>
            {
                var purchaseItems = allPurchaseItems.Where(pi => pi.Purchase.Id == p.Id);
                return new Shopping
                {
                    Customer = p.Customer,
                    Date = p.Date,
                    NumberOfItems = purchaseItems.Sum(pi => pi.Quantity),
                    TotalCost = purchaseItems.Sum(pi => pi.Price),
                };
            });
        }
    }
}
