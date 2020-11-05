namespace PeruShop.Services.Customers.Domain
{
    using PeruShop.Common.Repository;
    using System;
    using System.Collections.Generic;

    public class Customer : Entity<Guid>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerAddress Address { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}