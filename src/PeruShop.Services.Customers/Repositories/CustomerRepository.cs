namespace PeruShop.Services.Customers.Repositories
{
    using PeruShop.Common.Repository;
    using PeruShop.Services.Customers.Domain;
    using PeruShop.Services.Customers.Infrastructure;
    using System;

    public class CustomerRepository : GenericRepository<Customer,Guid>, ICustomerRepository
    {
        public CustomerRepository(CustomersDbContext context) : base(context)
        {
        }
    }
}