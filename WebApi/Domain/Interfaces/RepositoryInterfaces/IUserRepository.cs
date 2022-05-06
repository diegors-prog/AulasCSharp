using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(long userId);
        Task<User> GetByEmailAsync(string email);
        Task<IList<User>> GetAllAsync();
        void Save(User user);
        bool Delete(long userId);
        void Update(User user);
    }
}
