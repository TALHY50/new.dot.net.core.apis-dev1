using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

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
            private readonly ITaxRateRepository _repository;

            public GetTaxRateQueryHandler(ITaxRateRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<TaxRate>>> Handle(GetTaxRateQuery request, CancellationToken cancellationToken)
            {
                return await _repository.ListAsync(cancellationToken);
            }
        }
    }
}
