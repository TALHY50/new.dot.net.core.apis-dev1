using FluentValidation;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Rules;

public static partial class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string?> IsoCountryCode<T>(this IRuleBuilder<T, string?> ruleBuilder,  int fixedLength = 3)
    {
        var options = ruleBuilder.Length(fixedLength)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        return options;
    }

}