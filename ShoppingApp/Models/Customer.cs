using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShoppingApp.Models
{
    public class Customer: IEntity
    {
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual IEnumerable<Purchase> Purchases { get; set; }

        public virtual string City { get; set; }

        public virtual Product FavouriteFood { get; set; }
    }
}