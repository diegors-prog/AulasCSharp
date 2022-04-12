using Core.Extensions;
using FluentValidation;

namespace CobrancaControle.Domain.Entities
{
    public class ChargeValidator : AbstractValidator<Charge>
    {
        public ChargeValidator()
        {
            RuleFor(i => i.ClientId).NaoVazioNaoNulo();
        }
    }
}