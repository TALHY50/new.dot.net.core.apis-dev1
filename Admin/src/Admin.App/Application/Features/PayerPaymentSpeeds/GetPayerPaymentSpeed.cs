using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetPayerPaymentSpeedUrl, Name = Routes.GetPayerPaymentSpeedName)]
        public async Task<ActionResult<ErrorOr<List<PayerPaymentSpeed>>>> Get()
        {
            return await Mediator.Send(new GetPayerPaymentSpeedQuery()).ConfigureAwait(false);
        }

        public record GetPayerPaymentSpeedQuery() : IRequest<ErrorOr<List<PayerPaymentSpeed>>>;

        internal sealed class GetPayerPaymentSpeedQueryHandler : IRequestHandler<GetPayerPaymentSpeedQuery, ErrorOr<List<PayerPaymentSpeed>>>
        {
            private readonly IImtPayerPaymentSpeedRepository _repository;

            public GetPayerPaymentSpeedQueryHandler(IImtPayerPaymentSpeedRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<PayerPaymentSpeed>>> Handle(GetPayerPaymentSpeedQuery request, CancellationToken cancellationToken)
            {
                return _repository.All().ToList();
            }
        }
    }
}
