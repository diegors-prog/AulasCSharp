using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;

namespace WebApi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext Context;

        public CustomerRepository(DataContext context)
        {
            this.Context = context;
        }


        public async Task<IList<Customer>> GetAllAsync()
        {
            return await Context.DbSetCustomer.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(long customerId)
        {
            return await Context.DbSetCustomer
                .Include(i => i.Charges)
                .FirstOrDefaultAsync(i => i.Id == customerId);
        }

        public async Task<Customer> GetByCustomerAndChargesAsync(long customerId)
        {
            return await Context.DbSetCustomer
                .Include(i => i.Charges)
                .FirstOrDefaultAsync(i => i.Id == customerId);
        }

        public void Save(Customer customer)
        {
            Context.DbSetCustomer.Add(customer);
        }

        public void Update(Customer customer)
        {
            Context.Entry(customer).State = EntityState.Modified;
        }

        public bool Delete(long customerId)
        {
            var customer = Context.DbSetCustomer.FirstOrDefault(i => i.Id == customerId);

            if (customer == null)
                return false;
            else
            {
                Context.DbSetCustomer.Remove(customer);
                return true;
            }
        }
    }
}
