using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.PayerPaymentSpeeds
{
    public class UpdatePayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdatePayerPaymentSpeedUrl, Name = Routes.UpdatePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Update(uint Id, UpdatePayerPaymentSpeedCommand command)
        {
            var commandWithId = command with { Id = Id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdatePayerPaymentSpeedCommand(
            uint Id,
            uint PayerId,
            string Gmt,
            string WorkingDays,
            byte Status) : IRequest<ErrorOr<PayerPaymentSpeed>>;

        public class UpdatePayerPaymentSpeedCommandValidator : AbstractValidator<UpdatePayerPaymentSpeedCommand>
        {
            public UpdatePayerPaymentSpeedCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("PayerPaymentSpeed ID is required");
                RuleFor(x => x.PayerId).NotEmpty().WithMessage("Payer id is required");
                RuleFor(x => x.Gmt).NotEmpty().WithMessage("GMT is required");
                RuleFor(x => x.WorkingDays).NotEmpty().WithMessage("Working Days is required");
            }
        }

        public class UpdatePayerPaymentSpeedCommandHandler : IRequestHandler<UpdatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
        {
            private readonly IPayerPaymentSpeedRepository _repository;

            public UpdatePayerPaymentSpeedCommandHandler(IPayerPaymentSpeedRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<PayerPaymentSpeed>> Handle(UpdatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
            {
                PayerPaymentSpeed? payerPaymentSpeed = await _repository.GetByIdAsync(command.Id);
                if (payerPaymentSpeed != null)
                {
                    payerPaymentSpeed.PayerId = command.PayerId;
                    payerPaymentSpeed.Gmt = command.Gmt;
                    payerPaymentSpeed.WorkingDays = command.WorkingDays;
                    payerPaymentSpeed.Status = command.Status;
                    payerPaymentSpeed.UpdatedById = command.Id;
                    payerPaymentSpeed.UpdatedAt = DateTime.UtcNow;
                }

                if (payerPaymentSpeed == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Payer Payment Speed not found!");
                }

                 await _repository.UpdateAsync(payerPaymentSpeed);
                return payerPaymentSpeed;
            }
        }

    }
}
