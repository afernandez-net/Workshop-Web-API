namespace Camones.Shop.Infrastructure.Repositories
{
    using Camones.Shop.Domain.Entities;
    using Camones.Shop.Domain.Interfaces;
    using System;

    public class ProductRepository : GenericRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}