using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Domain.Entities
{
    public class CartItem : Entity<Guid>
    {
        public Guid CardId { get; set; }
        public Cart Card { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
