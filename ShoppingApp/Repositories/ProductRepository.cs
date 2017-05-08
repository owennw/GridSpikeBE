using NHibernate;
using ShoppingApp.Models;
using System.Collections.Generic;
using System;

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

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }
    }
}