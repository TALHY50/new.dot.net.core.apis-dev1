
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionMtts
{
    public record GetInstitutionMttsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<InstitutionMtt>>>;

    public class GetInstitutionMttsQueryValidator : AbstractValidator<GetInstitutionMttsQuery>
    {
        public GetInstitutionMttsQueryValidator()
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

    public class GetInstitutionMttsQueryHandler
        : InstitutionMttBase, IRequestHandler<GetInstitutionMttsQuery, ErrorOr<List<InstitutionMtt>>>
    {
        private readonly IInstitutionMttRepository _repository;

        public GetInstitutionMttsQueryHandler(IInstitutionMttRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Common.Domain.Entities.InstitutionMtt>>> Handle(GetInstitutionMttsQuery request, CancellationToken cancellationToken)
        {
            List<InstitutionMtt>? institutionMtts;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                institutionMtts = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                institutionMtts = await _repository.ListAsync(cancellationToken);

            }

            if (institutionMtts == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "InstitutionMtt not found!");
            }

            return institutionMtts;
        }
    }
}
