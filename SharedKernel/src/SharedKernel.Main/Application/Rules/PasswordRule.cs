using FluentValidation;
using SharedKernel.Main.Contracts.Common;

namespace SharedKernel.Main.Application.Rules;

public static partial class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 14)
    {
        var options = ruleBuilder
            .NotEmpty()
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString())
            .MinimumLength(minimumLength)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString())
            .Matches("[A-Z]")
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString())
            .Matches("[a-z]")
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString())
            .Matches("[0-9]")
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString())
            .Matches("[^a-zA-Z0-9]")
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        return options;
    }

}