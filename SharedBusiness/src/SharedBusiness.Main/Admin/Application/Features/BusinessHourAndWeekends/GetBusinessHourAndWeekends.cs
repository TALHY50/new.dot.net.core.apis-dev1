using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Weblication.Features.BusinessHourAndWeekends;

public record GetBusinessHourAndWeekendsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<BusinessHoursAndWeekend>>>;

public class GetBusinessHourAndWeekendsQueryValidator : AbstractValidator<GetBusinessHourAndWeekendsQuery>
{
    public GetBusinessHourAndWeekendsQueryValidator()
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

public class GetBusinessHourAndWeekendsQueryHandler
    : BusinessHourAndWeekendBase, IRequestHandler<GetBusinessHourAndWeekendsQuery, ErrorOr<List<BusinessHoursAndWeekend>>>
{
    private readonly IBusinessHourAndWeekendRepository _repository;

    public GetBusinessHourAndWeekendsQueryHandler(IBusinessHourAndWeekendRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<List<BusinessHoursAndWeekend>>> Handle(GetBusinessHourAndWeekendsQuery request, CancellationToken cancellationToken)
    {
        List<BusinessHoursAndWeekend>? businessHoursAndWeekends;

        if (request.PageNumber > 0 && request.PageSize > 0)
        {
            businessHoursAndWeekends = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);
        }
        else
        {
            businessHoursAndWeekends = await _repository.ListAsync(cancellationToken);
        }

        if (businessHoursAndWeekends == null)
        {
            return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Country not found!");
        }

        return businessHoursAndWeekends;
    }
}
