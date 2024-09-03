using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Banks;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Banks
{
    public record UpdateBankByIdCommand(
        uint id,
        string? code,
        string? name,
        string? displayName,
        string? url,
        string? logo,
        BankStatusValues status) : IRequest<ErrorOr<Bank>>;

    public class UpdateBankByIdCommandValidator : AbstractValidator<UpdateBankByIdCommand>
    {
        public UpdateBankByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Bank ID is required");
            RuleFor(v => v.code).MaximumLength(20).BankCode();
            RuleFor(v => v.name).MaximumLength(100).BankName();
            RuleFor(v => v.displayName).MaximumLength(100).BankDisplayName();
            RuleFor(v => v.url).MaximumLength(100).BankUrl();
            RuleFor(v => v.logo).MaximumLength(100).BankLogo();
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }

    public class UpdateBankByIdCommandHandler : BankBaseCommand, IRequestHandler<UpdateBankByIdCommand, ErrorOr<Bank>>
    {
        private readonly IBankRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateBankByIdCommandHandler(IBankRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Bank>> Handle(UpdateBankByIdCommand command, CancellationToken cancellationToken)
        {
            Bank? bank = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (bank == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => bank.Code = value, command.code);
            _guard.UpdateIfNotNullOrEmpty(value => bank.Name = value, command.name);
            _guard.UpdateIfNotNullOrEmpty(value => bank.DisplayName = value, command.displayName);
            _guard.UpdateIfNotNullOrEmpty(value => bank.Url = value, command.url);
            _guard.UpdateIfNotNullOrEmpty(value => bank.Logo = value, command.logo);

            bank.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(bank, cancellationToken);

            return bank;


        }

    }
}
