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

        public IRepository<TContext> RepositoryOptions<TEntity>(Action<RepositoryOptions<TEntity>> repositoryOptions) where TEntity : class
        {
            DbContext context = services.BuildServiceProvider().GetService<TContext>();

            RepositoryOptions<TEntity> options = new RepositoryOptions<TEntity>();

            repositoryOptions(options);

            foreach (var item in options.Seed)
            {
                var entry = context.Entry(item);

                var keys = entry
                    .Metadata
                    .FindPrimaryKey()
                    .Properties.Select(p => entry.Property(p.Name).CurrentValue)
                    .ToArray();

                if (context.Set<TEntity>().Find(keys) != null)
                    continue;

                context.Set<TEntity>().Add(item);
            }

            context.SaveChanges();

            return this;
        }
    }
}