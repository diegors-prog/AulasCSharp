using CobrancaControle.Data.Context;
using CobrancaControle.Domain.Entities;
using CobrancaControle.Domain.Interfaces.RepositoryInterfaces;
using Core;

namespace CobrancaControle.Data.Repositories
{
    public class ChargeRepository : BaseRepository<Charge, DataContext>, IChargeRepository
    {
        private readonly DataContext Context;

        public ChargeRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}