using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.ServiceInterfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
