using System.Collections.Generic;

namespace ShoppingApp.Models
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string EmailAddress { get; set; }

        public virtual IList<Purchase> Purchases { get; set; }
    }
}