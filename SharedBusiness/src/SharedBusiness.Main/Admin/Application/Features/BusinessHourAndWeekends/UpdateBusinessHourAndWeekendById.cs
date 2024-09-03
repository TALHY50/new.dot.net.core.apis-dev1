using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Weblication.Features.BusinessHourAndWeekends;

public record UpdateBusinessHoursAndWeekendByIdCommand(
    uint id, byte HourType, uint? CountryId,
    string Day, sbyte IsWeekend, string Gmt, DateTime OpenAt, DateTime CloseAt, uint? CompanyId, byte Status
    ) : IRequest<ErrorOr<BusinessHoursAndWeekend>>;

public class UpdateBusinessHoursAndWeekendByIdCommandValidator : AbstractValidator<UpdateBusinessHoursAndWeekendByIdCommand>
{
    public UpdateBusinessHoursAndWeekendByIdCommandValidator()
    {
        RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.HourType).Must(value => value == 0 || value == 1).WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.Day).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.IsWeekend).Must(value => value == 0 || value == 1).WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.Gmt).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.OpenAt).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.CloseAt).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class UpdateBusinessHoursAndWeekendByIdCommandHandler : BusinessHourAndWeekendBase, IRequestHandler<UpdateBusinessHoursAndWeekendByIdCommand, ErrorOr<BusinessHoursAndWeekend>>
{
    private readonly IBusinessHourAndWeekendRepository _repository;
    private readonly IGuardAgainstNullUpdate _guard;

    public UpdateBusinessHoursAndWeekendByIdCommandHandler(IBusinessHourAndWeekendRepository repository, IGuardAgainstNullUpdate guard)
    {
        _repository = repository;
        _guard = guard;
    }

    public async Task<ErrorOr<BusinessHoursAndWeekend>> Handle(UpdateBusinessHoursAndWeekendByIdCommand command, CancellationToken cancellationToken)
    {
        BusinessHoursAndWeekend? businessHoursAndWeekend = await _repository.GetByIdAsync(command.id, cancellationToken);
        if (businessHoursAndWeekend == null)
        {
            return Error.NotFound(description: Language.GetMessage("Record not found"),
                code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
        }
        // Update properties conditionally using the helper function
        businessHoursAndWeekend.HourType = command.HourType;
        _guard.UpdateIfNotNullOrEmpty(value => businessHoursAndWeekend.Day = value, command.Day);
        businessHoursAndWeekend.IsWeekend = command.IsWeekend;
        _guard.UpdateIfNotNullOrEmpty(value => businessHoursAndWeekend.Gmt = value, command.Gmt);
        businessHoursAndWeekend.OpenAt = command.OpenAt;
        businessHoursAndWeekend.CloseAt = command.CloseAt;
        businessHoursAndWeekend.UpdatedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(businessHoursAndWeekend, cancellationToken);
        return businessHoursAndWeekend;
    }

}

