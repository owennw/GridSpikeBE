using NHibernate;
using NHibernate.Linq;
using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
    }

    public class Repository<T> : IRepository<T>
        where T : IEntity
    {
        private readonly IUnitOfWork unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual void Add(T entity)
        {
            this.unitOfWork.BeginTransaction();

            var existingEntity = this.GetById(entity.Id);
            if (existingEntity != null)
            {
                this.unitOfWork.Session.SaveOrUpdate(entity);
            }
            else
            {
                this.unitOfWork.Session.Save(entity);
            }

            this.unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            this.unitOfWork.BeginTransaction();

            this.unitOfWork.Session.Delete(entity);

            this.unitOfWork.Commit();
        }

        public IQueryable<T> GetAll()
        {
            return this.unitOfWork.Session.Query<T>();
        }

        public T GetById(int id)
        {
            return this.unitOfWork.Session.Get<T>(id);
        }
    }
}