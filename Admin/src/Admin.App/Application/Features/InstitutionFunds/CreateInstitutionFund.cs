using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class CreateInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        // [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateInstitutionFundUrl, Name = Routes.CreateInstitutionFundName)]

        public async Task<ActionResult<ErrorOr<InstitutionFund>>> Create(CreateInstitutionFundCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
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

    public class CreateInstitutionFundCommandValidator : AbstractValidator<CreateInstitutionFundCommand>
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

    public class CreateInstitutionFundCommandHandler : IRequestHandler<CreateInstitutionFundCommand, ErrorOr<InstitutionFund>>
    {
        private readonly IImtInstitutionFundRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateInstitutionFundCommandHandler(IHttpContextAccessor httpContextAccessor, IImtInstitutionFundRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
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

            if (institutionFund == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return _repository.Add(institutionFund)!;
        }
    }
}
