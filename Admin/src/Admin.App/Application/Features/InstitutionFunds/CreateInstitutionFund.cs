using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class CreateInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        // [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateInstitutionFundUrl, Name = Routes.CreateInstitutionFundName)]

        public async Task<ActionResult<ErrorOr<InstitutionFund>>> Create(CreateInstitutionFundCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
    public record CreateInstitutionFundCommand(
        uint InstitutionId,
        uint ProviderId,
        uint FundCountryId,
        uint FundCurrencyId,
        string AccountNumber,
        decimal StartingAmount,
        decimal CurrentAmount,
        uint? CompanyId,
        byte Status
        ) : IRequest<ErrorOr<InstitutionFund>>;

    internal sealed class CreateInstitutionFundCommandValidator : AbstractValidator<CreateInstitutionFundCommand>
    {
        public CreateInstitutionFundCommandValidator()
        {
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

    internal sealed class CreateInstitutionFundCommandHandler : IRequestHandler<CreateInstitutionFundCommand, ErrorOr<InstitutionFund>>
    {
        private readonly IImtInstitutionFundRepository _repository;

        public CreateInstitutionFundCommandHandler(IImtInstitutionFundRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<InstitutionFund>> Handle(CreateInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            var institutionFund = new InstitutionFund
            {
                InstitutionId = command.InstitutionId,
                ProviderId = command.ProviderId,
                FundCountryId = command.FundCountryId,
                FundCurrencyId = command.FundCurrencyId,
                AccountNumber = command.AccountNumber,
                StartingAmount = command.StartingAmount,
                CurrentAmount = command.CurrentAmount,
                CompanyId = 0,
                Status = 1, // 0=inactive, 1=active, 2=pending, 3=rejected 
                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return await _repository.AddAsync(institutionFund);
        }
    }
}
