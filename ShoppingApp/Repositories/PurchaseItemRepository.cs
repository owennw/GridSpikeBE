using NHibernate;
using ShoppingApp.Models;
using System.Collections.Generic;

namespace ShoppingApp.Repositories
{
    public class PurchaseItemRepository : IRepository<PurchaseItem>
    {
        public IList<PurchaseItem> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Purchase purchase = null;
                Product product = null;

                return session
                    .QueryOver<PurchaseItem>()
                    .JoinAlias(pi => pi.Purchase, () => purchase)
                    .JoinAlias(pi => pi.Product, () => product)
                    .List();
            }
        }

        public PurchaseItem GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<PurchaseItem>(id);
            }
        }
    }
}