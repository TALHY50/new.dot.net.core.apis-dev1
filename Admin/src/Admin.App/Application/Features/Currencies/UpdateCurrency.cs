using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Currencies
{
    public class UpdateCurrencyController : ApiControllerBase
    {
        [Tags("Currency")]
        //[Authorize]//(Policy = "HasPermission")]
        [HttpPost(Routes.UpdateCurrencyUrl, Name = Routes.UpdateCurrencyName)]

        public async Task<ActionResult<ErrorOr<Currency>>> Update(UpdateCurrencyCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
    public record UpdateCurrencyCommand(
    string? Code,
    string? IsoCode,
    string? Name,
    string? Symbol) : IRequest<ErrorOr<Currency>>;
    internal sealed class UpdateCurrencyCommandHandler(ImtApplicationDbContext context) 
        : IRequestHandler<UpdateCurrencyCommand, ErrorOr<Currency>>
    {
        private readonly ImtApplicationDbContext _context = context;
        public async Task<ErrorOr<Currency>> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @currency = new Currency
            {
                Code = request.Code,
                IsoCode = request.IsoCode,
                Name = request.Name,
                Symbol = request.Symbol,
                CreatedById = 1,
                UpdatedById = 2,
                Status = 1,
                CreatedAt = now,
                UpdatedAt = now,
            };
            //_context.currencies.Add(@event);

            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return @currency;
        }
    }
}
