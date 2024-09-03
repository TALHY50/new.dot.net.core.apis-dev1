using FluentValidation;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Application.Rules
{
    public static partial class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, uint?> TaxCurrencyId<T>(this IRuleBuilder<T, uint?> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .WithMessage("Tax Currency Id must be valid.")
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            return options;
        }

    }
}
