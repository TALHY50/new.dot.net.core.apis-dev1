using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Application.Features.MttPaymentSpeeds
{
    public class GetMttPaymentSpeedController : ApiControllerBase
    {
        [Tags("MttPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetMttPaymentSpeedUrl, Name = Routes.GetMttPaymentSpeedName)]
        public async Task<ActionResult<ErrorOr<List<MttPaymentSpeed>>>> Get()
        {
            var result = await Mediator.Send(new GetMttPaymentSpeedQuery()).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetMttPaymentSpeedQuery() : IRequest<ErrorOr<List<MttPaymentSpeed>>>;

        public class GetMttPaymentSpeedHandler
            : IRequestHandler<GetMttPaymentSpeedQuery, ErrorOr<List<MttPaymentSpeed>>>
        {
            private readonly IImtMttPaymentSpeedRepository _MttPaymentSpeedRepository;

            public GetMttPaymentSpeedHandler(IImtMttPaymentSpeedRepository MttPaymentSpeedRepository)
            {
                _MttPaymentSpeedRepository = MttPaymentSpeedRepository;
            }

            public async Task<ErrorOr<List<MttPaymentSpeed>>> Handle(GetMttPaymentSpeedQuery request, CancellationToken cancellationToken)
            {
                return _MttPaymentSpeedRepository.GetAll().ToList();
            }
        }
    }
}
