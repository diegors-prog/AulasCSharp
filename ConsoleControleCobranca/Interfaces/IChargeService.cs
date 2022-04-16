using System;

namespace ConsoleControleCobranca.Interfaces
{
    public interface IChargeService
    {
         IClientService ClientService {get; set;}
         string AddCharge(DateTime dueDate, double amountCharge, int clientId);
         string ShowCharges();
         string PayCharge(int chargeId);
         bool CheckUnpaidClientFess(int clientId);
    }
}