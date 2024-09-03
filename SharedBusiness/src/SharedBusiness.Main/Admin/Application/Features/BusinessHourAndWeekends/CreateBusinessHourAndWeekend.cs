using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Weblication.Features.BusinessHourAndWeekends;

// [Authorize]
public record CreateBusinessHourAndWeekendCommand(byte HourType, uint? CountryId,
    string Day, sbyte IsWeekend, string Gmt, DateTime OpenAt, DateTime CloseAt, uint? CompanyId)
    : IRequest<ErrorOr<BusinessHoursAndWeekend>>;

public class CreateBusinessHourAndWeekendCommandValidator : AbstractValidator<CreateBusinessHourAndWeekendCommand>
{
    public CreateBusinessHourAndWeekendCommandValidator()
    {
        RuleFor(r => r.HourType).Must(value => value == 0 || value == 1).WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString()); 
        RuleFor(r => r.Day).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.IsWeekend).Must(value => value == 0 || value == 1).WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.Gmt).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.OpenAt).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(r => r.CloseAt).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class CreateBusinessHourAndWeekendCommandHandler(ILogger<CreateBusinessHourAndWeekendCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IBusinessHourAndWeekendRepository repository)
    : BusinessHourAndWeekendBase, IRequestHandler<CreateBusinessHourAndWeekendCommand, ErrorOr<BusinessHoursAndWeekend>>
{
    private readonly ILogger<CreateBusinessHourAndWeekendCommandHandler> _logger = logger;

    public async Task<ErrorOr<BusinessHoursAndWeekend>> Handle(CreateBusinessHourAndWeekendCommand command, CancellationToken cancellationToken)
    {
        BusinessHoursAndWeekend? businessHoursAndWeekend = new BusinessHoursAndWeekend
        {
            HourType = command.HourType,
            CountryId = command.CountryId,
            Day = command.Day,
            IsWeekend = command.IsWeekend,
            Gmt = command.Gmt,
            OpenAt = command.OpenAt,
            CloseAt = command.CloseAt,
            CompanyId = command.CompanyId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        var result = await transactionHandler.ExecuteWithTransactionAsync<BusinessHoursAndWeekend>(
            async (ct) =>
            {
                var obj = await repository.AddAsync(businessHoursAndWeekend, cancellationToken);
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

