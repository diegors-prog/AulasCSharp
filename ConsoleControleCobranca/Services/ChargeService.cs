using System.Collections.Generic;
using System.Text;
using System;
using ConsoleControleCobranca.Data;
using ConsoleControleCobranca.Domain;
using ConsoleControleCobranca.Interfaces;

/* Regras de negócio implementadas:
    Para poder adicionar uma nova cobrança é obrigado ter clientes adicionados na base de dados;
    Se a cobrança a ser paga estiver vencida, será acrecentado 10% em cima do valor da cobrança;
    Uma cobrança não pode ser excluída da base de dados, se verificarem o repositório
    de cobranças existe uma função de Delete, mas como não foi implementado uma rotina
    no ChargeService para a exclusão, esta ação está proíbida.
*/

namespace ConsoleControleCobranca.Services
{
    public class ChargeService : IChargeService
    {
        ChargeRepository chargeRepository = new ChargeRepository();
        private IClientService _clientService;
        public IClientService ClientService { get => _clientService; set => _clientService = value; }

        public ChargeService()
        {}

        public string AddCharge(DateTime dueDate, double amountCharge, int clientid)
        {
            int chargeId = chargeRepository.GetAll().Count + 1;
            var client = _clientService.SearchClient(clientid);
            if(client == null)
                return "Cliente não encontrado!";
            else
            {
                chargeRepository.Save(new Charge(chargeId, DateTime.Now, dueDate, amountCharge, client));
                return "Cobranca adicionada com sucesso!";
            }
        }

        public string ShowCharges()
        {
            var builder = new StringBuilder();
            var chargeList = chargeRepository.GetAll();
            var numberOfCharges = chargeList.Count;

            if (numberOfCharges == 0)
                return builder.Append("Lista vazia").ToString();
            else
            {
                foreach (Charge charge in chargeList)
                {
                    builder.AppendLine("Id: " + charge.Id + " Pagamento efetuado: " + charge.Status + " " + charge.PaymentDate + " Cliente: " + charge.Client.Name);
                }

                return builder.ToString();
            }
        }

        public string PayCharge(int chargeId)
        {
            var charge = chargeRepository.GetById(chargeId);

            if (charge == null)
                return "Cobrança não encontrada!";
            
            if (charge.Status == true)
                return "Esta cobrança já está paga!";

            DateTime currentDate = DateTime.Now;

            if (currentDate > charge.DueDate)
            {
                double readjustedAmount = charge.AmountCharge * 1.1;
                charge.AmountCharge = readjustedAmount;

                chargeRepository.Update(charge);
                return "Pagamento efetuado com sucesso na data " + charge.PaymentDate.ToString() + ", com o valor de R$ " + charge.AmountCharge.ToString("0.00");
            }
            else
            {
                chargeRepository.Update(charge);
                return "Pagamento efetuado com sucesso na data " + charge.PaymentDate.ToString() + ", com o valor de R$ " + charge.AmountCharge.ToString("0.00");
            }
        }

        // Função para verificar se existem cobranças sem pagar do
        // cliente a ser removido da base de dados
        public bool CheckUnpaidClientFess(int clientId)
        {
            var clientBillingList = chargeRepository.GetAllClientCharges(clientId);
            List<Charge> unpaidBillsList = new List<Charge>();

            if(clientBillingList.Count == 0)
                return false;
            else
            {
                foreach (Charge charge in clientBillingList)
                {
                    if (charge.Status.Equals(false))
                    {
                        unpaidBillsList.Add(charge);
                    }
                }

                if (unpaidBillsList.Count != 0)
                    return true;
                else
                    return false;
            }
        }
    }
}