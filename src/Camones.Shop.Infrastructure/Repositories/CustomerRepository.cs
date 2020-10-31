using Camones.Shop.Domain.Entities;
using Camones.Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Camones.Shop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(ShopContext context) : base(context)
        {
        }

        public new Customer Get(Guid id)
            => this.Set()
            .Include(x => x.Orders)
            .Where(x => x.Id == id)
            .FirstOrDefault();

        public IEnumerable<Customer> ClientesSinOrden()
            => this.Set()
            //.Include(x=> x.Orders)
            .Where(x=> x.Orders.Any())
            .ToList();
    }
}