using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Providers
{
    public record GetProvidersQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Provider>>>;

    public class GetProvidersQueryValidator : AbstractValidator<GetProvidersQuery>
    {
        public GetProvidersQueryValidator()
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


    public class GetProvidersQueryHandler
        : ProviderBaseCommand, IRequestHandler<GetProvidersQuery, ErrorOr<List<Provider>>>
    {
        private readonly IProviderRepository _repository;

        public GetProvidersQueryHandler(IProviderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Provider>>> Handle(GetProvidersQuery request, CancellationToken cancellationToken)
        {
            List<Provider>? providers;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                providers = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                providers = await _repository.ListAsync(cancellationToken);

            }

            if (providers == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Provider not found"));
            }

            return providers;
        }
    }
}
