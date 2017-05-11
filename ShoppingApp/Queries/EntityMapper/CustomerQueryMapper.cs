using ShoppingApp.Models;
using System;

namespace ShoppingApp.Queries.EntityMapper
{
    public class CustomerQueryMapper : IEntityQueryMapper<Customer>
    {
        public Func<Customer, string> GetSelector(string key)
        {
            switch (key)
            {
                case "first_name":
                    return c => c.FirstName;

                case "last_name":
                    return c => c.LastName;

                case "city":
                    return c => c.City;

                case "email_address":
                    return c => c.EmailAddress;

                default:
                    throw new ArgumentException($"{key} is not a valid key for Customer");
            }
        }
    }
}