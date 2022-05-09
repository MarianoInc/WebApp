using ClientRegister.Support.Entities;
using System.Threading.Tasks;

namespace ClientRegister.API.Core.Interfaces
{
    public interface IRoleBusiness
    {
        public Task<Rol> GetRol(int id);
    }
}
