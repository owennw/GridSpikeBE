using NHibernate;
using ShoppingApp.Models;
using System.Collections.Generic;

namespace ShoppingApp.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public IList<Product> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Product>().List();
            }
        }

        public Product GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Product>(id);
            }
        }
    }
}