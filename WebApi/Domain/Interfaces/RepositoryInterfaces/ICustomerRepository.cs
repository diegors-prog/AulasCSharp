using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(long customerId);
        Task<IList<Customer>> GetAllAsync();
        void Save(Customer customer);
        bool Delete(long customerId);
        void Update(Customer customer);
    }
}
