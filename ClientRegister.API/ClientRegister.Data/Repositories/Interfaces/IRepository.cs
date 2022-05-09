using ClientRegister.Support.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientRegister.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll(bool listEntity);

        Task<T> GetById(int id);

        Task<T> Add(T entity);

        Task<T> AddAsync(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
