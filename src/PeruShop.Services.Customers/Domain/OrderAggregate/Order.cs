using PeruShop.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeruShop.Services.Customers.Domain
{
    public class Order: Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        //public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public OrderStatus Status { get; set; }
    }
}
