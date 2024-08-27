using Ardalis.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using static Admin.App.Application.Features.Mtts.MttsDelete;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class DeleteTransactionTypeController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteTransactionTypeUrl, Name = Routes.DeleteTransactionTypeName)]
        public async Task<bool> Delete(uint id)
        {
            return await Mediator.Send(new DeleteTransactionTypeCommand(id)).ConfigureAwait(false);
        }

        public record DeleteTransactionTypeCommand(uint id) 
            : IRequest<bool>;

        internal sealed class DeleteTransactionTypeCommandValidator : AbstractValidator<DeleteTransactionTypeCommand>
        {
            public DeleteTransactionTypeCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        internal sealed class DeleteTransactionTypeCommandHandler
        : IRequestHandler<DeleteTransactionTypeCommand, bool>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtTransactionTypeRepository _transactiontypeRepository;
           
            public DeleteTransactionTypeCommandHandler(ICurrentUserService user, IImtTransactionTypeRepository transactionTypeRepository)
            {
                _user = user;
                _transactiontypeRepository = transactionTypeRepository;
            }

            public async Task<bool> Handle(DeleteTransactionTypeCommand request, CancellationToken cancellationToken)
            {
                if (request.id > 0)
                {
                    var transactionTypes = _transactiontypeRepository.GetByUintId(request.id);

                    if (transactionTypes != null)
                    {
                        return await _transactiontypeRepository.DeleteAsync(transactionTypes);
                    }

                    return await _transactiontypeRepository.DeleteAsync(transactionTypes);
                }

                return false;
            }
        }
    }

}
