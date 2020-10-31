namespace Camones.Shop.Application
{
    using AutoMapper;
    using Camones.Shop.Application.Adapters;
    using Camones.Shop.Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();

            

            CreateMap<Order, OrderDto>().ReverseMap();


            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}