using ConsoleControleCobranca.Domain;

namespace ConsoleControleCobranca.Interfaces
{
    public interface IClientService
    {
         IChargeService ChargeService {get; set;}
         string AddClient(string clientName, string phoneNumber);
         string ShowClients();
         string EditClient(int clientId, string clientName, string phoneNumber);
         string RemoveClient(int clientId);
         Client SearchClient(int clientId);
    }
}