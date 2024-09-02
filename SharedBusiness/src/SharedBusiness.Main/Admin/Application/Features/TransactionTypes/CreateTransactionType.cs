using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;

namespace SharedBusiness.Main.Admin.Application.Features.TransactionTypes
{
    public record CreateTransactionTypeCommand(
        string? Name,
        byte? Status) : IRequest<ErrorOr<TransactionType>>;

    public class CreateTransactionTypeCommandValidator : AbstractValidator<CreateTransactionTypeCommand>
    {
        public CreateTransactionTypeCommandValidator()
        {
            RuleFor(v => v.Name).MaximumLength(50).TransactionTypeName();
        }
    }


    public class CreateTransactionTypeCommandHandler(ILogger<CreateTransactionTypeCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, ITransactionTypeRepository repository)
        : TransactionTypeBase, IRequestHandler<CreateTransactionTypeCommand, ErrorOr<TransactionType>>
    {
        private readonly ILogger<CreateTransactionTypeCommandHandler> _logger = logger;

        public async Task<ErrorOr<TransactionType>> Handle(CreateTransactionTypeCommand command, CancellationToken cancellationToken)
        {
            var transactionType = new TransactionType
            {
                Name = command.Name,
                Status = command.Status,
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var result = await transactionHandler.ExecuteWithTransactionAsync<TransactionType>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(transactionType, cancellationToken);
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
