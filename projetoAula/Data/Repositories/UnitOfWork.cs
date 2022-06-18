using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _Context;

        public UnitOfWork(DataContext context)
        {
            this._Context = context;
        }

        public async Task CommitAsync()
        {
            await _Context.SaveChangesAsync();
        }

        private IUserRepository _UserRepository;

        public IUserRepository UserRepository
        {
            get { return _UserRepository ??= new UserRepository(_Context);}
        }
    }
}