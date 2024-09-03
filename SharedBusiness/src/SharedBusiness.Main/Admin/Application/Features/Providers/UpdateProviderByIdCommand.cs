using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Providers
{
    public record UpdateProviderByIdCommand(
        uint id,
        string? code,
        string? name,
        string? baseUrl,
        string? apiKey,
        string? apiSecret,
        ProviderStatusValues status) : IRequest<ErrorOr<Provider>>;


    public class UpdateProviderByIdCommandValidator : AbstractValidator<UpdateProviderByIdCommand>
    {
        public UpdateProviderByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Provider ID is required");
            RuleFor(v => v.name).MaximumLength(50).ProviderCode();
            RuleFor(v => v.name).MaximumLength(50).ProviderName();
            RuleFor(v => v.name).MaximumLength(50).ProviderBaseUrl();
            RuleFor(v => v.name).MaximumLength(50).ProviderApiKey();
            RuleFor(v => v.name).MaximumLength(50).ProviderApiSecret();
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }

    public class UpdateProviderByIdCommandHandler : ProviderBaseCommand, IRequestHandler<UpdateProviderByIdCommand, ErrorOr<Provider>>
    {
        private readonly IProviderRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateProviderByIdCommandHandler(IProviderRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Provider>> Handle(UpdateProviderByIdCommand command, CancellationToken cancellationToken)
        {
            Provider? provider = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (provider == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => provider.Code = value, command.code);
            _guard.UpdateIfNotNullOrEmpty(value => provider.Name = value, command.name);
            _guard.UpdateIfNotNullOrEmpty(value => provider.BaseUrl = value, command.baseUrl);
            _guard.UpdateIfNotNullOrEmpty(value => provider.ApiKey = value, command.apiKey);
            _guard.UpdateIfNotNullOrEmpty(value => provider.ApiSecret = value, command.apiSecret);


            provider.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(provider, cancellationToken);

            return provider;


        }

    }
}
