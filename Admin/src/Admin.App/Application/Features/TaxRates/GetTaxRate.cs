using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
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
            var result = await Mediator.Send(new GetTaxRateQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetTaxRateQuery() : IRequest<ErrorOr<List<TaxRate>>>;

        public class GetTaxRateQueryHandler : IRequestHandler<GetTaxRateQuery, ErrorOr<List<TaxRate>>>
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
