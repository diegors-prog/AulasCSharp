using System.Collections.Generic;
using ConsoleControleCobranca.Domain;

namespace ConsoleControleCobranca.Interfaces
{
    public interface IClientRepository
    {
         void Save(Client client);
         List<Client> GetAll();
         Client GetById(int clientId);
         bool Update(Client client);
         bool Delete(int clientId);
         int ListSize();
    }
}