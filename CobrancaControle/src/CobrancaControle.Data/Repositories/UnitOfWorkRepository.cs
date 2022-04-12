using CobrancaControle.Data.Context;
using CobrancaControle.Domain.Interfaces.RepositoryInterfaces;
using Core;

namespace CobrancaControle.Data.Repositories
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        private readonly DataContext _context;
        private IChargeRepository _ChargeRepository;
        private IClientRepository _ClientRepository;

        public IChargeRepository ChargeRepository
        {
            get { return _ChargeRepository ??= new ChargeRepository(_context);}
        }
        public IClientRepository ClientRepository
        {
            get { return _ClientRepository ??= new ClientRepository(_context);}
        }
        public UnitOfWork(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}