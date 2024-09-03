using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.BusinessHourAndWeekends
{

    public record GetBusinessHoursAndWeekendByIdQuery(uint id) : IRequest<ErrorOr<BusinessHoursAndWeekend>>;

    public class GetBusinessHoursAndWeekendByIdQueryValidator : AbstractValidator<GetBusinessHoursAndWeekendByIdQuery>
    {
        public GetBusinessHoursAndWeekendByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }

    public class GetBusinessHoursAndWeekendByIdQueryHandler : BusinessHourAndWeekendBase, IRequestHandler<GetBusinessHoursAndWeekendByIdQuery, ErrorOr<BusinessHoursAndWeekend>>
    {
        private readonly IBusinessHourAndWeekendRepository _repository;

        public GetBusinessHoursAndWeekendByIdQueryHandler(IBusinessHourAndWeekendRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<BusinessHoursAndWeekend>> Handle(GetBusinessHoursAndWeekendByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (country == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return country;
        }
    }
}

