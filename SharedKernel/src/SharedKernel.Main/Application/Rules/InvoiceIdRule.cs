using FluentValidation;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Rules;

public static partial class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string> InvoiceId<T>(this IRuleBuilder<T, string> ruleBuilder, int maximumLength = 50)
    {
        var options = ruleBuilder
            .NotEmpty()
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString())
            .MaximumLength(maximumLength)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        return options;
    }

}