using Camones.Shop.Domain.Entities;
using System;

namespace Camones.Shop.Domain.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart, Guid>
    {
    }
}