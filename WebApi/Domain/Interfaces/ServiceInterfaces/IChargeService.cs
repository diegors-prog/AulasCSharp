using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.ServiceInterfaces
{
    public interface IChargeService
    {
        Task<bool> AddChargeAsync(Charge charge);
        Task<IList<Charge>> GetAllChargesAsync();
        Task<Charge> SearchChargeAsync(long chargeId);
        Task<Charge> PayChargeAsync(long chargeId);
        Task<bool> CheckUnpaidClientFessAsync(long clientId);
        Task<bool> RemoveChargeAsync(long chargeId);
    }
}
