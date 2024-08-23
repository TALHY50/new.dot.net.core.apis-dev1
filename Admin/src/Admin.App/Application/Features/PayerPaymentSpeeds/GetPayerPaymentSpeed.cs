using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetPayerPaymentSpeedUrl, Name = Routes.GetPayerPaymentSpeedName)]
        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Get()
        {
            return await Mediator.Send(new GetPayerPaymentSpeedQuery()).ConfigureAwait(false);
        }

        public record GetPayerPaymentSpeedQuery() : IQuery<ErrorOr<PayerPaymentSpeed>>;

        internal sealed class GetPayerPaymentSpeedQueryHandler() : IQueryHandler<GetPayerPaymentSpeedQuery, ErrorOr<PayerPaymentSpeed>>
        {
            // get all data 
            public Task<ErrorOr<PayerPaymentSpeed>> Handle(GetPayerPaymentSpeedQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
