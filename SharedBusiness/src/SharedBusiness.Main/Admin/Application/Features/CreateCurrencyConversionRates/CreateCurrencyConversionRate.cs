using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.CreateCurrencyConversionRates
{
    public record CreateCurrencyConversionRateCommand(
        uint CorridorId,
        decimal ExchangeRate,
        decimal FxSpread,
        uint? CompanyId,
        byte Status
        ) : IRequest<ErrorOr<CurrencyConversionRate>>;

    public class CreateCurrencyConversionRateCommandValidator : AbstractValidator<CreateCurrencyConversionRateCommand>
    {
        public CreateCurrencyConversionRateCommandValidator()
        {
            RuleFor(x => x.CorridorId).NotEmpty().WithMessage("CorridorId Code  is required");
            RuleFor(x => x.ExchangeRate).NotEmpty().WithMessage("ExchangeRate Code  is required");
            RuleFor(x => x.FxSpread).NotEmpty().WithMessage("FxSpread Code  is required");
        }
    }

    public class CreateCurrencyConversionRateCommandHandler : IRequestHandler<CreateCurrencyConversionRateCommand, ErrorOr<CurrencyConversionRate>>
    {
        private readonly ICurrencyConversionRateRepository _repository;

        public CreateCurrencyConversionRateCommandHandler(ICurrencyConversionRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<CurrencyConversionRate>> Handle(CreateCurrencyConversionRateCommand command, CancellationToken cancellationToken)
        {
            var currencyConversionRate = new CurrencyConversionRate
            {
                CorridorId = command.CorridorId,
                ExchangeRate = command.ExchangeRate, //Exchange rate between currencies
                FxSpread = command.FxSpread, //Foreign exchange spread
                CompanyId = 0, 
                Status = 1, // 0=inactive, 1=active, 2=pending, 3=rejected 
                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var message = new MessageResponse("Record not found");
            if (currencyConversionRate == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return _repository.Add(currencyConversionRate)!;
        }
    }
}
