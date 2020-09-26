namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class SqlRepository<TEntity> : ISqlRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> DbSet { get; }
        protected DbContext Context { get; }

        public SqlRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Guid id)
            => await GetAsync(e => e.Id == id);

        public IQueryable<TEntity> Query()
            => DbSet;

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await DbSet.Where(predicate).FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await DbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
            => await DbSet.Where(predicate).AnyAsync();
    }
}