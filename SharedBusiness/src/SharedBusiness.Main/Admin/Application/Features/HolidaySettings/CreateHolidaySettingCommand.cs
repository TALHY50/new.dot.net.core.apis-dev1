using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Features.HolidaySetting;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.HolidaySettings;

public record CreateHolidaySettingCommand(
    uint? country_id, DateTime date, HolidaySettingTypeValues type, string gmt, DateTime? open_at, DateTime? close_at, uint? company_id, HolidaySettingStatusValues status
    ) : IRequest<ErrorOr<HolidaySetting>>;

public class CreateHolidaySettingCommandValidator : AbstractValidator<CreateHolidaySettingCommand>
{
    public CreateHolidaySettingCommandValidator()
    {
        RuleFor(r => r.date).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.type).IsInEnum();
        RuleFor(r => r.gmt).NotEmpty().MaximumLength(5).MinimumLength(1).WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(x => x.status).IsInEnum();
    }
}

public class CreateHolidaySettingCommandHandler(ILogger<CreateHolidaySettingCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IHolidaySettingRepository repository)
    : HolidaySettingBase, IRequestHandler<CreateHolidaySettingCommand, ErrorOr<HolidaySetting>>
{
    private readonly ILogger<CreateHolidaySettingCommandHandler> _logger = logger;

    public async Task<ErrorOr<HolidaySetting>> Handle(CreateHolidaySettingCommand command, CancellationToken cancellationToken)
    {
        var holidaySetting = new HolidaySetting
        {
            CountryId = command.country_id,
            Date = command.date,
            Type = (byte)command.type, //Full,Half,Quater,Special
            Gmt = command.gmt,
            OpenAt = command.open_at,
            CloseAt = command.close_at,
            CompanyId = command.company_id,
            CreatedById = 0,
            UpdatedById = 0,
            Status = (byte)command.status, //1=active, 0=inactive, 2=soft-deleted
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        var result = await transactionHandler.ExecuteWithTransactionAsync<HolidaySetting>(
            async (ct) =>
            {
                var obj = await repository.AddAsync(holidaySetting, cancellationToken);
                return obj;
            }, dbContext, 3, cancellationToken
        );
        if (result.IsError)
        {
            return result;
        }
        return result.Value;
    }
}
