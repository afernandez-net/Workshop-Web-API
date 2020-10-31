using Camones.Shop.Domain;
using System.Threading.Tasks;

namespace Camones.Shop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext context;

        public UnitOfWork(ShopContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {            
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}