using System;

namespace Camones.Shop.Application.Adapters
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; set; }
        public string UrlImage { get; set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}