using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Interfaces
{
    public interface IBaseUnitOfWork
    {
        Task Commit();
        IDbContextTransaction EFBeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}