using ErrorOr;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.TaxRates
{
    public class GetTaxRateController : ApiControllerBase
    {
        [Tags("TaxRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTaxRateUrl, Name = Routes.GetTaxRateName)]
        public async Task<ActionResult<ErrorOr<List<TaxRate>>>> Get()
        {
            return await Mediator.Send(new GetTaxRateQuery()).ConfigureAwait(false);
        }

        public record GetTaxRateQuery() : IRequest<ErrorOr<List<TaxRate>>>;

        internal sealed class GetTaxRateQueryHandler : IRequestHandler<GetTaxRateQuery, ErrorOr<List<TaxRate>>>
        {
            private readonly IImtTaxRateRepository _repository;

            public GetTaxRateQueryHandler(IImtTaxRateRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<TaxRate>>> Handle(GetTaxRateQuery request, CancellationToken cancellationToken)
            {
                return _repository.All().ToList();
            }
        }
    }
}
