using ConsoleControleCobranca.Domain;

namespace ConsoleControleCobranca.Interfaces
{
    public interface IClientService
    {
         IChargeService ChargeService {get; set;}
         string AddClient(string clientName, string phoneNumber);
         string ShowClients();
         string EditClient(int clientId, string clientName, string phoneNumber);
         Client SearchClient(int clientId);
    }
}