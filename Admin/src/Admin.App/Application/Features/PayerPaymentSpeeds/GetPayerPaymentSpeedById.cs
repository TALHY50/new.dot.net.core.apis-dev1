using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedByIdController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetPayerPaymentSpeedByIdUrl, Name = Routes.GetPayerPaymentSpeedByIdName)]
        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> GetById(uint Id)
        {
            var result = await Mediator.Send(new GetPayerPaymentSpeedByIdQuery(Id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);return Ok(result);
        }

        public record GetPayerPaymentSpeedByIdQuery(uint Id) : IRequest<ErrorOr<PayerPaymentSpeed>>;

        public class GetPayerPaymentSpeedByIdValidator : AbstractValidator<GetPayerPaymentSpeedByIdQuery>
        {
            public GetPayerPaymentSpeedByIdValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
            }
        }

        public class GetPayerPaymentSpeedByIdQueryHandler : IRequestHandler<GetPayerPaymentSpeedByIdQuery, ErrorOr<PayerPaymentSpeed>>
        {
            private readonly IImtPayerPaymentSpeedRepository _repository;

            public GetPayerPaymentSpeedByIdQueryHandler(IImtPayerPaymentSpeedRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<PayerPaymentSpeed>> Handle(GetPayerPaymentSpeedByIdQuery request, CancellationToken cancellationToken)
            {
                var payerPaymentSpeed = _repository.View(request.Id);

                if (payerPaymentSpeed == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Payer Payment Speed not found!");
                }

                return payerPaymentSpeed;
            }
        }
    }
}
