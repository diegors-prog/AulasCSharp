using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<bool> AddCustomerAsync(Customer customer);
        Task<IList<Customer>> GetAllCustomersAsync();
        Task<Customer> SearchCustomerAsync(long customerId);
        Task<bool> EditCustomer(Customer customer);
        Task<bool> RemoveCustomerAsync(long chargeId);
    }
}
