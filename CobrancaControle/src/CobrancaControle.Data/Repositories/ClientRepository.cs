using CobrancaControle.Data.Context;
using CobrancaControle.Domain.Entities;
using CobrancaControle.Domain.Interfaces.RepositoryInterfaces;
using Core;

namespace CobrancaControle.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client, DataContext>, IClientRepository
    {
        private readonly DataContext Context;

        public ClientRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}