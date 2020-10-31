using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Domain.Entities
{
    public class Cart : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
