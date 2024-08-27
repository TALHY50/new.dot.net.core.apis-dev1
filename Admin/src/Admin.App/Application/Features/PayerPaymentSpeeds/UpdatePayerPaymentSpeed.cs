using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Domain.Entities;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class UpdatePayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdatePayerPaymentSpeedUrl, Name = Routes.UpdatePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Update(uint Id, UpdatePayerPaymentSpeedCommand command)
        {
            var commandWithId = command with { Id = Id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdatePayerPaymentSpeedCommand(
            uint Id,
            uint PayerId,
            sbyte Gmt,
            string WorkingDays,
            byte Status) : IRequest<ErrorOr<PayerPaymentSpeed>>;

        internal sealed class UpdatePayerPaymentSpeedCommandValidator : AbstractValidator<UpdatePayerPaymentSpeedCommand>
        {
            public UpdatePayerPaymentSpeedCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("PayerPaymentSpeed ID is required");
            }
        }

        internal sealed class UpdatePayerPaymentSpeedCommandHandler : IRequestHandler<UpdatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
        {
            private readonly IImtPayerPaymentSpeedRepository _repository;

            public UpdatePayerPaymentSpeedCommandHandler(IImtPayerPaymentSpeedRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<PayerPaymentSpeed>> Handle(UpdatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
            {
                PayerPaymentSpeed? payerPaymentSpeed = _repository.GetByUintId(command.Id);
                if (payerPaymentSpeed != null)
                {
                    payerPaymentSpeed.PayerId = command.PayerId;
                    payerPaymentSpeed.Gmt = command.Gmt;
                    payerPaymentSpeed.WorkingDays = command.WorkingDays;
                    payerPaymentSpeed.Status = command.Status;

                    //if (_user?.UserId != null)
                    //{
                    //    entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
                    //}
                    //else
                    //{
                    //    entity.UpdatedById = 1;
                    //}
                }

                return await _repository.UpdateAsync(payerPaymentSpeed);
            }
        }

    }
}
