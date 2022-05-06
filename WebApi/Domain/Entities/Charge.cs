using System;
using WebApi.Domain.Enums;

namespace WebApi.Domain.Entities
{
    public class Charge
    {
        public long Id { get; set; }
        public DateTime IssuanceDate { get; set; } //Data Emissão
        public DateTime DueDate { get; set; } //Data Vencimento
        public DateTime? PaymentDate { get; set; } //Data Pagamento
        public bool PaymentStatus { get; set; } //Status do Pagamento
        public double AmountCharge { get; set; } //Valor da cobrança
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
    }
}
