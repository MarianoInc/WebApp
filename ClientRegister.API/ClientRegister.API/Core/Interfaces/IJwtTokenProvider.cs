using ClientRegister.Support.Entities;
using System.Threading.Tasks;

namespace ClientRegister.API.Core.Interfaces
{
    public interface IJwtTokenProvider
    {
        Task<string> CreateJwtToken(User user);
    }
}
