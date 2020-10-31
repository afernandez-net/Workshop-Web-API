using Camones.Shop.Domain.Entities;
using System;

namespace Camones.Shop.Domain.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem, Guid>
    {
    }
}