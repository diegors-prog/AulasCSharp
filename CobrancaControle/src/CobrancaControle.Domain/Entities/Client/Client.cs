using Core.Interfaces;
using FluentValidation;

namespace CobrancaControle.Domain.Entities
{
    public class Client : IBaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public void IsValid() => new ClientValidator().ValidateAndThrow(this);
    }
}