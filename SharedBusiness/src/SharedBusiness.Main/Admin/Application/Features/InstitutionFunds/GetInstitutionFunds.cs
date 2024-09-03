using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionFunds
{
    public record GetInstitutionFundsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<InstitutionFund>>>;

    public class GetInstitutionFundsQueryValidator : AbstractValidator<GetInstitutionFundsQuery>
    {
        public GetInstitutionFundsQueryValidator()
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

    public class GetInstitutionFundsQueryHandler
        : InstitutionFundBase, IRequestHandler<GetInstitutionFundsQuery, ErrorOr<List<InstitutionFund>>>
    {
        private readonly IInstitutionFundRepository _repository;

        public GetInstitutionFundsQueryHandler(IInstitutionFundRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<InstitutionFund>>> Handle(GetInstitutionFundsQuery request, CancellationToken cancellationToken)
        {
            List<InstitutionFund>? institutionFunds;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                institutionFunds = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                institutionFunds = await _repository.ListAsync(cancellationToken);

            }

            if (institutionFunds == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "InstitutionFund not found!");
            }

            return institutionFunds;
        }
    }
}
