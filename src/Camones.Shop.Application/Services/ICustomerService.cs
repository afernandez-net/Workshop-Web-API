namespace Camones.Shop.Application.Services
{
    using Camones.Shop.Application.Adapters;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        IEnumerable<CustomerDto> Get();

        CustomerDto Get(Guid id);

        CustomerDto Post(CustomerDto customerDto);

        Task Put(CustomerUpdateDto customerDto);

        void Delete(Guid id);
    }
}