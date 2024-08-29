using Ardalis.SharedKernel;
using ErrorOr;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.Currencies
{
    public class GetCurrencyController: ApiControllerBase
    {
        [Tags("Currency")]
        //[Authorize]
        [HttpGet(Routes.GetCurrencyUrl, Name = Routes.GetCurrencyName)]
        public async Task<ActionResult<ErrorOr<List<Currency>>>> Get()
        {
            return await Mediator.Send(new GetCurrencyQuery()).ConfigureAwait(false);
        }
    }
    public record GetCurrencyQuery() : IQuery<ErrorOr<List<Currency>>>;

    internal sealed class GetCurrencyHandler
        : IQueryHandler<GetCurrencyQuery, ErrorOr<List<Currency>>>
    {
        private readonly IImtAdminCurrencyRepository _repository;

        public GetCurrencyHandler(IImtAdminCurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<List<Currency>>> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            return _repository.All().ToList();
        }
    }
}
