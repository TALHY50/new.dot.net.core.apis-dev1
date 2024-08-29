
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;


namespace Admin.App.Application.Features.TransactionLimits
{
    public class DeleteTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteTransactionLimitUrl, Name = Routes.DeleteTransactionLimitName)]
        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
        {
            var result = await Mediator.Send(new DeleteTransactionLimitCommand(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record DeleteTransactionLimitCommand(uint id) : IRequest<ErrorOr<bool>>;

        public class DeleteTransactionLimitCommandValidator : AbstractValidator<DeleteTransactionLimitCommand>
        {
            public DeleteTransactionLimitCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        public class DeleteTransactionLimitCommandHandler: IRequestHandler<DeleteTransactionLimitCommand, ErrorOr<bool>>
        {
            private readonly IImtTransactionLimitRepository _transactionLimitRepository;
          
            public async Task<ErrorOr<bool>> Handle(DeleteTransactionLimitCommand request, CancellationToken cancellationToken)
            {
                return await _transactionLimitRepository.DeleteById(request.id);
            }
        }
    }

}
