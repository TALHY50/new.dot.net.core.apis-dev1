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
        public static IRuleBuilder<T, bool> IsProcessingDuringBankingHolidayRule<T>(this IRuleBuilder<T, bool> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .WithMessage("Is Processing During Banking Holiday must be valid.")
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            return options;
        }

    }
}
