using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.TaxRates
{
    public record GetTaxRateByIdQuery(uint id) : IRequest<ErrorOr<TaxRate>>;

    public class GetTaxRateByIdQueryValidator : AbstractValidator<GetTaxRateByIdQuery>
    {
        public GetTaxRateByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("TaxRate ID is required");
        }
    }

    public class GetTaxRateByIdQueryHandler : TaxRateBase, IRequestHandler<GetTaxRateByIdQuery, ErrorOr<Common.Domain.Entities.TaxRate>>
    {
        private readonly ITaxRateRepository _repository;

        public GetTaxRateByIdQueryHandler(ITaxRateRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<TaxRate>> Handle(GetTaxRateByIdQuery request, CancellationToken cancellationToken)
        {
            var taxRate = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (taxRate == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return taxRate;
        }
    }
}
