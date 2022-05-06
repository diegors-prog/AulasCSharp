using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.RepositoryInterfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(long roleId);
        Task<IList<Role>> GetAllAsync();
        void Save(Role role);
        bool Delete(long roleId);
        void Update(Role role);
    }
}
