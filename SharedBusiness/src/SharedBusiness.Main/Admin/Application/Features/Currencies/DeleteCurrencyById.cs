using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Features.Currencies;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.Currencies
{
    public record DeleteCurrencyByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteCurrencyByIdCommandValidator : AbstractValidator<DeleteCurrencyByIdCommand>
    {
        public DeleteCurrencyByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteCurrencyByIdCommandHandler : CurrencyBase, IRequestHandler<DeleteCurrencyByIdCommand, ErrorOr<bool>>
    {
        private readonly ICurrencyRepository _repository;

        public DeleteCurrencyByIdCommandHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCurrencyByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var currency = await _repository.GetByIdAsync(command.id);

                if (currency == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Currency not found");
                }

                await _repository.DeleteAsync(currency, cancellationToken);

            }

            return true;
        }
    }
}
