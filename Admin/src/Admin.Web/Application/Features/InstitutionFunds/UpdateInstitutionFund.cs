﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class UpdateInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateInstitutionFundUrl, Name = Routes.UpdateInstitutionFundName)]

        public async Task<ActionResult<ErrorOr<InstitutionFund>>> Update(uint Id, UpdateInstitutionFundCommand command)
        {
            var commandWithId = command with { Id = Id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);return Ok(result);
        }

        public record UpdateInstitutionFundCommand(
            uint Id,
            uint InstitutionId,
            uint ProviderId,
            uint FundCountryId,
            uint FundCurrencyId,
            string AccountNumber,
            decimal StartingAmount,
            decimal CurrentAmount,
            uint? CompanyId,
            byte Status) : IRequest<ErrorOr<InstitutionFund>>;

        public class UpdateInstitutionFundCommandValidator : AbstractValidator<UpdateInstitutionFundCommand>
        {
            public UpdateInstitutionFundCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("InstitutionFund ID is required");
                RuleFor(x => x.InstitutionId).NotEmpty().WithMessage("InstitutionId  is required");
                RuleFor(x => x.ProviderId).NotEmpty().WithMessage("ProviderId  is required");
                RuleFor(x => x.FundCountryId).NotEmpty().WithMessage("ProviderId  is required");
                RuleFor(x => x.FundCurrencyId).NotEmpty().WithMessage("FundCurrencyId  is required");
                RuleFor(x => x.AccountNumber).NotEmpty().WithMessage("AccountNumber  is required");
                RuleFor(x => x.StartingAmount).NotEmpty().WithMessage("StartingAmount  is required");
                RuleFor(x => x.CurrentAmount).NotEmpty().WithMessage("CurrentAmount  is required");
                RuleFor(x => x.Status).NotEmpty().WithMessage("Status  is required");
            }
        }

        public class UpdateInstitutionFundCommandHandler : IRequestHandler<UpdateInstitutionFundCommand, ErrorOr<InstitutionFund>>
        {
            private readonly IInstitutionFundRepository _repository;

            public UpdateInstitutionFundCommandHandler(IInstitutionFundRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<InstitutionFund>> Handle(UpdateInstitutionFundCommand command, CancellationToken cancellationToken)
            {
                InstitutionFund? institutionFund = await _repository.GetByIdAsync(command.Id);
                if (institutionFund != null)
                {
                    institutionFund.InstitutionId = command.InstitutionId;
                    institutionFund.ProviderId = command.ProviderId;
                    institutionFund.FundCountryId = command.FundCountryId;
                    institutionFund.FundCurrencyId = command.FundCurrencyId;
                    institutionFund.AccountNumber = command.AccountNumber;
                    institutionFund.StartingAmount = command.StartingAmount;
                    institutionFund.CurrentAmount = command.CurrentAmount;
                    institutionFund.CompanyId = command.CompanyId;
                    institutionFund.Status = command.Status;
                    institutionFund.UpdatedById = command.Id;
                    institutionFund.UpdatedAt = DateTime.UtcNow;
                }

                if (institutionFund == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Institution Fund not found!");
                }

                 await _repository.UpdateAsync(institutionFund,cancellationToken);
                return institutionFund;
            }
        }
    }
}