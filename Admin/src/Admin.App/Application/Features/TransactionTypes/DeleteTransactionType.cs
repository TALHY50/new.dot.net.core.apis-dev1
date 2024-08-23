using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class DeleteTransactionTypeController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.DeleteTransactionTypeUrl, Name = Routes.DeleteTransactionTypeName)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTransactionTypeCommand(id));

            return NoContent();
        }
    }

    public record DeleteTransactionTypeCommand(int Id) : IRequest;

    internal sealed class DeleteTransactionTypeCommandHandler(ImtApplicationDbContext context)
        : IRequestHandler<DeleteTransactionTypeCommand>
    {
        private readonly ImtApplicationDbContext _context = context;

        public async Task Handle(DeleteTransactionTypeCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
