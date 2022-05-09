using ClientRegister.API.Core.Interfaces;
using ClientRegister.Data.Repositories.Interfaces;
using ClientRegister.Support.Entities;
using System;
using System.Threading.Tasks;

namespace ClientRegister.API.Core.Business
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Rol> GetRol(int id)
        { 
            var rol = _unitOfWork.RolRepository.GetById(id);
            if (rol.Result != null)
            {
                return rol;
            }
            throw new Exception("Rol null");
        }
    }
}
