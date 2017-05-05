namespace ShoppingApp.Repositories
{
    using NHibernate;
    using System.Collections.Generic;

    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
    }
}