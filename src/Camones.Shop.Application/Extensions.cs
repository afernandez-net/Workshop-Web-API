namespace Camones.Shop.Application
{
    using AutoMapper;
    using Camones.Shop.Application.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MappingProfile));

            service.AddScoped<ICustomerService, CustomerService>();

            service.AddScoped<IProductService, ProductService>();

            return service;
        }
    }
}