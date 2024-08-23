using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Providers
{
    public class DeleteProviderController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.DeleteProviderUrl, Name = Routes.DeleteProviderName)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProviderCommand(id));

            return NoContent();
        }
    }

    public record DeleteProviderCommand(int Id) : IRequest;

    internal sealed class DeleteProviderCommandHandler(ImtApplicationDbContext context)
        : IRequestHandler<DeleteProviderCommand>
    {
        private readonly ImtApplicationDbContext _context = context;

        public async Task Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
