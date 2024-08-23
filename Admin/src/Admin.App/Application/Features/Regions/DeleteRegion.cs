using ADMIN.Application.Infrastructure.Persistence.Configurations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace ADMIN.App.Application.Features.Regions
{
    public class DeleteRegionController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.DeleteRegionUrl, Name = Routes.DeleteRegionName)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRegionCommand(id));

            return NoContent();
        }
    }

    public record DeleteRegionCommand(int Id) : IRequest;

    internal sealed class DeleteRegionCommandHandler(ApplicationDbContext context) 
        : IRequestHandler<DeleteRegionCommand>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
