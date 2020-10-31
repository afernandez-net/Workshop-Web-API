using Camones.Shop.Application.Adapters;
using Camones.Shop.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camones.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class CustomersController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            //var claims = User.Claims.ToList();
            return Collection(customerService.Get());
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CustomerDto> Get(Guid id)
            => Single(customerService.Get(id));

        [HttpPost]
        public ActionResult Post([FromBody] CustomerDto customerDto)
        {
            var customer = customerService.Post(customerDto);

            return new CreatedAtRouteResult("Get", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] CustomerUpdateDto customerDto)
        {
            if (id != customerDto.Id)
                return BadRequest();

            await customerService.Put(customerDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var customer = customerService.Get(id);

            if (customer == null)
                return NotFound();

            customerService.Delete(id);

            return Ok();
        }
    }
}