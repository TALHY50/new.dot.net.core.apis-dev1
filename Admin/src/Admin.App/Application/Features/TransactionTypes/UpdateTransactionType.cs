using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;


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
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdateTransactionTypeCommand(
        uint id,
        string Name,
        byte? Status) : IRequest<ErrorOr<TransactionType>>;

        public class UpdateTransactionTypeCommandValidator : AbstractValidator<UpdateTransactionTypeCommand>
        {
            public UpdateTransactionTypeCommandValidator()
            {
                RuleFor(v => v.id)
                    .NotEmpty()
                    .WithMessage("ID is required.");
                RuleFor(v => v.Name)
                    .MaximumLength(50)
                    .WithMessage("Maximum length can be 50.");
            }
        }


        public class UpdateTransactionTypeCommandHandler
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

                if (transactionTypes == null)
                {
                    return Error.NotFound(description: "TransactionType not found", code: AppStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                transactionTypes.Name = request.Name;
                transactionTypes.Status = request.Status;
                transactionTypes.CreatedById = 1;
                transactionTypes.UpdatedById = 2;
                transactionTypes.CreatedAt = now;
                transactionTypes.UpdatedAt = now;

                return await _transactionTypeRepository.UpdateAsync(transactionTypes);
            }
        }

    }
}

