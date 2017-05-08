using NHibernate;
using ShoppingApp.Models;
using System.Collections.Generic;
using System;

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
                    .Left.JoinAlias(c => c.Purchases, () => purchases)
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

        public void Add(Customer customer)
        {
            this.PreserveIntegrity(customer);

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var existingCustomer = this.GetById(customer.Id);
                    if (existingCustomer != null)
                    {
                        session.SaveOrUpdate(customer);
                    }
                    else
                    {
                        session.Save(customer);
                    }

                    transaction.Commit();
                }
            }
        }

        private void PreserveIntegrity(Customer customer)
        {
            if (customer.Purchases == null)
            {
                return;
            }

            foreach (var purchase in customer.Purchases)
            {
                purchase.Customer = customer;

                foreach (var purchaseItem in purchase.PurchaseItems)
                {
                    purchaseItem.Purchase = purchase;
                }
            }
        }

        public void Delete(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var existingCustomer = this.GetById(customer.Id);
                    session.Delete(customer);
                    transaction.Commit();
                }
            }
        }
    }
}