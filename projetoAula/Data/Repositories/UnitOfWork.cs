using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IUserRepository _UserRepository;
        private IRoleRepository _RoleRepository;

        public IUserRepository UserRepository
        {
            get { return _UserRepository ??= new UserRepository(_context);}
        }

        public IRoleRepository RoleRepository
        {
            get { return _RoleRepository ??= new RoleRepository(_context);}
        }
    }
}