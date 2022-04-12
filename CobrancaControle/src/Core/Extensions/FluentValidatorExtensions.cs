using System;
using FluentValidation;

namespace Core.Extensions
{
    public static class FluentValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NaoVazio<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage("'{PropertyName}' is required.");
        }

        public static IRuleBuilderOptions<T, TProperty> NaoNulo<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                    .WithMessage("'{PropertyName}' is required.");
        }

        public static IRuleBuilderOptions<T, TProperty> NaoVazioNaoNulo<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder
                .NaoVazio()
                .NaoNulo();
        }

        public static IRuleBuilderOptions<T, string> TamanhoMinimo<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength)
        {
            return ruleBuilder
                .MinimumLength(minimumLength)
                    .WithMessage("The field '{PropertyName}' must contain at least {MinLength} characters.");
        }

        public static IRuleBuilderOptions<T, string> TamanhoMaximo<T>(this IRuleBuilder<T, string> ruleBuilder, int maximumLength)
        {
            return ruleBuilder
                .MaximumLength(maximumLength)
                    .WithMessage("The field '{PropertyName}' must contain a maximum of {MaxLength} characters.");
        }

        public static IRuleBuilderOptions<T, string> TamanhoMinimoMaximo<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength, int maximumLength)
        {
            return ruleBuilder
                .TamanhoMinimo(minimumLength)
                .TamanhoMaximo(maximumLength);
        }

        public static IRuleBuilderOptions<T, TProperty> MaiorQue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .GreaterThan(valueToCompare)
                    .WithMessage("The field '{PropertyName}' must be greater than " + valueToCompare + ".");
        }

        public static IRuleBuilderOptions<T, TProperty> MaiorOuIgualQue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .GreaterThanOrEqualTo(valueToCompare)
                    .WithMessage("The field '{PropertyName}' must be greater than or equal to " + valueToCompare + ".");
        }

        public static IRuleBuilderOptions<T, TProperty> MenorQue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .LessThan(valueToCompare)
                    .WithMessage("The field '{PropertyName}' must be less than " + valueToCompare + ".");
        }

        public static IRuleBuilderOptions<T, TProperty> MenorOuIgualQue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
        {
            return ruleBuilder
                .LessThanOrEqualTo(valueToCompare)
                    .WithMessage("The field '{PropertyName}' must be less than or equal to " + valueToCompare + ".");
        }
    }
}