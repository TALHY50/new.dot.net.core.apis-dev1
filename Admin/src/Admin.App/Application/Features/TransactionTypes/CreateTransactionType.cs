using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class CreateTransactionTypeController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateTransactionTypeUrl, Name = Routes.CreateTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Create(CreateTransactionTypeCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateTransactionTypeCommand(
        byte Status) : IRequest<ErrorOr<TransactionType>>;


    internal sealed class CreateTransactionTypeCommandHandler
        : IRequestHandler<CreateTransactionTypeCommand, ErrorOr<TransactionType>>
    {
        private readonly IImtTransactionTypeRepository _transactionTypeRepository;

        public CreateTransactionTypeCommandHandler(IImtTransactionTypeRepository transactionTypeRepository)
        {
            _transactionTypeRepository = transactionTypeRepository;
        }

        public async Task<ErrorOr<TransactionType>> Handle(CreateTransactionTypeCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @transactionType = new TransactionType
            {
                Status = request.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };

            return await _transactionTypeRepository.AddAsync(@transactionType);
        }
    }
}
