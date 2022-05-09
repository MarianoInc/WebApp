using ClientRegister.API.Core.Interfaces;
using ClientRegister.Support.Entities;
using ClientRegister.Support.Models.Dtos;
using System;

namespace ClientRegister.API.Core.Mapper
{
    public class EntityMapper : IEntityMapper
    {
        public AuthUserOutputDto UserToAuthUserOutputDto(User user, string token)
        {
            var _authUserOutputDto = new AuthUserOutputDto
            {
                UserName = user.UserName,
                Token = token
            };

            return _authUserOutputDto;
        }

        public ClientToClientDto MapClientToClientDto(Client client)
        {
            var _clientDto = new ClientToClientDto
            {
                Id = client.Id,
                FullName = client.FullName,
                DNI = client.DNI,
                Age = client.Age,
                Gender = client.Gender,
                IsActive = client.IsActive,
                DriverLicense = client.DriverLicense,
                UseGlasses = client.UseGlasses,
                IsDiabetic = client.IsDiabetic,
                OtherDisease = client.OtherDisease,
                Disease = client.Disease,
                Properties = client.Properties                
            };

            return _clientDto;
        }

        public Client MapClientDtoToClient(ClientDtoToClient clientDto)
        {
            var _client = new Client
            {
                FullName = clientDto.FullName,
                DNI = clientDto.DNI,
                Age = clientDto.Age,
                Gender = clientDto.Gender,
                DriverLicense = clientDto.DriverLicense,
                UseGlasses = clientDto.UseGlasses,
                IsDiabetic = clientDto.IsDiabetic,
                OtherDisease = clientDto.OtherDisease,
                Disease = clientDto.Disease,
                Properties = clientDto.Properties,
                IsActive = true,
                ModifiedAt = DateTime.Now
            };
            return _client;
        }
        public ClientDtoToClient MapClientDtoToUpdateClient(ClientToClientDto clientDto)
        {
            var _clientDtoToClient = new ClientDtoToClient
            {
                FullName = clientDto.FullName,
                DNI = clientDto.DNI,
                Age = clientDto.Age,
                Gender = clientDto.Gender,
                DriverLicense = clientDto.DriverLicense,
                UseGlasses = clientDto.UseGlasses,
                IsDiabetic = clientDto.IsDiabetic,
                OtherDisease = clientDto.OtherDisease,
                Disease = clientDto.Disease,
                Properties = clientDto.Properties,
            };
            return _clientDtoToClient;
        }
        public Client MapClientDtoToUpdateClient(ClientToClientDto clientDto, Client client)
        {
            client.FullName = clientDto.FullName;
            client.DNI = clientDto.DNI;
            client.Age = clientDto.Age;
            client.Gender = clientDto.Gender;
            client.IsActive = clientDto.IsActive;
            client.DriverLicense = clientDto.DriverLicense;
            client.UseGlasses = clientDto.UseGlasses;
            client.IsDiabetic = clientDto.IsDiabetic;
            client.OtherDisease = clientDto.OtherDisease;
            client.Disease = clientDto.Disease;
            client.Properties = clientDto.Properties;

            return client;
        }
    }
}
