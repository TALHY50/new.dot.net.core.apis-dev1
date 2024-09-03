using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using System.Configuration.Provider;

namespace SharedBusiness.Main.Admin.Application.Features.Providers
{
    //[Authorize]
    public record CreateProviderCommand(
        string? code,
        string? name,
        string? baseUrl,
        string? apiKey,
        string? apiSecret,
        ProviderStatusValues status
        ) : IRequest<ErrorOr<Provider>>;

    public class CreateProviderCommandValidator : AbstractValidator<CreateProviderCommand>
    {
        public CreateProviderCommandValidator()
        {
            RuleFor(v => v.name).MaximumLength(50).ProviderCode();
            RuleFor(v => v.name).MaximumLength(50).ProviderName();
            RuleFor(v => v.name).MaximumLength(50).ProviderBaseUrl();
            RuleFor(v => v.name).MaximumLength(50).ProviderApiKey();
            RuleFor(v => v.name).MaximumLength(50).ProviderApiSecret();
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }

    public class CreateProviderCommandHandler(ILogger<CreateProviderCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IProviderRepository repository)
        : ProviderBaseCommand, IRequestHandler<CreateProviderCommand, ErrorOr<Provider>>
    {
        private readonly ILogger<CreateProviderCommandHandler> _logger = logger;

        public async Task<ErrorOr<Provider>> Handle(CreateProviderCommand command, CancellationToken cancellationToken)
        {
            var provider = new Provider
            {
                Code = command.code,
                Name = command.name,
                BaseUrl = command.baseUrl,
                ApiKey = command.apiKey,
                ApiSecret = command.apiSecret,
                Status = (byte) command.status,
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await transactionHandler.ExecuteWithTransactionAsync<Provider>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(provider, cancellationToken);
                    return obj;

                }, dbContext, 3, cancellationToken
            );

            if (result.IsError)
            {
                return result;
            }

            return result.Value;
        }
    }
}
