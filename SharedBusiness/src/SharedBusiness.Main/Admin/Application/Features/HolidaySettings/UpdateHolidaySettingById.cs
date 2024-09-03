using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.HolidaySetting;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.HolidaySettings;

public record UpdateHolidaySettingByIdCommand(
        uint id, uint? country_id, DateTime date, HolidaySettingTypeValues type, string gmt, DateTime? open_at, DateTime? close_at, uint? company_id, HolidaySettingStatusValues status
) : IRequest<ErrorOr<HolidaySetting>>;

public class UpdateHolidaySettingByIdCommandValidator : AbstractValidator<UpdateHolidaySettingByIdCommand>
{
    public UpdateHolidaySettingByIdCommandValidator()
    {
        RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.date).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.type).NotEmpty().IsInEnum();
        RuleFor(r => r.gmt).NotEmpty().MaximumLength(5).MinimumLength(1).WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(x => x.status).NotEmpty().IsInEnum();
    }
}

public class UpdateHolidaySettingByIdCommandHandler : HolidaySettingBase, IRequestHandler<UpdateHolidaySettingByIdCommand, ErrorOr<HolidaySetting>>
{
    private readonly IHolidaySettingRepository _repository;
    private readonly IGuardAgainstNullUpdate _guard;

    public UpdateHolidaySettingByIdCommandHandler(IHolidaySettingRepository repository, IGuardAgainstNullUpdate guard)
    {
        _repository = repository;
        _guard = guard;
    }

    public async Task<ErrorOr<HolidaySetting>> Handle(UpdateHolidaySettingByIdCommand command, CancellationToken cancellationToken)
    {
        HolidaySetting? holidaySetting = await _repository.GetByIdAsync(command.id, cancellationToken);
        if (holidaySetting == null)
        {
            return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
        }
        // Update properties conditionally using the helper function
        _guard.UpdateIfNotNullOrEmpty(value => holidaySetting.CountryId = value, command.country_id);
        holidaySetting.Date = command.date;
        holidaySetting.Type = (byte)command.type; //Full,Half,Quater,Special;
        holidaySetting.Gmt = command.gmt;
        holidaySetting.OpenAt = command.open_at;
        holidaySetting.CloseAt = command.close_at;
        holidaySetting.CompanyId = command.company_id;
        holidaySetting.CreatedById = 0;
        holidaySetting.UpdatedById = 0;
        holidaySetting.Status = (byte)command.status;

        holidaySetting.UpdatedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(holidaySetting, cancellationToken);
        return holidaySetting;
    }

}

