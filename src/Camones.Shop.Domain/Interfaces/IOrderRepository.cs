using Camones.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order, Guid>
    {
        
    }
}
