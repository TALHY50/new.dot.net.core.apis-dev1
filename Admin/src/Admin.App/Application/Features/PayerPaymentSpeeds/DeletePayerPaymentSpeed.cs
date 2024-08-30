using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class DeletePayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeletePayerPaymentSpeedUrl, Name = Routes.DeletePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint Id)
        {
            var result = await Mediator.Send(new DeletePayerPaymentSpeedCommand(Id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeletePayerPaymentSpeedCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeletePayerPaymentSpeedCommandValidator : AbstractValidator<DeletePayerPaymentSpeedCommand>
    {
        public DeletePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    public class DeletePayerPaymentSpeedCommandHandler: IRequestHandler<DeletePayerPaymentSpeedCommand, ErrorOr<bool>>
    {
        private readonly IImtPayerPaymentSpeedRepository _repository;

        public DeletePayerPaymentSpeedCommandHandler(IImtPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var payerPaymentSpeed = _repository.View(command.Id);

                if (payerPaymentSpeed == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Payer Payment Speed not found!");
                }
                
                return _repository.Delete(payerPaymentSpeed);
            }

            return false;
        }
    }
}
