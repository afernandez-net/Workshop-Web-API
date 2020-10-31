using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Application.Adapters
{
     public class ListadoClientesDto
    {
        public Guid CustomerId { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid OrderId { get; set; }
        public string Currency { get; set; }
        public int Status { get; set; }
    }
}
