using FluentValidation;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Rules
{
    public static partial class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string?> TransactionTypeName<T>(this IRuleBuilder<T, string?> ruleBuilder, int maxLength = 50)
        {
            var options = ruleBuilder.MaximumLength(maxLength)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            return options;
        }
    }
}
