using System;
using System.Threading.Tasks;
using WebApi.Data.Context;
using WebApi.Domain.Interfaces.RepositoryInterfaces;

namespace WebApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
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

        public void Dispose()
        {
            _context.Dispose();
        }

        private IChargeRepository _ChargeRepository;
        private ICustomerRepository _CustomerRepository;
        private IUserRepository _UserRepository;
        private IRoleRepository _RoleRepository;


        public IChargeRepository ChargeRepository
        {
            get { return _ChargeRepository ??= new ChargeRepository(_context); }
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _CustomerRepository ??= new CustomerRepository(_context); }
        }

        public IUserRepository UserRepository
        {
            get { return _UserRepository ??= new UserRepository(_context); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _RoleRepository ??= new RoleRepository(_context); }
        }
    }
}
