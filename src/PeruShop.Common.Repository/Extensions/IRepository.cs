namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;

    public interface IRepository<TContext> where TContext : DbContext
    {
        IRepository<TContext> AddRepository<TEntity>() where TEntity : BaseEntity;
    }
}