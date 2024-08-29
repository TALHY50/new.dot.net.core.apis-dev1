using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.MttPaymentSpeeds
{
    public class GetMttPaymentSpeedByIdController : ApiControllerBase
    {
        [Tags("MttPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetMttPaymentSpeedByIdUrl, Name = Routes.GetMttPaymentSpeedByIdName)]
        public async Task<ActionResult<ErrorOr<MttPaymentSpeed>>> Get(uint id)
        {
            var result = await Mediator.Send(new GetMttPaymentSpeedByIdQuery(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetMttPaymentSpeedByIdQuery(uint id) : IRequest<ErrorOr<MttPaymentSpeed>>;

        public class GetMttPaymentSpeedByIdCommandValidator : AbstractValidator<GetMttPaymentSpeedByIdQuery>
        {
            public GetMttPaymentSpeedByIdCommandValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("ID is required");
            }
        }

        public class GetMttPaymentSpeedByIdQueryHandler
            : IRequestHandler<GetMttPaymentSpeedByIdQuery, ErrorOr<MttPaymentSpeed>>
        {
            private readonly IImtMttPaymentSpeedRepository _repository;
            public GetMttPaymentSpeedByIdQueryHandler(IImtMttPaymentSpeedRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<MttPaymentSpeed>> Handle(GetMttPaymentSpeedByIdQuery request, CancellationToken cancellationToken)
            {
                var message = new MessageResponse("Record not found");

                var mttPaymentSpeed = _repository.View(request.id);

                if (mttPaymentSpeed == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                else
                {
                    return mttPaymentSpeed;
                }
            }
        }
    }
}
