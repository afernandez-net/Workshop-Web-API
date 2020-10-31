using System;

namespace Camones.Shop.Application.Adapters
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

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