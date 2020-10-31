using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Domain.Entities
{
    public class Product : Entity<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; set; }
        public string UrlImage { get; set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
