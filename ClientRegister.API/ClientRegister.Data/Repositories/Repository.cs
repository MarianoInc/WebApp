using ClientRegister.Data.DataContext;
using ClientRegister.Data.Repositories.Interfaces;
using ClientRegister.Support.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRegister.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ClientDbContext _context;
        protected DbSet<T> _entities;

        public Repository(ClientDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<List<T>> GetAll(bool state)
        {
            if(!state) 
                return await _entities.Where(x => x.IsActive == false).ToListAsync();

            return await _entities.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _entities.SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new InvalidOperationException("Entity not found");

            return entity;
        }

        public async Task<T> Add(T entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null || entity.IsActive == false)
                throw new InvalidOperationException("Entity not found");

            entity.IsActive = false;
            _entities.Update(entity);
        }
    }
}
