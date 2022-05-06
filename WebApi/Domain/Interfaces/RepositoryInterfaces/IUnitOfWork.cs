using System.Threading.Tasks;

namespace WebApi.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IChargeRepository ChargeRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
