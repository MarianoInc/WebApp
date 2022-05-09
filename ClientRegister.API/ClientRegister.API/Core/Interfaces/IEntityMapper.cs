using ClientRegister.Support.Entities;
using ClientRegister.Support.Models.Dtos;

namespace ClientRegister.API.Core.Interfaces
{
    public interface IEntityMapper
    {
        public AuthUserOutputDto UserToAuthUserOutputDto(User user, string token);
        public ClientToClientDto MapClientToClientDto(Client client);
        public Client MapClientDtoToClient(ClientDtoToClient clientDto);
        public ClientDtoToClient MapClientDtoToUpdateClient(ClientToClientDto clientDto);
        public Client MapClientDtoToUpdateClient(ClientToClientDto clientDto, Client client);
    }
}
