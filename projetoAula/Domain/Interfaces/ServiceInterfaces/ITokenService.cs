using Domain.Entities;

namespace Domain.Interfaces.ServiceInterfaces
{
    public interface ITokenService
    {
         string GenerateToken(User user);
    }
}