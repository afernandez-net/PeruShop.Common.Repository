namespace PeruShop.Common.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// SqlServer, MySql, Posgres
    /// </summary>
    public static class Extensions
    {
        public static IRepository<TContext> AddSql<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            using var serviceScope = services
                .BuildServiceProvider()
                .GetService<IServiceScopeFactory>()
                .CreateScope();

            var context = serviceScope
                .ServiceProvider
                .GetRequiredService<TContext>();

            context.Database.EnsureCreated();

            return new Repository<TContext>(services);
        }


    }
}