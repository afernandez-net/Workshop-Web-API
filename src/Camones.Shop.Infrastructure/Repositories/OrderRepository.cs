namespace Camones.Shop.Infrastructure.Repositories
{
    using Camones.Shop.Domain.Entities;
    using Camones.Shop.Domain.Interfaces;
    using System;

    public class OrderRepository : GenericRepository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }
    }
}