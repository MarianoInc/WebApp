using ClientRegister.API.Core.Interfaces;
using ClientRegister.Data.Repositories.Interfaces;
using ClientRegister.Support.Entities;
using ClientRegister.Support.Models;
using ClientRegister.Support.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRegister.API.Core.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _entityMapper;

        public ClientBusiness(IUnitOfWork unitOfWork, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
        }

        public async Task<IEnumerable<ClientToClientDto>> GetClientsAsync(bool clientState)
        {
            try
            {
                var clientsList = await _unitOfWork.ClientsRepository.GetAll(clientState);
                if (clientsList.Count() == 0)
                    return null;
                var result = new List<ClientToClientDto>();
                foreach (var client in clientsList)
                {
                    result.Add(_entityMapper.MapClientToClientDto(client));
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<Client>> GetClientAsync(int id)
        {
            var response = new Response<Client>();
            try
            {
                var client = await _unitOfWork.ClientsRepository.GetById(id);
                if (client.IsActive == false)
                {
                    response.Data = null;
                    response.Errors = null;
                    response.Succeeded = false;
                    response.Message = "Not Found";
                    return response;
                }
                response.Data = client;
                response.Succeeded = true;
                response.Message = "Success!"; 
                response.Errors = null;
            }
            catch (InvalidOperationException e)
            {
                var errorList = new string[] { e.Message };
                response.Succeeded = false;
                response.Errors = errorList;
                response.Data = null;
                response.Message = "Not Found";
                return response;
            }
            return response;
        }

        public async Task<Response<ClientDtoToClient>> AddClientAsync(ClientDtoToClient clientDto)
        {
            var response = new Response<ClientDtoToClient>();
            try
            {
                var clients = await _unitOfWork.ClientsRepository.GetAll(true);
                
                
                if (clients.FirstOrDefault(c => c.DNI == clientDto.DNI) != null)
                {

                    response.Message = "The client wheter exists and is active or is blocked in the system";
                    response.Succeeded = false;
                    response.Data = clientDto;
                    response.Errors = null;
                    return response;
                }
                var client = _entityMapper.MapClientDtoToClient(clientDto);
                await _unitOfWork.ClientsRepository.AddAsync(client);
                await _unitOfWork.SaveChangesAsync();
                response.Data = clientDto;
                response.Errors = null;
                response.Message = "Success!";
                response.Succeeded = true;
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<ClientDtoToClient>> UpdateClientAsync(ClientToClientDto clientDto)
        {
            var response = new Response<ClientDtoToClient>();
            try
            {
                var existingClient = await _unitOfWork.ClientsRepository.GetById(clientDto.Id);
                if (existingClient == null)
                {
                    response.Message = "The client doesn't exists or is blocked in the system.";
                    response.Succeeded = false;
                    response.Data = _entityMapper.MapClientDtoToUpdateClient(clientDto);
                    response.Errors = null;
                    return response;
                }
                await _unitOfWork.ClientsRepository.Update(_entityMapper.MapClientDtoToUpdateClient(clientDto, existingClient));
                await _unitOfWork.SaveChangesAsync();
                response.Data = _entityMapper.MapClientDtoToUpdateClient(clientDto);
                response.Errors = null;
                response.Message = "Success!";
                response.Succeeded = true;
                return response;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Client>> DeleteClientAsync(int id)
        {
            var response = new Response<Client>();
            try
            {
                await _unitOfWork.ClientsRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                response.Succeeded = true;
                response.Message = "Entity deleted succesfully.";
                response.Errors = null;
                response.Data = null;
            }
            catch (InvalidOperationException e)
            {
                var errorList = new string[] { e.Message };
                response.Succeeded = false;
                response.Message = "Not Found";
                response.Errors = errorList;
                response.Data = null;
                return response;
            }
            return response;
        }
    }
}
