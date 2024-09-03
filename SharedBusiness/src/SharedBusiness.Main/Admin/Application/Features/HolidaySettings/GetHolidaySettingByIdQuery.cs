using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.HolidaySetting;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.HolidaySettings;

public record GetHolidaySettingByIdQuery(uint id) : IRequest<ErrorOr<HolidaySetting>>;

public class GetHolidaySettingByIdQueryValidator : AbstractValidator<GetHolidaySettingByIdQuery>
{
    public GetHolidaySettingByIdQueryValidator()
    {
        RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class GetHolidaySettingByIdQueryHandler : HolidaySettingBase, IRequestHandler<GetHolidaySettingByIdQuery, ErrorOr<HolidaySetting>>
{
    private readonly IHolidaySettingRepository _repository;

    public GetHolidaySettingByIdQueryHandler(IHolidaySettingRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<HolidaySetting>> Handle(GetHolidaySettingByIdQuery request, CancellationToken cancellationToken)
    {
        var holidaySetting = await _repository.GetByIdAsync(request.id, cancellationToken);
        if (holidaySetting == null)
        {
            return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
        }
        return holidaySetting;
    }
}


