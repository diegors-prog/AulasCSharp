using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;
using WebApi.Domain.Interfaces.ServiceInterfaces;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            _userRepository.Save(user);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<User> SearchUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
