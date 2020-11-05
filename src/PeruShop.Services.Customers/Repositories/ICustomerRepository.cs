namespace PeruShop.Services.Customers.Repositories
{
    using PeruShop.Common.Repository;
    using PeruShop.Services.Customers.Domain;
    using System;

    public interface ICustomerRepository : IGenericRepository<Customer,Guid>
    {
    }
}