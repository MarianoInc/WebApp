using ClientRegister.Support.Entities;
using System.Threading.Tasks;

namespace ClientRegister.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Client> ClientsRepository { get; }
        IRepository<Rol> RolRepository { get; }
        IRepository<User> UserRepository { get; }
        IAuthRepository AuthRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();

        void Dispose();
    }
}
