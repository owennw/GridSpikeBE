using NHibernate;
using NHibernate.Cfg;
using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShoppingApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory sessionFactory;

        private ITransaction transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the
            // application lifetime - the first time the UnitOfWork class is used
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly("ShoppingApp");
            sessionFactory = configuration.BuildSessionFactory();
        }

        public UnitOfWork()
        {
            this.Session = sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            this.transaction = this.Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (this.transaction != null && this.transaction.IsActive)
                {
                    this.transaction.Commit();
                }
            }
            catch
            {
                // rollback if there was an exception
                if (this.transaction != null && this.transaction.IsActive)
                {
                    this.transaction.Rollback();
                }

                throw;
            }
            finally
            {
                this.Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (this.transaction != null && this.transaction.IsActive)
                {
                    this.transaction.Rollback();
                }
            }
            finally
            {
                this.Session.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Session != null)
                {
                    this.Session.Dispose();
                }

                if (this.transaction != null)
                {
                    this.transaction.Dispose();
                }
            }
        }
    }
}