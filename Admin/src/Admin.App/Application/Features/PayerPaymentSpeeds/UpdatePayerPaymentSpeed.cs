﻿using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

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
                RuleFor(x => x.PayerId).NotEmpty().WithMessage("Payer Id is required");
                RuleFor(x => x.Gmt).NotEmpty().WithMessage("GMT is required");
                RuleFor(x => x.WorkingDays).NotEmpty().WithMessage("Working Days is required");
            }
        }

        public class UpdatePayerPaymentSpeedCommandHandler : IRequestHandler<UpdatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
        {
            private readonly IImtPayerPaymentSpeedRepository _repository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public UpdatePayerPaymentSpeedCommandHandler(IHttpContextAccessor httpContextAccessor, IImtPayerPaymentSpeedRepository repository)
            {
                _httpContextAccessor = httpContextAccessor;
                _repository = repository;
            }

            public async Task<ErrorOr<PayerPaymentSpeed>> Handle(UpdatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
            {
                PayerPaymentSpeed? payerPaymentSpeed = _repository.View(command.Id);
                if (payerPaymentSpeed != null)
                {
                    payerPaymentSpeed.PayerId = command.PayerId;
                    payerPaymentSpeed.Gmt = command.Gmt;
                    payerPaymentSpeed.WorkingDays = command.WorkingDays;
                    payerPaymentSpeed.Status = command.Status;
                    payerPaymentSpeed.UpdatedById = command.Id;
                    payerPaymentSpeed.UpdatedAt = DateTime.UtcNow;
                }

                var message = new MessageResponse("Record not found");
                if (payerPaymentSpeed == null)
                {
                    return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Update(payerPaymentSpeed)!;
            }
        }

    }
}
