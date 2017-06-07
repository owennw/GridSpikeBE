namespace ShoppingApp.Repositories
{
    using ShoppingApp.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
    }
}