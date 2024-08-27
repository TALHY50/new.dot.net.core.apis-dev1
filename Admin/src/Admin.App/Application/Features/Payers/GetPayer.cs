using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.Payers
{
    public class GetPayerController: ApiControllerBase
    {
        [Tags("Payer")]
        [HttpGet(Routes.GetPayerUrl, Name = Routes.GetPayerName)]
        public async Task<ActionResult<ErrorOr<List<Payer>>>> Get()
        {
            return await Mediator.Send(new GetPayerQuery()).ConfigureAwait(false);
        }
    }
    public record GetPayerQuery() : IQuery<ErrorOr<List<Payer>>>;

    internal sealed class GetPayerHandler
        : IQueryHandler<GetPayerQuery, ErrorOr<List<Payer>>>
    {
        private readonly IImtPayerRepository _repository;
        public GetPayerHandler(IImtPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Payer>>> Handle(GetPayerQuery request, CancellationToken cancellationToken)
        {
            return _repository.All().ToList();
        }
    }
}
