using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.Payers
{
    public class GetPayerController: ApiControllerBase
    {
        [Tags("Payer")]
        [HttpGet(Routes.GetPayerUrl, Name = Routes.GetPayerName)]
        public async Task<ActionResult<ErrorOr<List<Payer>>>> Get()
        {
            var result = await Mediator.Send(new GetPayerQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record GetPayerQuery() : IQuery<ErrorOr<List<Payer>>>;

    public class GetPayerHandler
        : IQueryHandler<GetPayerQuery, ErrorOr<List<Payer>>>
    {
        private readonly IPayerRepository _repository;
        public GetPayerHandler(IPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Payer>>> Handle(GetPayerQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListAsync();
        }
    }
}
