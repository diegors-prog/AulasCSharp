using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.RepositoryInterfaces
{
    public interface IChargeRepository
    {
        Task<Charge> GetByIdAsync(long chargeId);
        Task<IList<Charge>> GetAllAsync();
        Task<IList<Charge>> GetAllCustomerChargesAsync(long customerId);
        void Save(Charge charge);
        bool Delete(long chargeId);
        void Update(Charge charge);
    }
}
