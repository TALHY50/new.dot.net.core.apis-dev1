using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionFunds
{
    public record GetInstitutionFundByIdQuery(uint id) : IRequest<ErrorOr<InstitutionFund>>;

    public class GetInstitutionFundByIdQueryValidator : AbstractValidator<GetInstitutionFundByIdQuery>
    {
        public GetInstitutionFundByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Institution Fund ID is required");
        }
    }

    public class GetInstitutionFundByIdQueryHandler : InstitutionFundBase, IRequestHandler<GetInstitutionFundByIdQuery, ErrorOr<InstitutionFund>>
    {
        private readonly IInstitutionFundRepository _repository;

        public GetInstitutionFundByIdQueryHandler(IInstitutionFundRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<InstitutionFund>> Handle(GetInstitutionFundByIdQuery request, CancellationToken cancellationToken)
        {
            var institutionFund = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (institutionFund == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return institutionFund;
        }
    }
}
