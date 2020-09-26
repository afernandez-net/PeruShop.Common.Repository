namespace PeruShop.Common.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public interface ISqlRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query();

        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}