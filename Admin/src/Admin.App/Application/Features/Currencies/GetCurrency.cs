using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
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
            var result = await Mediator.Send(new GetCurrencyQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record GetCurrencyQuery() : IQuery<ErrorOr<List<Currency>>>;

    public class GetCurrencyHandler
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
