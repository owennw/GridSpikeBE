using ShoppingApp.Models;
using System.Collections.Generic;

namespace ShoppingApp.DTOs
{
    public class CustomerDTO : EntityDTO
    {
        public CustomerDTO(Customer customer) : base(customer)
        {
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.City = customer.City;
            this.EmailAddress = customer.EmailAddress;
            this.Purchases = customer.Purchases;
            this.FavouriteFood = customer.FavouriteFood;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmailAddress { get; private set; }

        public IEnumerable<Purchase> Purchases { get; private set; }

        public string City { get; private set; }

        public Product FavouriteFood { get; private set; }
    }
}