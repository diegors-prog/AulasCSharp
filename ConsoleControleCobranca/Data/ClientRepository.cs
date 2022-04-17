using System.Collections.Generic;
using ConsoleControleCobranca.Domain;
using ConsoleControleCobranca.Interfaces;

namespace ConsoleControleCobranca.Data
{
    public class ClientRepository : IClientRepository
    {
        private List<Client> clientList = new List<Client>();

        public void Save(Client client)
        {
            clientList.Add(client);
        }

        public List<Client> GetAll()
        {
            return clientList;
        }

        public Client GetById(int clientId)
        {
            var client = clientList.Find(x => x.Id == clientId);
            return client;
        }

        public bool Update(Client client)
        {

            var editClient = clientList.Find(x => x.Id == client.Id);
            if (editClient == null)
            {
                return false;
            }
            else
            {
                editClient.Name = client.Name;
                editClient.PhoneNumber = client.PhoneNumber;
                return true;
            }
        }
        
        public bool Delete(int clientId)
        {
            var client = clientList.Find(i => i.Id == clientId);
            if (client == null)
            {
                return false;
            }
            else
            {
                clientList.Remove(client);
                return true;
            }
        }

        public int ListSize()
        {
            return clientList.Count;
        }
    }
}