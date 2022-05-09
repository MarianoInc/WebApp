using ClientRegister.Data.DataContext;
using ClientRegister.Data.Repositories.Interfaces;
using ClientRegister.Support.Entities;
using System;
using System.Threading.Tasks;

namespace ClientRegister.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ClientDbContext _context;
        private readonly IRepository<Client> _ClientsRepository;
        private readonly IRepository<Rol> _rolRepository;
        private readonly IRepository<User> _usersRepository;
        private readonly IAuthRepository _authRepository;

        private bool disposed = false;

        public UnitOfWork(ClientDbContext context)
        {
            _context = context;
        }

        public IRepository<Client> ClientsRepository =>
            _ClientsRepository ?? new Repository<Client>(_context);
        public IRepository<Rol> RolRepository => _rolRepository ?? new Repository<Rol>(_context);
        public IRepository<User> UserRepository => _usersRepository ?? new Repository<User>(_context);
        public IAuthRepository AuthRepository => _authRepository ?? new AuthRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
