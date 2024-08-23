using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetPayerPaymentSpeedUrl, Name = Routes.GetPayerPaymentSpeedName)]
        public async Task<ActionResult<List<PayerPaymentSpeed>>> Get()
        {
            return await Mediator.Send(new GetPayerPaymentSpeedQuery()).ConfigureAwait(false);
        }

        public record GetPayerPaymentSpeedQuery() : IQuery<List<PayerPaymentSpeed>>;

        internal sealed class GetPayerPaymentSpeedQueryHandler : IQuery<List<PayerPaymentSpeed>>
        {
            private readonly IImtPayerPaymentSpeedRepository _repository;

            public GetPayerPaymentSpeedQueryHandler(IImtPayerPaymentSpeedRepository repository)
            {
                _repository = repository;
            }
            public Task<List<PayerPaymentSpeed>> Handle(GetPayerPaymentSpeedQuery request, CancellationToken cancellationToken)
            {
                 return Task.FromResult(_repository.All().ToList());
            }
        }
    }
}
