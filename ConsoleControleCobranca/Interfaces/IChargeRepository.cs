using System.Collections.Generic;
using ConsoleControleCobranca.Domain;

namespace ConsoleControleCobranca.Interfaces
{
    public interface IChargeRepository
    {
         void Save(Charge charge);
         List<Charge> GetAll();
         Charge GetById(int chargeId);
         void Update(Charge charge);
         void Delete(int chargeId);
         List<Charge> GetAllClientCharges(int clientId);
         int ListSize();
    }
}