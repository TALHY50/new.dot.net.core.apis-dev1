using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.CreateCurrencyConversionRates
{
    public record DeleteCurrencyConversionRateCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteCurrencyConversionRateCommandValidator : AbstractValidator<DeleteCurrencyConversionRateCommand>
    {
        public DeleteCurrencyConversionRateCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteCurrencyConversionRateCommandHandler : CurrencyConversionRateBase, IRequestHandler<DeleteCurrencyConversionRateCommand, ErrorOr<bool>>
    {
        private readonly ICurrencyConversionRateRepository _repository;
        public DeleteCurrencyConversionRateCommandHandler(ICurrencyConversionRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCurrencyConversionRateCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var currencyConversionRate = await _repository.GetByIdAsync(command.id);

                if (currencyConversionRate == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Currency Conversion Rate not found");
                }

                await _repository.DeleteAsync(currencyConversionRate, cancellationToken);
            }

            return true;
        }
    }
}
