using System;
using System.Collections.Generic;
using ConsoleControleCobranca.Domain;
using ConsoleControleCobranca.Interfaces;

namespace ConsoleControleCobranca.Data
{
    public class ChargeRepository : IChargeRepository
    {
        private List<Charge> billingList = new List<Charge>();

        public void Save(Charge charge)
        {
            billingList.Add(charge);
        }

        public List<Charge> GetAll()
        {
            return billingList;
        }

        public Charge GetById(int chargeId)
        {
            var charge = billingList.Find(i => i.Id == chargeId);
            return charge;
        }

        public void Update(Charge charge)
        { 
            charge.PaymentDate = DateTime.Now;
            charge.Status = true;
        }

        public void Delete(int chargeId)
        {
            var charge = billingList.Find(i => i.Id == chargeId);
            billingList.Remove(charge);
        }

        public List<Charge> GetAllClientCharges(int clientId)
        {
            var clientCharges = billingList.FindAll(i => i.Client.Id == clientId);
            return clientCharges;
        }

        public int ListSize()
        {
            return billingList.Count;
        }
    }
}