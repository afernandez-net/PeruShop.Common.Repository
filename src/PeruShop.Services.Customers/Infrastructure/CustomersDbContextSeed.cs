namespace PeruShop.Services.Customers.Infrastructure
{
    using PeruShop.Services.Customers.Domain;
    using System;
    using System.Collections.Generic;
    public static class CustomersDbContextSeed
    {
        public static IEnumerable<Customer> Customers =>
            new Customer[]
            {
                new Customer
                {
                    Id = Guid.Parse( "328ec4ab-1b0b-4204-9886-b508a5d3d751"),
                    FirstName = "Juan",
                    LastName = "Perez",
                    Address = "Los Olivos",
                    Country = "Lima",
                    Email = "juan@perez.com"
                },
                new Customer
                {
                    Id = Guid.Parse( "c8560665-e9de-41ac-85b5-d304a298af9a"),
                    FirstName = "Perico",
                    LastName = "Palotes",
                    Address = "Lima #123",
                    Country = "Lima",
                    Email = "perico@palotes.com"
                }
            };
    }
}