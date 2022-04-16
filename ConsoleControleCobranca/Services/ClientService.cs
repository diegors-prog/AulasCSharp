using System.Text;
using ConsoleControleCobranca.Data;
using ConsoleControleCobranca.Domain;
using ConsoleControleCobranca.Interfaces;

namespace ConsoleControleCobranca.Services
{
    public class ClientService : IClientService
    {
        IClientRepository clientRepository = new ClientRepository();
        private IChargeService _ChargeService;
        public IChargeService ChargeService { get => _ChargeService; set => _ChargeService = value; }

        public ClientService()
        {}

        public string AddClient(string clientName, string phoneNumber)
        {
            int clientId = clientRepository.ListSize() + 1;
            clientRepository.Save(new Client(clientId, clientName, phoneNumber));
            return "Cliente adicionado com sucesso!";
        }

        public string ShowClients()
        {
            var builder = new StringBuilder();
            var clientList = clientRepository.GetAll();
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

            if (clientRepository.ListSize().Equals(0))
            {
                presentation = "Lista vazia";
                return presentation;
            }
            else
            {
                var wasEdited = clientRepository.Update(new Client(clientId, clientName, phoneNumber));

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

            if (clientRepository.ListSize().Equals(0))
            {
                presentation = "Lista vazia";
            }
            else
            {
                var thereAreUnpaidCharges = ChargeService.CheckUnpaidClientFess(clientId);

                if (thereAreUnpaidCharges.Equals(false))
                {
                    var wasRemoved = clientRepository.Delete(clientId);
                    
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

        public Client SearchClient(int clientId)
        {
            var client = clientRepository.GetById(clientId);
            return client;
        }
    }
}