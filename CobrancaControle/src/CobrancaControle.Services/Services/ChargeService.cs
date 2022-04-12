using CobrancaControle.Domain.Entities;
using CobrancaControle.Domain.Interfaces.RepositoryInterfaces;
using CobrancaControle.Domain.Interfaces.ServiceInterfaces;
using Core;

namespace CobrancaControle.Services.Services
{
    public class ChargeService : BaseService<Charge>, IChargeService
    {
        private readonly IChargeRepository ChargeRepository;

        public ChargeService(
            IUnitOfWork unitOfWork,
            IChargeRepository chargeRepository) : base(unitOfWork.ChargeRepository)
        {
            this.ChargeRepository = chargeRepository;
        }
    }
}