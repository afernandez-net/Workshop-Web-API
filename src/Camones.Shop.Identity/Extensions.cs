namespace Camones.Shop.Identity
{
    using Camones.Shop.Identity.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class Extensions
    {
        public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var env = serviceScope.ServiceProvider.GetService<IWebHostEnvironment>();

                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();

                new ApplicationDbContextSeed().Seed(context);
            }

            return app;
        }
    }
}