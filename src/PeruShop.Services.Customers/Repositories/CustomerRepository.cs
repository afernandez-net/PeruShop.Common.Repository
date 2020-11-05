namespace PeruShop.Services.Customers.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PeruShop.Common.Repository;
    using PeruShop.Services.Customers.Domain;
    using PeruShop.Services.Customers.Infrastructure;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CustomerRepository : GenericRepository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(CustomersDbContext context) : base(context)
        {
        }

        public new async Task<Customer> GetAsync(Guid id)
        {
            return await DbSet
                .Include(i => i.Orders)
                .ThenInclude(it => it.Items)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}