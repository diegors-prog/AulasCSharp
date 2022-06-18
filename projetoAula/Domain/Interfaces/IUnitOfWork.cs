namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
         Task CommitAsync();

         IUserRepository UserRepository {get;}
         IRoleRepository RoleRepository {get;}
    }
}