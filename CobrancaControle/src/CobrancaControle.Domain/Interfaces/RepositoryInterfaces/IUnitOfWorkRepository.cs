using Core.Interfaces;

namespace CobrancaControle.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
         IChargeRepository ChargeRepository { get; }
         IClientRepository ClientRepository { get; }
    }
}