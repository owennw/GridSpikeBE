using ShoppingApp.Models;
using System;
using System.Collections.Generic;

namespace ShoppingApp.DTOs
{
    public class PurchaseDTO : EntityDTO
    {
        public PurchaseDTO(Purchase purchase) : base(purchase)
        {
            this.Customer = purchase.Customer;
            this.Date = purchase.Date;
            this.PurchaseItems = purchase.PurchaseItems;
        }

        public Customer Customer { get; private set; }

        public DateTime Date { get; private set; }

        public IEnumerable<PurchaseItem> PurchaseItems { get; private set; }
    }
}