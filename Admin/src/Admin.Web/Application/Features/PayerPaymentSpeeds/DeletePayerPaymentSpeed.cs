using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.PayerPaymentSpeeds
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
        private readonly IPayerPaymentSpeedRepository _repository;

        public DeletePayerPaymentSpeedCommandHandler(IPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var payerPaymentSpeed = await _repository.GetByIdAsync(command.Id);

                if (payerPaymentSpeed == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Payer Payment Speed not found!");
                }
                
                 await _repository.DeleteAsync(payerPaymentSpeed);
                return true;
            }

            return false;
        }
    }
}
