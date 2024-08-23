using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Currencies
{
    public class GetCurrencyById : ApiControllerBase
    {
        [Authorize]
        [HttpGet(Routes.GetCurrencyByIdUrl, Name = Routes.GetCurrencyByIdName)]
        public async Task<ActionResult<ErrorOr<Currency>>> GetById(int id)
        {
            return await Mediator.Send(new GetCurrencyByIdQuery(id)).ConfigureAwait(false);
        }
    }
    public record GetCurrencyByIdQuery(int id) : IRequest<ErrorOr<Currency>>;

    internal sealed class GetCurrencyByIdQueryHandler() :
        IRequestHandler<GetCurrencyByIdQuery, ErrorOr<Currency>>
    {
        public Task<ErrorOr<Currency>> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
