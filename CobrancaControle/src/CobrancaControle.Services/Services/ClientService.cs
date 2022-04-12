using CobrancaControle.Domain.Entities;
using CobrancaControle.Domain.Interfaces.RepositoryInterfaces;
using CobrancaControle.Domain.Interfaces.ServiceInterfaces;
using Core;

namespace CobrancaControle.Services.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IClientRepository ClientRepository;

        public ClientService(
            IUnitOfWork unitOfWork,
            IClientRepository clientRepository) : base(unitOfWork.ClientRepository)
        {
            this.ClientRepository = clientRepository;
        }
    }
}