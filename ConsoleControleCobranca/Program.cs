using ConsoleControleCobranca.Controllers;
using ConsoleControleCobranca.Data;
using ConsoleControleCobranca.Interfaces;
using ConsoleControleCobranca.Services;

namespace ConsoleControleCobranca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency injection

            IClientRepository clientRepository = new ClientRepository();
            IChargeRepository chargeRepository = new ChargeRepository();

            IClientService clientService = new ClientService(clientRepository);
            clientService.ChargeService = new ChargeService(chargeRepository);

            IChargeService chargeService = new ChargeService(chargeRepository);
            chargeService.ClientService = new ClientService(clientRepository);

            // Program

            ChargeClientController controller = new ChargeClientController(chargeService, clientService);
            controller.Menu();
        }
    }
}
