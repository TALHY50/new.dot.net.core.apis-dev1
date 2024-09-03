using ACL.Business.Infrastructure.Persistence.Context;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Features.Banks;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;


namespace SharedBusiness.Main.Admin.Application.Features.Banks
{
    public record CreateBankCommand(
        string? code,
        string? name,
        string? displayName,
        string? url,
        string? logo,
        BankStatusValues status
        ) : IRequest<ErrorOr<Bank>>;
    public class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
    {
        public CreateBankCommandValidator()
        {
            RuleFor(v => v.code).MaximumLength(20).BankCode();
            RuleFor(v => v.name).MaximumLength(100).BankName();
            RuleFor(v => v.displayName).MaximumLength(100).BankDisplayName();
            RuleFor(v => v.url).MaximumLength(100).BankUrl();
            RuleFor(v => v.logo).MaximumLength(100).BankLogo();
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }

    public class CreateBankCommandHandler(ILogger<CreateBankCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IBankRepository repository)
        : BankBase, IRequestHandler<CreateBankCommand, ErrorOr<Bank>>
    {
        private readonly ILogger<CreateBankCommandHandler> _logger = logger;

        public async Task<ErrorOr<Bank>> Handle(CreateBankCommand command, CancellationToken cancellationToken)
        {
            var bank = new Bank
            {
                Code = command.code,
                Name = command.name,
                DisplayName = command.displayName,
                Url = command.url,
                Logo = command.logo,
                CreatedById = 0,
                UpdatedById = 0,
                Status = (byte) command.status, //1=active, 0=inactive, 2=soft-deleted
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<Bank>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(bank, cancellationToken);
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
