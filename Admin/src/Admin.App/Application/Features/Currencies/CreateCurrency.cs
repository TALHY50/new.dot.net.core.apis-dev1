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
    public class CreateCurrencyController : ApiControllerBase
    {
        [Authorize]
        [HttpPost(Routes.CreateCurrencyUrl, Name = Routes.CreateCurrencyName)]
        public async Task<ActionResult<ErrorOr<Currency>>> Create(CreateCurrencyCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateCurrencyCommand(
        string? Code,
        string? IsoCode,
        string? Name,
        string? Symbol) : IRequest<ErrorOr<Currency>>;

    internal sealed class CreateCurrencyCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateCurrencyCommand, ErrorOr<Currency>>
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<ErrorOr<Currency>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
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
