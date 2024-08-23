using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Currencies
{
    public class GetCurrencyController: ApiControllerBase
    {
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
        public Task<ErrorOr<List<Currency>>> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var currencies = _repository.All().ToList(); // Convert IEnumerable to List
            return Task.FromResult<ErrorOr<List<Currency>>>(currencies); // Wrap in ErrorOr.Success
            
        }
    }
}
