using ADMIN.Application.Infrastructure.Persistence.Configurations;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.Currencies
{
    public class DeleteCurrencyController : ApiControllerBase
    {
        [Authorize]
        [HttpDelete(Routes.DeleteCurrencyUrl, Name = Routes.DeleteCurrencyName)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCurrencyCommand(id));
            return NoContent();
        }
    }
    public record DeleteCurrencyCommand(int id) : IRequest;

    internal sealed class DeleteCurrencyCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteCurrencyCommand>
    {
        private readonly ApplicationDbContext _context;
        public async Task Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
