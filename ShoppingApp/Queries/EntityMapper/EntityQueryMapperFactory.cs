using ShoppingApp.Models;
using System;

namespace ShoppingApp.Queries.EntityMapper
{
    public interface IEntityQueryMapper<T>
        where T : IEntity
    {
        Func<T, string> GetSelector(string key);
    }

    public static class EntityQueryMapperFactory
    {
        public static IEntityQueryMapper<T> Build<T>() where T: IEntity
        {
            if (typeof(T) == typeof(Customer)) {
                return new CustomerQueryMapper() as IEntityQueryMapper<T>;
            }

            throw new NotImplementedException($"Cannot build with unknown type {typeof(T)}");
        }
    }
}