using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;

namespace WebApi.Data.Repositories
{
    public class ChargeRepository : IChargeRepository
    {
        private readonly DataContext Context;

        public ChargeRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<Charge>> GetAllAsync()
        {
            return await Context.DbSetCharge.
                Include(i => i.Customer)
                .ToListAsync();
        }

        public async Task<IList<Charge>> GetAllCustomerChargesAsync(long customerId)
        {
            var customerChargeList = await Context.DbSetCharge
                .Where(i => i.CustomerId == customerId)
                .ToListAsync();

            return customerChargeList;
        }

        public async Task<Charge> GetByIdAsync(long chargeId)
        {
            return await Context.DbSetCharge
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(i => i.Id == chargeId);
        }

        public void Save(Charge charge)
        {
            Context.Add(charge);
        }

        public void Update(Charge charge)
        {
            Context.Entry(charge).State = EntityState.Modified;
        }

        public bool Delete(long chargeId)
        {
            var charge = Context.DbSetCharge.FirstOrDefault(i => i.Id == chargeId);

            if (charge == null)
                return false;
            else
            {
                Context.DbSetCharge.Remove(charge);
                return true;
            }
        }
    }
}
