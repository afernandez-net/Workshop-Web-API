namespace Camones.Shop.Application.Adapters
{
    using Camones.Shop.Application.Helpers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "Maximo 10 caracteres")]
        [FirstLetterUpper]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }

        [Url]
        public string Url { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }
    }
}