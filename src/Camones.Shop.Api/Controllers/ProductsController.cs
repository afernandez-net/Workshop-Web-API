using Camones.Shop.Application.Adapters;
using Camones.Shop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Camones.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService) 
            => this.productService = productService;

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
            => Collection(productService.Get());

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(Guid id)
            => Single(productService.Get(id));
    }
}