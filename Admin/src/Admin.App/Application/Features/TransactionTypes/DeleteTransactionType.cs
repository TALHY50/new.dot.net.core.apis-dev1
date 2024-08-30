using ACL.Business.Contracts.Responses;
using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Mtts.InstitutionDelete;
using static Admin.App.Application.Features.Regions.DeleteRegionController;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class DeleteTransactionTypeController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteTransactionTypeUrl, Name = Routes.DeleteTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
        {
            var result = await Mediator.Send(new DeleteTransactionTypeCommand(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record DeleteTransactionTypeCommand(uint id) 
            : IRequest<ErrorOr<bool>>;

        public class DeleteTransactionTypeCommandValidator : AbstractValidator<DeleteTransactionTypeCommand>
        {
            public DeleteTransactionTypeCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        public class DeleteTransactionTypeCommandHandler
        : IRequestHandler<DeleteTransactionTypeCommand, ErrorOr<bool>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtTransactionTypeRepository _transactiontypeRepository;

            public DeleteTransactionTypeCommandHandler(ICurrentUserService user, IImtTransactionTypeRepository transactionTypeRepository)
            {
                _user = user;
                _transactiontypeRepository = transactionTypeRepository;
            }

            public async Task<ErrorOr<bool>> Handle(DeleteTransactionTypeCommand request, CancellationToken cancellationToken)
            {
                var transactionTypes = _transactiontypeRepository.View(request.id);

                if (transactionTypes == null)
                {
                    return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _transactiontypeRepository.Delete(transactionTypes);
            }
        }
    }

}
