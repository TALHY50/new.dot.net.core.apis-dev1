using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.HolidaySetting;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.HolidaySettings;

public record GetHolidaySettingsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<HolidaySetting>>>;

public class GetHolidaySettingsQueryValidator : AbstractValidator<GetHolidaySettingsQuery>
{
    public GetHolidaySettingsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .When(x => x.PageNumber != 0)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .When(x => x.PageNumber > 0)
            .When(x => x.PageSize != 0)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class GetHolidaySettingsQueryHandler
    : HolidaySettingBase, IRequestHandler<GetHolidaySettingsQuery, ErrorOr<List<HolidaySetting>>>
{
    private readonly IHolidaySettingRepository _repository;

    public GetHolidaySettingsQueryHandler(IHolidaySettingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<List<HolidaySetting>>> Handle(GetHolidaySettingsQuery request, CancellationToken cancellationToken)
    {
        List<HolidaySetting>? holidaySettingRepository;
        if (request.PageNumber > 0 && request.PageSize > 0)
        {
            holidaySettingRepository = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);
        }
        else
        {
            holidaySettingRepository = await _repository.ListAsync(cancellationToken);
        }
        if (holidaySettingRepository == null)
        {
            return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
        }
        return holidaySettingRepository;
    }
}
