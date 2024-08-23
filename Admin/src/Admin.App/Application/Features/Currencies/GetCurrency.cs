using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Currencies
{
    public class GetCurrencyController: ApiControllerBase
    {
        //[Authorize]
        [HttpGet(Routes.GetCurrencyUrl, Name = Routes.GetCurrencyName)]
        public async Task<ActionResult<ErrorOr<Currency>>> Get()
        {
            return await Mediator.Send(new GetCurrencyQuery()).ConfigureAwait(false);
        }
    }
    public record GetCurrencyQuery() : IQuery<ErrorOr<Currency>>;

    internal sealed class GetCurrencyHandler()
        : IQueryHandler<GetCurrencyQuery, ErrorOr<Currency>>
    {
        public Task<ErrorOr<Currency>> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
