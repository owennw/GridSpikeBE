using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShoppingApp.Models
{
    public class Customer
    {
        public virtual int Id { get; set; }

        [JsonIgnore]
        public virtual string FirstName { get; set; }

        [JsonIgnore]
        public virtual string LastName { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual IList<Purchase> Purchases { get; set; }

        public virtual string City { get; set; }

        public virtual Product FavouriteFood { get; set; }

        public string Name
        {
            get { return $"{this.FirstName} {this.LastName}"; }
        }
    }
}