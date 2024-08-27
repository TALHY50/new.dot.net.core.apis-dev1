using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;


namespace Admin.App.Application.Features.TransactionTypes
{
    public class UpdateTransactionTypeController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateTransactionTypeUrl, Name = Routes.UpdateTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Update(uint id, UpdateTransactionTypeCommand command)
        {
            var commandWithId = command with { id = id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateTransactionTypeCommand(
        uint id,
        byte Status) : IRequest<ErrorOr<TransactionType>>;

        internal sealed class UpdateTransactionTypeCommandHandler
        : IRequestHandler<UpdateTransactionTypeCommand, ErrorOr<TransactionType>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtTransactionTypeRepository _transactionTypeRepository;

            public UpdateTransactionTypeCommandHandler(ICurrentUserService user, IImtTransactionTypeRepository transactionTypeRepository)
            {
                _user = user;
                _transactionTypeRepository = transactionTypeRepository;
            }

            public async Task<ErrorOr<TransactionType>> Handle(UpdateTransactionTypeCommand request, CancellationToken cancellationToken)
            {
                var now = DateTime.UtcNow;
                TransactionType? transactionTypes = _transactionTypeRepository.GetByUintId(request.id);

                if (transactionTypes != null)
                {
                    transactionTypes.Status = request.Status;
                    transactionTypes.CreatedById = 1;
                    transactionTypes.UpdatedById = 2;
                    transactionTypes.CreatedAt = now;
                    transactionTypes.UpdatedAt = now;
                };

                return await _transactionTypeRepository.UpdateAsync(@transactionType);
            }
        }

    }
}

