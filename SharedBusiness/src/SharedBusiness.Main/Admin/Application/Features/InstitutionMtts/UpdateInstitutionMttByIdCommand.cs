
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionMtts
{
    public record UpdateInstitutionMttByIdCommand(
        uint id,
        uint InstitutionId,
        uint MttId,
        byte CommissionType,
        uint? CommissionCurrencyId,
        decimal CommissionPercentage,
        decimal CommissionFixed,
        uint? CompanyId,
        StatusValues Status) : IRequest<ErrorOr<InstitutionMtt>>;

    public class UpdateInstitutionMttByIdCommandValidator : AbstractValidator<UpdateInstitutionMttByIdCommand>
    {
        public UpdateInstitutionMttByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.InstitutionId).NotEmpty().WithMessage("InstitutionId is required");
            RuleFor(x => x.MttId).NotEmpty().WithMessage("MttId is required");
            RuleFor(x => x.CommissionType).NotEmpty().WithMessage("CommissionType is required");
            RuleFor(x => x.CommissionCurrencyId).NotEmpty().WithMessage("CommissionCurrencyId cannot be empty");
            RuleFor(x => x.CommissionPercentage).NotEmpty().WithMessage("CommissionPercentage is required");
            RuleFor(x => x.CommissionFixed).NotEmpty().WithMessage("CommissionFixed is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
            RuleFor(x => x.CompanyId).NotEmpty().CompanyIdRule();
        }
    }

    public class UpdateInstitutionMttByIdCommandHandler : InstitutionMttBase, IRequestHandler<UpdateInstitutionMttByIdCommand, ErrorOr<InstitutionMtt>>
    {
        private readonly IInstitutionMttRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateInstitutionMttByIdCommandHandler(IInstitutionMttRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<InstitutionMtt>> Handle(UpdateInstitutionMttByIdCommand command, CancellationToken cancellationToken)
        {
            InstitutionMtt? institutionMtt = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (institutionMtt == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.InstitutionId = value, command.InstitutionId);
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.MttId = value, command.MttId);
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.CommissionType = value, command.CommissionType);
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.CommissionCurrencyId = value, command.CommissionCurrencyId);
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.CommissionPercentage = value, command.CommissionPercentage);
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.CommissionFixed = value, command.CommissionFixed);
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.CompanyId = value, command.CompanyId);
            _guard.UpdateIfNotNullOrEmpty(value => institutionMtt.Status = value, (byte) command.Status);

            institutionMtt.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(institutionMtt, cancellationToken);

            return institutionMtt;


        }

    }
}
