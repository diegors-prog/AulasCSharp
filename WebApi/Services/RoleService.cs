using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;
using WebApi.Domain.Interfaces.ServiceInterfaces;

namespace WebApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork)
        {
            this._roleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> AddRoleAsync(Role role)
        {
            _roleRepository.Save(role);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
