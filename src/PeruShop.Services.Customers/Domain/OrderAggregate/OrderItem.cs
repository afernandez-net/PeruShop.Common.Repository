using PeruShop.Common.Repository;
using System;

namespace PeruShop.Services.Customers.Domain
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        //public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public object[] GetKeys()
        {
            return new object[] { OrderId, ProductId };
        }
    }
}