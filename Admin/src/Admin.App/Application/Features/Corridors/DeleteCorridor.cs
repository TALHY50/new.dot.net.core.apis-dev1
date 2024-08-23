using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Corridors
{
    public class DeleteCorridorController : ApiControllerBase
    {
        // [Authorize]
        [HttpDelete(Routes.DeleteCorridorUrl, Name = Routes.DeleteCorridorName)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCorridorCommand(id));
            return NoContent();
        }
    }

    public record DeleteCorridorCommand(int id) : IRequest;

    internal sealed class DeleteCorridorCommandHandler(ImtApplicationDbContext context) : IRequestHandler<DeleteCorridorCommand>
    {
        private readonly ImtApplicationDbContext _context;

        public async Task Handle(DeleteCorridorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
