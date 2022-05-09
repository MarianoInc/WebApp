using ClientRegister.Data.DataContext;
using ClientRegister.Data.Repositories.Interfaces;
using ClientRegister.Support.Entities;
using ClientRegister.Support.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClientRegister.Data.Repositories
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(ClientDbContext context) : base(context)
        {

        }
        public async Task<User> GetUserByNameOrDefault(AuthUserDto login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserName == login.UserName && x.IsActive == true);
        }
    }
}
