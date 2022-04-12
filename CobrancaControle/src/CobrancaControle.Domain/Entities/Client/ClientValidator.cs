using Core.Extensions;
using FluentValidation;

namespace CobrancaControle.Domain.Entities
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(i => i.Name).NaoVazioNaoNulo();
        }
    }
}