using System;
using System.Collections.Generic;

namespace ShoppingApp.Models
{
    public class Purchase
    {
        public virtual int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DateTime Date { get; set; }

        public virtual IList<PurchaseItem> PurchaseItems { get; set; }

        public override string ToString()
        {
            return $"{this.Customer.FirstName} {this.Customer.LastName} at {this.Date.ToLongTimeString()}";
        }
    }
}