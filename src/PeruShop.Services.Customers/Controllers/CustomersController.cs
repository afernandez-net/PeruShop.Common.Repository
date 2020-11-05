namespace PeruShop.Services.Customers.Controllers
{    
    using Microsoft.AspNetCore.Mvc;
    using PeruShop.Services.Customers.Domain;
    using PeruShop.Services.Customers.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customersRepository;

        public CustomersController(ICustomerRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await customersRepository.FindAsync(_ => true);
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Customer> Get(Guid id)            
        {
            return await customersRepository.GetAsync(id);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult> Post(Customer customer)
        {
            await customersRepository.AddAsync(customer);

            return Ok();
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Customer customer)
        {
            await customersRepository.UpdateAsync(customer);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await customersRepository.DeleteAsync(id);

            return Ok();
        }
    }
}
