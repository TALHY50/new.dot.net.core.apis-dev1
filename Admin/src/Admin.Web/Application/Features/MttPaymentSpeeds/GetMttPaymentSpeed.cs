//using ErrorOr;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using SharedBusiness.Main.Common.Application.Services.Repositories;
//using SharedBusiness.Main.Common.Domain.Entities;
//using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
//using SharedKernel.Main.Presentation;
//using SharedKernel.Main.Presentation.Routes;

//namespace Admin.App.Application.Features.MttPaymentSpeeds
//{
//    public class GetMttPaymentSpeedController : ApiControllerBase
//    {
//        [Tags("MttPaymentSpeeds")]
//        //[Authorize(Policy = "HasPermission")]
//        [HttpGet(Routes.GetMttPaymentSpeedUrl, Name = Routes.GetMttPaymentSpeedName)]
//        public async Task<ActionResult<ErrorOr<List<MttPaymentSpeed>>>> Get()
//        {
//            var result = await Mediator.Send(new GetMttPaymentSpeedQuery()).ConfigureAwait(false);

//            return result.Match(
//                reminder => Ok(result.Value),
//                Problem);
//        }

//        public record GetMttPaymentSpeedQuery() : IRequest<ErrorOr<List<MttPaymentSpeed>>>;

//        public class GetMttPaymentSpeedHandler
//            : IRequestHandler<GetMttPaymentSpeedQuery, ErrorOr<List<MttPaymentSpeed>>>
//        {
//            private readonly IMTTPaymentSpeedRepository _imttPaymentSpeedRepository;

//            public GetMttPaymentSpeedHandler(IMTTPaymentSpeedRepository imttPaymentSpeedRepository)
//            {
//                _imttPaymentSpeedRepository = imttPaymentSpeedRepository;
//            }

//            public async Task<ErrorOr<List<MttPaymentSpeed>>> Handle(GetMttPaymentSpeedQuery request, CancellationToken cancellationToken)
//            {
//               return await _imttPaymentSpeedRepository.ListAsync();
//            }
//        }
//    }
//}
