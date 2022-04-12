using System.Data;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly DbContext _context;

        public BaseUnitOfWork(DbContext context)
        {
            _context = context;
        }
        
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction EFBeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return _context.Database.BeginTransaction(isolationLevel);
        }
    }
}