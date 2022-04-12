using System;
using ControleCobrancas.Domain.Enums;
using Core.Interfaces;
using FluentValidation;

namespace CobrancaControle.Domain.Entities
{
    public class Charge : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime IssuanceDate { get; set; } //Data Emissão
        public DateTime DueDate { get; set; } //Data Vencimento
        public DateTime PaymentDate { get; set; } //Data Pagamento
        public PaymentTypeEnum PaymentStatus { get; set; } //Status do Pagamento
        public double ChargeAmount { get; set; } //Valor da cobrança
        public Client Client { get; set; }
        public int ClientId { get; set; }

        public void IsValid() => new ChargeValidator().ValidateAndThrow(this);
    }
}