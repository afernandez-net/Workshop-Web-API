using Camones.Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Camones.Shop.Domain.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer, Guid>
    {
        IEnumerable<Customer> ClientesSinOrden();
    }
}