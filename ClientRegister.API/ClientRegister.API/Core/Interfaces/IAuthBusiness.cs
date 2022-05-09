using ClientRegister.Support.Models;
using ClientRegister.Support.Models.Dtos;

namespace ClientRegister.API.Core.Interfaces
{
    public interface IAuthBusiness
    {
        Response<AuthUserOutputDto> LoginUser(AuthUserDto login);
    }
}
