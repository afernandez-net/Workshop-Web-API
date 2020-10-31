using Camones.Shop.Application.Adapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camones.Shop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> Get();

        ProductDto Get(Guid id);
    }
}
