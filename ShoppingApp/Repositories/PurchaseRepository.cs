using NHibernate;
using ShoppingApp.Models;
using System.Collections.Generic;
using System;

namespace ShoppingApp.Repositories
{
    public class PurchaseRepository : IRepository<Purchase>
    {
        public IList<Purchase> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IEnumerable<PurchaseItem> purchaseItems = null;

                return session
                    .QueryOver<Purchase>()
                    .JoinAlias(p => p.PurchaseItems, () => purchaseItems)
                    .List();
            }
        }

        public Purchase GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Purchase>(id);
            }
        }

        public void Add(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public void Delete(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}