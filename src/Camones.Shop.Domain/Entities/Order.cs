using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Domain.Entities
{
    public class Order : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        //public ICollection<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public OrderStatus Status { get; set; }

        public enum OrderStatus : byte
        {
            Created = 0,
            Approved = 1,
            Completed = 2,
            Canceled = 3,
            Revoked = 4
        }
    }
}
