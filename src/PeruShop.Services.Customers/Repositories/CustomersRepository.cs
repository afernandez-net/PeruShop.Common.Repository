namespace PeruShop.Services.Customers.Repositories
{
    using PeruShop.Common.Repository;
    using PeruShop.Services.Customers.Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CustomersRepository : ICustomersRepository
    {
        private readonly ISqlRepository<Customer> _repository;

        public CustomersRepository(ISqlRepository<Customer> repository)
            => _repository = repository;

        public async Task<Customer> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<Customer>> BrowseAsync()
            => await _repository.FindAsync(_ => true);

        public async Task AddAsync(Customer customer)
            => await _repository.AddAsync(customer);

        public async Task UpdateAsync(Customer customer)
            => await _repository.UpdateAsync(customer);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}