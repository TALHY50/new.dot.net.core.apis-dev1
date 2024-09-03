﻿using FluentValidation;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Rules
{
    public static partial class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, uint?> CorridorIdRule<T>(this IRuleBuilder<T, uint?> ruleBuilder)
        {
            var options = ruleBuilder.NotEmpty().WithMessage("Corridor Id must be valid!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            return options;
        }

    }
}
