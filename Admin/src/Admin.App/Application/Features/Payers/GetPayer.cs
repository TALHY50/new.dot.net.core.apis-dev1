using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Payers
{
    public class GetPayerController: ApiControllerBase
    {
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

        public Task<ErrorOr<List<Payer>>> Handle(GetPayerQuery request, CancellationToken cancellationToken)
        {
            var payer = _repository.All().ToList();
            return Task.FromResult<ErrorOr<List<Payer>>>(payer);
        }
    }
}
