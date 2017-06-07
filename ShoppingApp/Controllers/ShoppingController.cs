using ShoppingApp.DTOs;
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
        public Purchase Purchase { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class ShoppingController : ApiController
    {
        public IEnumerable<Shopping> GetAllShopping()
        {
            var unitOfWork = new UnitOfWork();
            var purchaseRepo = new Repository<Purchase>(unitOfWork);

            IEnumerable<Purchase> purchases = purchaseRepo.GetAll();

            var purchaseItemRepo = new Repository<PurchaseItem>(unitOfWork);

            var allPurchaseItems = purchaseItemRepo.GetAll();

            return purchases.Select(p =>
            {
                var purchaseItems = allPurchaseItems.Where(pi => pi.Purchase.Id == p.Id);
                return new Shopping
                {
                    Purchase = p,
                    Customer = p.Customer,
                    Date = p.Date,
                    NumberOfItems = purchaseItems.Sum(pi => pi.Quantity),
                    TotalCost = purchaseItems.Sum(pi => pi.Product.Price * pi.Quantity),
                };
            });
        }
    }
}
