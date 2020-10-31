using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Domain.Entities
{
    public class Customer : Entity<Guid>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Cart Cart { get; set; }
    }
}
