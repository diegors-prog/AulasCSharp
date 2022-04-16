using System;

namespace ConsoleControleCobranca.Domain
{
    public class Charge
    {
        public Charge(int id, DateTime issuanceDate, DateTime duedate, double amountCharge, Client client)
        {
            this.Id = id;
            this.IssuanceDate = issuanceDate;
            this.DueDate = duedate;
            this.AmountCharge = amountCharge;
            this.PaymentDate = null;
            this.Status = false;
            this.Client = client;
        }

        public int Id { get; set; }
        public DateTime IssuanceDate { get; set; } //Data Emissão
        public DateTime DueDate { get; set; } //DataVencimento
        public double AmountCharge { get; set; } //Valor da cobrança
        public DateTime? PaymentDate { get; set; } //DataPagamento
        public bool Status { get; set; } //Status do pagamento
        public Client Client { get; set; }
    }
}