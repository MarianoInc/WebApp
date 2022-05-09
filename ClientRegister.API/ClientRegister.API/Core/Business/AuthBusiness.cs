using ClientRegister.API.Core.Interfaces;
using ClientRegister.Data.Repositories.Interfaces;
using ClientRegister.Support.Encrypt;
using ClientRegister.Support.Models;
using ClientRegister.Support.Models.Dtos;
using System;

namespace ClientRegister.API.Core.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly IEntityMapper _entityMapper;
        public AuthBusiness(IUnitOfWork unitOfWork, IJwtTokenProvider jwtTokenProvider, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenProvider = jwtTokenProvider;
            _entityMapper = entityMapper;
        }
        public Response<AuthUserOutputDto> LoginUser(AuthUserDto login)
        {
            var response = new Response<AuthUserOutputDto>();
            try
            {
                var user = _unitOfWork.AuthRepository.GetUserByNameOrDefault(login);
                if (user.Result != null)
                {
                    if (EncryptSha256.SamePasswords(user.Result.Password, login.Password))
                    {
                        string token = _jwtTokenProvider.CreateJwtToken(user.Result).Result;

                        response.Data = _entityMapper.UserToAuthUserOutputDto(user.Result, token);
                        response.Succeeded = true;
                        response.Message = "Success!";
                    }
                    else
                    {
                        response.Succeeded = false;
                        response.Message = "Usuario o Contraseña incorrecto.";
                    }
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "El usuario ingresado no existe.";
                }

            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
