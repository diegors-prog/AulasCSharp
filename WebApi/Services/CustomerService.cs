using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;
using WebApi.Domain.Interfaces.ServiceInterfaces;

namespace WebApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IChargeService _chargeService;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(
            ICustomerRepository customerRepository,
            IChargeService chargeService,
            IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._chargeService = chargeService;
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            _customerRepository.Save(customer);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> EditCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<bool> RemoveCustomerAsync(long customerId)
        {
            //var customer = await _customerRepository.GetByIdAsync(customerId);

            var thereAreUnpaidCharges = await _chargeService.CheckUnpaidClientFessAsync(customerId);

            if (thereAreUnpaidCharges.Equals(true))
                return false;
            else
            {
                var deleted = _customerRepository.Delete(customerId);
                await _unitOfWork.CommitAsync();
                return deleted;
            }
        }

        public async Task<Customer> SearchCustomerAsync(long customerId)
        {
            return await _customerRepository.GetByIdAsync(customerId);
        }

        private bool CheckUnpaidClientFessAsync(IList<Charge> chargeList)
        {
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
    }
}
