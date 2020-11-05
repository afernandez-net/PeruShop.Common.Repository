namespace PeruShop.Common.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IGenericRepository<T, K> : IGeneric<T> where T : Entity<K>
    {
        Task<T> GetAsync(K id);

        Task DeleteAsync(K id);
    }

    public interface IGenericRepository<T> : IGeneric<T> where T : Entity
    {
        Task<T> GetAsync(object[] keyParams);

        Task DeleteAsync(object[] keyParams);
    }

    public interface IGeneric<T> where T : class
    {
        IQueryable<T> Query();

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}