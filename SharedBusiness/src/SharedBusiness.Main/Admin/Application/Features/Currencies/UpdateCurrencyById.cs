using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Features.Currencies;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Application.Features.Currencies
{
    public record UpdateCurrencyByIdCommand(
        uint id,
        string? Code,
        string? IsoCode,
        string? Name,
        string? Symbol,
        StatusValues status) : IRequest<ErrorOr<Currency>>;

    public class UpdateCurrencyByIdCommandValidator : AbstractValidator<UpdateCurrencyByIdCommand>
    {
        public UpdateCurrencyByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Currency ID is required");
            RuleFor(x => x.Code).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("IsoCodeShort cannot be empty");
            RuleFor(x => x.IsoCode).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("iso_code cannot be empty");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(100).WithMessage("name cannot be empty");
            RuleFor(x => x.Symbol).NotEmpty().MinimumLength(1).MaximumLength(50).WithMessage("Symbol cannot be empty");
        }
    }

    public class UpdateCurrencyByIdCommandHandler : CurrencyBase, IRequestHandler<UpdateCurrencyByIdCommand, ErrorOr<Currency>>
    {
        private readonly ICurrencyRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateCurrencyByIdCommandHandler(ICurrencyRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Currency>> Handle(UpdateCurrencyByIdCommand command, CancellationToken cancellationToken)
        {
            Currency? currency = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (currency == null)
            {
                return Error.NotFound(description: "Currency not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => currency.IsoCode = value, command.IsoCode);
            _guard.UpdateIfNotNullOrEmpty(value => currency.Code = value, command.Code);
            _guard.UpdateIfNotNullOrEmpty(value => currency.Symbol = value, command.Symbol);
            _guard.UpdateIfNotNullOrEmpty(value => currency.Name = value, command.Name);
            
            currency.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(currency, cancellationToken);

            return currency;


        }

    }
}
