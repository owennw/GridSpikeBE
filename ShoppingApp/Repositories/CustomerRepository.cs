using NHibernate;
using ShoppingApp.Models;
using System.Collections.Generic;

namespace ShoppingApp.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public IList<Customer> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IEnumerable<Purchase> purchases = null;
                Product favouriteFood = null;

                return session
                    .QueryOver<Customer>()
                    .JoinAlias(c => c.Purchases, () => purchases)
                    .Left.JoinAlias(c => c.FavouriteFood, () => favouriteFood)
                    .List();
            }
        }

        public Customer GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Customer>(id);
            }
        }
    }
}