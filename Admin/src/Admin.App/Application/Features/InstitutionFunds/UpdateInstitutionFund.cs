using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

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
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
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

        internal sealed class UpdateInstitutionFundCommandValidator : AbstractValidator<UpdateInstitutionFundCommand>
        {
            public UpdateInstitutionFundCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("InstitutionFund ID is required");
            }
        }

        internal sealed class UpdateInstitutionFundCommandHandler : IRequestHandler<UpdateInstitutionFundCommand, ErrorOr<InstitutionFund>>
        {
            private readonly IImtInstitutionFundRepository _repository;

            public UpdateInstitutionFundCommandHandler(IImtInstitutionFundRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<InstitutionFund>> Handle(UpdateInstitutionFundCommand command, CancellationToken cancellationToken)
            {
                InstitutionFund? institutionFund = _repository.GetByUintId(command.Id);
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

                    //if (_user?.UserId != null)
                    //{
                    //    entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
                    //}
                    //else
                    //{
                    //    entity.UpdatedById = 1;
                    //}
                }

                return await _repository.UpdateAsync(institutionFund);
            }
        }
    }
}
