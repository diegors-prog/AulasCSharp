using System.Text;
using ConsoleControleCobranca.Domain;
using ConsoleControleCobranca.Interfaces;

/* Regras de negócio implementadas:
    Basicamente o CRUD normal, só que para remover um cliente, ele não deve ter
    nenhuma cobrança vinculada, ou se tiver cobranças vinculadas, elas devem estar pagas.
*/

namespace ConsoleControleCobranca.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private IChargeService _chargeService;
        public IChargeService ChargeService { get => _chargeService; set => _chargeService = value; }

        public ClientService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public string AddClient(string clientName, string phoneNumber)
        {
            int clientId = _clientRepository.ListSize() + 1;
            _clientRepository.Save(new Client(clientId, clientName, phoneNumber));
            return "Cliente adicionado com sucesso!";
        }

        public string ShowClients()
        {
            var builder = new StringBuilder();
            var clientList = _clientRepository.GetAll();
            var numberOfClients = clientList.Count;

            if (numberOfClients == 0)
                return builder.Append("Lista vazia").ToString();
            else
            {
                foreach (Client client in clientList)
                {
                    builder.AppendLine("Id: " + client.Id + " Nome: " + client.Name + " Telefone: " + client.PhoneNumber);
                }

                return builder.ToString();
            }
        }

        public string EditClient(int clientId, string clientName, string phoneNumber)
        {
            string presentation = string.Empty;

            if (_clientRepository.ListSize().Equals(0))
            {
                presentation = "Lista vazia";
                return presentation;
            }
            else
            {
                var wasEdited = _clientRepository.Update(new Client(clientId, clientName, phoneNumber));

                if (wasEdited)
                    presentation = "Cliente editado com sucesso!";
                else
                    presentation = "Não foi possível editar";
                
                return presentation;
            }
        }

        public string RemoveClient(int clientId)
        {
            string presentation = string.Empty;

            if (_clientRepository.ListSize().Equals(0))
            {
                presentation = "Lista vazia";
            }
            else
            {
                var thereAreUnpaidCharges = _chargeService.CheckUnpaidClientFess(clientId);

                if (thereAreUnpaidCharges.Equals(false))
                {
                    var wasRemoved = _clientRepository.Delete(clientId);
                    
                    if (wasRemoved.Equals(true))
                        presentation = "Cliente deletado com sucesso!";
                    else
                        presentation = "Cliente não encontrado na base de dados";
                }
                else
                    presentation = "Existem cobrancas sem pagar no nome deste cliente, para poder deletar é necessário efetuar o pagamento das contas pendentes!";
            }
            return presentation;
        }

        // Função para buscar um cliente específico na base de dados,
        // para ser incluído na cobrança que está sendo criada
        public Client SearchClient(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            return client;
        }
    }
}