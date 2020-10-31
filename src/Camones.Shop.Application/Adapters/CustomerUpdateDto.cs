using System;

namespace Camones.Shop.Application.Adapters
{
    public class CustomerUpdateDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}