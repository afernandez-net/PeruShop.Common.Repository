namespace PeruShop.Services.Customers.Repositories
{
    using PeruShop.Services.Customers.Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);

        Task<IEnumerable<Customer>> BrowseAsync();

        Task AddAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task DeleteAsync(Guid id);
    }
}