using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Features.Currencies;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Weblication.Features.Currencies
{
    public record GetCurrencyByIdQuery(uint id) : IRequest<ErrorOr<Currency>>;

    public class GetCurrencyByIdQueryValidator : AbstractValidator<GetCurrencyByIdQuery>
    {
        public GetCurrencyByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Currency ID is required");
        }
    }

    public class GetCurrencyByIdQueryHandler : CurrencyBase, IRequestHandler<GetCurrencyByIdQuery, ErrorOr<Currency>>
    {
        private readonly ICurrencyRepository _repository;

        public GetCurrencyByIdQueryHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Currency>> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
        {
            var Currency = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (Currency == null)
            {
                return Error.NotFound(description: "Currency not found!", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return Currency;
        }
    }
}
