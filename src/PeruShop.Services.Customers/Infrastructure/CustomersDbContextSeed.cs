﻿namespace PeruShop.Services.Customers.Infrastructure
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
                    Address = new CustomerAddress {
                        City ="Lima",
                        Country = "Perú",
                        ProvinceState="Lima",
                        StreetAdress ="Los Olivos"
                    },
                    Email = "juan@perez.com",
                    IsActive=true
                },
                new Customer
                {
                    Id = Guid.Parse( "c8560665-e9de-41ac-85b5-d304a298af9a"),
                    FirstName = "Perico",
                    LastName = "Palotes",
                    Address = new CustomerAddress {
                        City ="Lima",
                        Country = "Perú",
                        ProvinceState="Lima",
                        StreetAdress ="Lince"
                    },
                    Email = "perico@palotes.com",
                    IsActive=true
                }
            };

        public static IEnumerable<Order> Orders =>
            new Order[]
    {
                new Order
                {
                    Id = Guid.Parse( "c2f3ea40-6b01-4bab-8b67-f5dd9a7f2e39"),
                    CustomerId = Guid.Parse( "328ec4ab-1b0b-4204-9886-b508a5d3d751"),
                    Currency="DOL",
                    Status = OrderStatus.Created,
                }
    };

        public static IEnumerable<OrderItem> OrderItems =>
            new OrderItem[]
            {
                new OrderItem
                {
                    OrderId = Guid.Parse( "c2f3ea40-6b01-4bab-8b67-f5dd9a7f2e39"),
                    ProductId = Guid.Parse( "9eab8c38-3b51-4d7e-8b4c-2266d4228a7a"),
                },
                new OrderItem
                {
                    OrderId = Guid.Parse( "c2f3ea40-6b01-4bab-8b67-f5dd9a7f2e39"),
                    ProductId = Guid.Parse( "c0ddf0fd-e70f-46f3-9869-1f92ae0f7961"),
                }
            };
    }
}