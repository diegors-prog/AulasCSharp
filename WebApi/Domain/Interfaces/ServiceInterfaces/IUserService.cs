using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User user);
        Task<User> SearchUserByEmailAsync(string email);
    }
}
