using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Corridors
{
    public record GetCorridorsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Corridor>>>;

    public class GetCorridorsQueryValidator : AbstractValidator<GetCorridorsQuery>
    {
        public GetCorridorsQueryValidator()
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

    public class GetCorridorsQueryHandler
        : CorridorBase, IRequestHandler<GetCorridorsQuery, ErrorOr<List<Corridor>>>
    {
        private readonly ICorridorRepository _repository;

        public GetCorridorsQueryHandler(ICorridorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Common.Domain.Entities.Corridor>>> Handle(GetCorridorsQuery request, CancellationToken cancellationToken)
        {
            List<Corridor>? corridors;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                corridors = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                corridors = await _repository.ListAsync(cancellationToken);

            }

            if (corridors == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Corridor not found!");
            }

            return corridors;
        }
    }

}
