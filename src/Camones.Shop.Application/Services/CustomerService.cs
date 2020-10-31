using AutoMapper;
using Bogus;
using Camones.Shop.Application.Adapters;
using Camones.Shop.Domain;
using Camones.Shop.Domain.Entities;
using Camones.Shop.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Camones.Shop.Domain.Entities.Order;

namespace Camones.Shop.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerService> logger;
        private readonly Serilog.ILogger seriLogger;

        public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomerService> logger, Serilog.ILogger seriLogger)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.seriLogger = seriLogger;
        }

        public IEnumerable<CustomerDto> Get()
        {
            //#region Generar Insert Customer
            //var faker = new Faker<Customer>()
            //    .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            //    .RuleFor(o => o.LastName, f => f.Person.LastName)
            //    .RuleFor(o => o.Email, f => f.Person.Email)
            //    .RuleFor(o => o.Country, f => f.Person.Address.City)
            //    .RuleFor(o => o.Address, f => f.Person.Address.Street)
            //    .RuleFor(o => o.IsActive, f => f.Person.Random.Bool());

            //var fackerCustomers = faker.Generate(2).ToList();

            //customerRepository.InsertRange(fackerCustomers);

            //#endregion

            //#region Generar Insert Order
            //var currency = new[] { "SOL", "DOL", "EUR" };

            //var customerIds = fackerCustomers
            //    .Select(x => x.Id)
            //    .ToList();

            //var fakerOrder = new Faker<Order>()
            //    .RuleFor(o => o.CustomerId, f => f.PickRandom(customerIds))
            //     .RuleFor(o => o.Status, f => f.PickRandom<OrderStatus>())
            //     .RuleFor(o => o.Currency, f => f.PickRandom(currency))
            //     .RuleFor(o => o.TotalAmount, f => f.Random.Decimal(100M, 1000M));

            //var orders = fakerOrder.Generate(5).ToList();

            //orderRepository.InsertRange(orders);
            //#endregion






            //unitOfWork.SaveChanges();

            //var customerSp = customerRepository.ListSp<ListadoClientesDto>("SP_Orders");

            var customers = customerRepository.List();

            var clientesSinOrden = customerRepository.ClientesSinOrden();

            var result = mapper.Map<IEnumerable<CustomerDto>>(customers);

            return result;
        }

        public CustomerDto Get(Guid id)
        {
            var customer = customerRepository.Get(id);

            var result = mapper.Map<CustomerDto>(customer);

            return result;
        }

        public CustomerDto Post(CustomerDto customerDto)
        {
            
            logger.LogWarning("Mensaje Warning desde Post Customer");
            logger.LogError("Mensaje Error desde Post Customer");
            logger.LogCritical("Mensaje Critical desde Post Customer");

            seriLogger.Warning("Mensaje Warning desde Post Customer");
            seriLogger.Error("Mensaje Error desde Post Customer");
            seriLogger.Fatal("Mensaje Critical desde Post Customer");


            var customer = mapper.Map<Customer>(customerDto);

            customerRepository.Insert(customer);

            unitOfWork.SaveChanges();

            return mapper.Map<CustomerDto>(customer);
        }

        public async Task Put(CustomerUpdateDto customerDto)
        {

            //return Task.Run(()=> {

            //});

            var customer = customerRepository
                    .Set()
                    .FirstOrDefault(x => x.Id == customerDto.Id);

            mapper.Map(customerDto, customer);

            customerRepository.Update(customer);

            await unitOfWork.SaveChangesAsync();

        }

        public void Delete(Guid id)
        {
            var customer = customerRepository.Get(id);

            customerRepository.Delete(customer);

            unitOfWork.SaveChanges();
        }
    }
}