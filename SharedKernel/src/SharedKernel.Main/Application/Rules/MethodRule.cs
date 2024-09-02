using FluentValidation;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Rules
{
    public static partial class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, byte> MethodRule<T>(this IRuleBuilder<T, byte> ruleBuilder)
        {
            var options = ruleBuilder.NotEmpty().WithMessage("Method must be valid!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            return options;
        }

    }
}
