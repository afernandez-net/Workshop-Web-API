using Camones.Shop.Api.Validation;
using Camones.Shop.Application;
using Camones.Shop.Application.Adapters;
using Camones.Shop.Domain;
using Camones.Shop.Domain.Interfaces;
using Camones.Shop.Infrastructure;
using Camones.Shop.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace Camones.Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();



            services.AddTransient<IValidator<CustomerUpdateDto>, CustomerUpdateValidator>();

            services.AddApplication();

            services.AddAuth().AddSwaggerAuth();

            services.AddCors(confg =>
                confg.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()));

            services.AddSingleton<Serilog.ILogger>(x => {

                var connectionString = Configuration["Serilog:DefaultConnection"];
                var tableName = Configuration["Serilog:TableName"];

                var sqlLoggerOptions = new SinkOptions
                {
                    AutoCreateSqlTable = true,
                    SchemaName = "Logger",
                    TableName = tableName,
                    BatchPostingLimit = 1
                };

                return  new LoggerConfiguration()
                .MinimumLevel.Debug()                
                .WriteTo.MSSqlServer(connectionString, sqlLoggerOptions) 
                .CreateLogger();
            });

            //Infra
            //Domain
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Camones.Log-{Date}.txt");


            app.UseSwaggerAuth();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            //app.UseCors(x => x.WithOrigins("http://apirequest.io"));

            app.UseDatabase();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}