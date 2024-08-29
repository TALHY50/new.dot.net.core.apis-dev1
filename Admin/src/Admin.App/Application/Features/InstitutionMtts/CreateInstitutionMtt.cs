using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common;
using SharedBusiness.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.InstitutionMtts
{
    public class CreateInstitutionMttController : ApiControllerBase
    {
        [Tags("InstitutionMtt")]
        //[Authorize]
        [HttpPost(Routes.CreateInstitutionMttUrl, Name = Routes.CreateInstitutionMttName)]
        public async Task<ActionResult<ErrorOr<InstitutionMtt>>> Create(CreateInstitutionMttCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateInstitutionMttCommand(
        uint InstitutionId,
        uint MttId,
        byte CommissionType,
        uint? CommissionCurrencyId,
        decimal CommissionPercentage,
        decimal CommissionFixed,
        uint? CompanyId,
        byte Status = 1) : IRequest<ErrorOr<InstitutionMtt>>;

    public class CreateInstitutionMttCommandValidator : AbstractValidator<CreateInstitutionMttCommand>
    {
        public CreateInstitutionMttCommandValidator()
        {
            RuleFor(x => x.InstitutionId).NotEmpty().WithMessage("InstitutionId is required");
            RuleFor(x => x.MttId).NotEmpty().WithMessage("MttId is required");
            RuleFor(x => x.CommissionType).NotEmpty().WithMessage("CommissionType is required");
            RuleFor(x => x.CommissionCurrencyId).NotEmpty().WithMessage("CommissionCurrencyId cannot be empty");
            RuleFor(x => x.CommissionPercentage).NotEmpty().WithMessage("CommissionPercentage is required");
            RuleFor(x => x.CommissionFixed).NotEmpty().WithMessage("CommissionFixed is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("CompanyId cannot be empty");
        }
    }

    public class CreateInstitutionMttCommandHandler
        : IRequestHandler<CreateInstitutionMttCommand, ErrorOr<InstitutionMtt>>
    {
        private readonly IImtInstitutionMttRepository _repository;
        public CreateInstitutionMttCommandHandler(IImtInstitutionMttRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<InstitutionMtt>> Handle(CreateInstitutionMttCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @InstitutionMtt = new InstitutionMtt
            {
                InstitutionId = request.InstitutionId,
                MttId = request.MttId,
                CommissionType = request.CommissionType,
                CommissionCurrencyId = request.CommissionCurrencyId,
                CommissionPercentage = request.CommissionPercentage,
                CommissionFixed = request.CommissionFixed,
                CompanyId = request.CompanyId,
                Status = request.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };
            return _repository.Add(@InstitutionMtt);
        }
    }
}
