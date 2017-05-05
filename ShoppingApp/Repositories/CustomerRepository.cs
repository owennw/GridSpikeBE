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
                return session
                    .QueryOver<Customer>()
                    .JoinQueryOver<Purchase>(c => c.Purchases)
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