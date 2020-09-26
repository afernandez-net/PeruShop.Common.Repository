namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Repository<TContext> : IRepository<TContext> where TContext : DbContext
    {
        private readonly IServiceCollection services;

        public Repository(IServiceCollection services)
            => this.services = services;

        public IRepository<TContext> AddRepository<TEntity>() where TEntity : BaseEntity
        {
            DbContext context = services.BuildServiceProvider().GetService<TContext>();

            services.AddSingleton<ISqlRepository<TEntity>>(p => new SqlRepository<TEntity>(context));

            return this;
        }
    }
}