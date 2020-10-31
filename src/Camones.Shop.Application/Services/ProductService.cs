using AutoMapper;
using Bogus;
using Camones.Shop.Application.Adapters;
using Camones.Shop.Domain;
using Camones.Shop.Domain.Entities;
using Camones.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camones.Shop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IEnumerable<ProductDto> Get()
        {
            #region Generar Insert Product
            //var faker = new Faker<Product>()
            //    .RuleFor(o => o.Name, f => f.Commerce.ProductName())
            //    .RuleFor(o => o.Description, f => f.Commerce.ProductDescription().Substring(0,50))
            //    .RuleFor(o => o.Category, f => f.Commerce.ProductAdjective())
            //    .RuleFor(o => o.UrlImage, f => f.Image.LoremFlickrUrl(320, 240, "phone"))
            //    .RuleFor(o => o.Price, f => decimal.Parse(f.Commerce.Price(1, 100)))
            //    .RuleFor(o => o.Quantity, f => f.Random.Int(1, 10))
            //    .RuleFor(o => o.IsActive, f => f.Person.Random.Bool());

            //var fackerProducts = faker.Generate(20).ToList();

            //productRepository.InsertRange(fackerProducts);


            //unitOfWork.SaveChanges();

            #endregion

            var customers = productRepository.List();


            var result = mapper.Map<IEnumerable<ProductDto>>(customers);

            return result;
        }

        public ProductDto Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
