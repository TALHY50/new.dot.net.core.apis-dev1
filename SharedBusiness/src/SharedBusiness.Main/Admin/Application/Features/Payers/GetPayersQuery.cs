using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.Corridors;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.Payers
{
    public record GetPayersQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Payer>>>;

    public class GetPayersQueryValidator : AbstractValidator<GetPayersQuery>
    {
        public GetPayersQueryValidator()
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

    public class GetPayersQueryHandler
        : PayerBase, IRequestHandler<GetPayersQuery, ErrorOr<List<Payer>>>
    {
        private readonly IPayerRepository _repository;

        public GetPayersQueryHandler(IPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Common.Domain.Entities.Payer>>> Handle(GetPayersQuery request, CancellationToken cancellationToken)
        {
            List<Payer>? payers;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                payers = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                payers = await _repository.ListAsync(cancellationToken);

            }

            if (payers == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Payer not found!");
            }

            return payers;
        }
    }
}
