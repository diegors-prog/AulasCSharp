using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;
using WebApi.Domain.Interfaces.ServiceInterfaces;

namespace WebApi.Services
{
    public class ChargeService : IChargeService
    {
        private readonly IChargeRepository _chargeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChargeService(
            IChargeRepository chargeRepository,
            IUnitOfWork unitOfWork)
        {
            this._chargeRepository = chargeRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> AddChargeAsync(Charge charge)
        {
            _chargeRepository.Save(charge);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> CheckUnpaidClientFessAsync(long customerId)
        {
            var chargeList = await _chargeRepository.GetAllCustomerChargesAsync(customerId);
            List<Charge> unpaidBillsList = new List<Charge>();

            if (chargeList.Count == 0)
                return false;
            else
            {
                foreach (Charge charge in chargeList)
                {
                    if (charge.PaymentStatus.Equals(false))
                        unpaidBillsList.Add(charge);
                }

                if (unpaidBillsList.Count != 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<IList<Charge>> GetAllChargesAsync()
        {
            return await _chargeRepository.GetAllAsync();
        }

        public async Task<Charge> PayChargeAsync(long chargeId)
        {
            var chargePaid = await _chargeRepository.GetByIdAsync(chargeId);

            if (chargePaid == null)
                return null;

            chargePaid.PaymentDate = DateTime.Now;
            chargePaid.PaymentStatus = true;

            _chargeRepository.Update(chargePaid);
            await _unitOfWork.CommitAsync();

            return chargePaid;
        }

        public async Task<bool> RemoveChargeAsync(long chargeId)
        {
            var deleted = _chargeRepository.Delete(chargeId);
            await _unitOfWork.CommitAsync();
            return deleted;
        }

        public async Task<Charge> SearchChargeAsync(long chargeId)
        {
            return await _chargeRepository.GetByIdAsync(chargeId);
        }
    }
}
