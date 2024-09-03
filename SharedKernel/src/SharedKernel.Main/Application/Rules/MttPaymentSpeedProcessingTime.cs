using FluentValidation;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Rules
{
    public static partial class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, uint> MttPaymentSpeedProcessingTime<T>(this IRuleBuilder<T, uint> ruleBuilder, uint maxValue = 10)
        {
            var options = ruleBuilder
                .LessThanOrEqualTo(maxValue)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            return options;
        }
    }
}
