namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public interface IRepository<TContext> where TContext : DbContext
    {
        IRepository<TContext> RepositoryOptions<TEntity>(Action<RepositoryOptions<TEntity>> options) where TEntity : class;
    }
}