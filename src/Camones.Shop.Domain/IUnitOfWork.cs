using System.Threading.Tasks;

namespace Camones.Shop.Domain
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}