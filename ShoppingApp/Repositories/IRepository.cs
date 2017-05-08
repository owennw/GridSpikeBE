namespace ShoppingApp.Repositories
{
    using ShoppingApp.Models;
    using System.Collections.Generic;

    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
    }
}