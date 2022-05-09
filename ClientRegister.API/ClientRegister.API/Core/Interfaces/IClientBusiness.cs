using ClientRegister.Support.Entities;
using ClientRegister.Support.Models;
using ClientRegister.Support.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientRegister.API.Core.Interfaces
{
    public interface IClientBusiness
    {
        public Task<IEnumerable<ClientToClientDto>> GetClientsAsync(bool clientState);
        public Task<Response<Client>> GetClientAsync(int id);
        public Task<Response<ClientDtoToClient>> AddClientAsync(ClientDtoToClient clientDto);
        public Task<Response<ClientDtoToClient>> UpdateClientAsync(ClientToClientDto clientDto);
        public Task<Response<Client>> DeleteClientAsync(int id);
    }
}
