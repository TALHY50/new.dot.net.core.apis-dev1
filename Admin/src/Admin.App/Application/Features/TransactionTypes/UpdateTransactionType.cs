using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;


namespace Admin.App.Application.Features.TransactionTypes
{
    public class UpdateTransactionTypeController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateTransactionTypeUrl, Name = Routes.UpdateTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Update(UpdateTransactionTypeCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

    }

    public record UpdateTransactionTypeCommand(
        int Id,
        string? Name,
        sbyte Status) : IRequest<ErrorOr<TransactionType>>;

    internal sealed class UpdateTransactionTypeCommandHandler(ImtApplicationDbContext context)
        : IRequestHandler<UpdateTransactionTypeCommand, ErrorOr<TransactionType>>
    {


        public async Task<ErrorOr<TransactionType>> Handle(UpdateTransactionTypeCommand command, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @transactionType = new TransactionType
            {
                //Name = command.Name,
                //Status = command.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };
            // _context.Events.Add(@region);

            return @transactionType;
        }
    }
}

