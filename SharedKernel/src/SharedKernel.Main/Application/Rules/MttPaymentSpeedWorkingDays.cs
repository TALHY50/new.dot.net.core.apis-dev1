﻿using FluentValidation;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Rules
{
    public static partial class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> MttPaymentSpeedWorkingDays<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength = 255)
        {
            var options = ruleBuilder.MaximumLength(maxLength)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            return options;
        }
    }
}
