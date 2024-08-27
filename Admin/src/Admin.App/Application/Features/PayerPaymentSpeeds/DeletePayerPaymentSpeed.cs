using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class DeletePayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeletePayerPaymentSpeedUrl, Name = Routes.DeletePayerPaymentSpeedName)]

        public async Task<ActionResult<bool>> Delete(DeletePayerPaymentSpeedCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record DeletePayerPaymentSpeedCommand(uint Id) : IRequest<bool>;

    internal sealed class DeletePayerPaymentSpeedCommandValidator : AbstractValidator<DeletePayerPaymentSpeedCommand>
    {
        public DeletePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    internal sealed class DeletePayerPaymentSpeedCommandHandler: IRequestHandler<DeletePayerPaymentSpeedCommand, bool>
    {
        private readonly IImtPayerPaymentSpeedRepository _repository;

        public DeletePayerPaymentSpeedCommandHandler(IImtPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var payerPaymentSpeed = _repository.GetByUintId(command.Id);

                if (payerPaymentSpeed != null)
                {
                    return await _repository.DeleteAsync(payerPaymentSpeed);
                }

                return await _repository.DeleteAsync(payerPaymentSpeed);
            }

            return false;
        }
    }
}
