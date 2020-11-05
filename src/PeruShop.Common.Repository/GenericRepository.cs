namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class GenericRepository<T, K> : Generic<T>, IGenericRepository<T, K> where T : Entity<K>
    {
        public GenericRepository(DbContext context) : base(context)
        {
        }

        public async Task<T> GetAsync(K id)
            => await DbSet.FindAsync(id);

        public async Task DeleteAsync(K id)
        {
            var entity = await GetAsync(id);
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

    public class GenericRepository<T> : Generic<T>, IGenericRepository<T> where T : Entity
    {
        public GenericRepository(DbContext context) : base(context)
        {
        }

        public async Task<T> GetAsync(object[] keyParams)
            => await DbSet.FindAsync(keyParams);

        public async Task DeleteAsync(object[] keyParams)
        {
            var entity = await GetAsync(keyParams);
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

    public class Generic<T> where T : class
    {
        protected DbSet<T> DbSet { get; }
        protected DbContext Context { get; }

        public Generic(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IQueryable<T> Query()
            => DbSet;

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
            => await DbSet.Where(predicate).FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await DbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
            => await DbSet.Where(predicate).AnyAsync();
    }
}