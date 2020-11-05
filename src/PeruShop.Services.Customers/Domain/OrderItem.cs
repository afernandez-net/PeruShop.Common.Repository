using PeruShop.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeruShop.Services.Customers.Domain
{
    public class OrderItem:Entity
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }

        public object[] GetKeys()
        {
            return new object[] { CustomerId, ProductId };
        }
    }
}
