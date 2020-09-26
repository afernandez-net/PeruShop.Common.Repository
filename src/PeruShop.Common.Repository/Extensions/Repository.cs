namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

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

        public IRepository<TContext> AddRepository<TEntity>(Action<RepositoryOptions<TEntity>> repositoryOptions) where TEntity : BaseEntity
        {
            DbContext context = services.BuildServiceProvider().GetService<TContext>();

            DbSeeder(context, repositoryOptions);

            services.AddSingleton<ISqlRepository<TEntity>>(p => new SqlRepository<TEntity>(context));

            return this;
        }

        private void DbSeeder<TEntity>(DbContext context, Action<RepositoryOptions<TEntity>> repositoryOptions) where TEntity : BaseEntity
        {
            RepositoryOptions<TEntity> options = new RepositoryOptions<TEntity>();

            repositoryOptions(options);

            foreach (var item in options.Seed)
            {
                if (context.Set<TEntity>().Any(x => x.Id == item.Id))
                    continue;

                context.Set<TEntity>().Add(item);
            }

            context.SaveChanges();
        }
    }
}