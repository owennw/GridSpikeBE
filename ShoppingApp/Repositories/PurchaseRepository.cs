using NHibernate;
using ShoppingApp.Models;
using System.Collections.Generic;

namespace ShoppingApp.Repositories
{
    public class PurchaseRepository : IRepository<Purchase>
    {
        public IList<Purchase> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Purchase>().List();
            }
        }

        public Purchase GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Purchase>(id);
            }
        }
    }
}