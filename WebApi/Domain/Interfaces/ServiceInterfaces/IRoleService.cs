using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.ServiceInterfaces
{
    public interface IRoleService
    {
        Task<bool> AddRoleAsync(Role role);
    }
}
