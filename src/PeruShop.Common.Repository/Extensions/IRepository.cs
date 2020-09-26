namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public interface IRepository<TContext> where TContext : DbContext
    {
        IRepository<TContext> AddRepository<TEntity>() where TEntity : BaseEntity;

        IRepository<TContext> AddRepository<TEntity>(Action<RepositoryOptions<TEntity>> options) where TEntity : BaseEntity;
    }
}