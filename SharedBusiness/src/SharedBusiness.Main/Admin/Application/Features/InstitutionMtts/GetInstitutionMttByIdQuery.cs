
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionMtts
{
    public record GetInstitutionMttByIdQuery(uint id) : IRequest<ErrorOr<InstitutionMtt>>;

    public class GetInstitutionMttByIdQueryValidator : AbstractValidator<GetInstitutionMttByIdQuery>
    {
        public GetInstitutionMttByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("InstitutionMtt ID is required");
        }
    }

    public class GetInstitutionMttByIdQueryHandler
        : InstitutionMttBase, IRequestHandler<GetInstitutionMttByIdQuery, ErrorOr<InstitutionMtt>>
    {
        private readonly IInstitutionMttRepository _repository;

        public GetInstitutionMttByIdQueryHandler(IInstitutionMttRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<InstitutionMtt>> Handle(GetInstitutionMttByIdQuery request, CancellationToken cancellationToken)
        {
            var institutionMtt = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (institutionMtt == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return institutionMtt;
        }
    }
}
