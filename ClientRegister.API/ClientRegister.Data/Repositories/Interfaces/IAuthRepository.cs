using ClientRegister.Support.Entities;
using ClientRegister.Support.Models.Dtos;
using System.Threading.Tasks;

namespace ClientRegister.Data.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> GetUserByNameOrDefault(AuthUserDto login);
    }
}
