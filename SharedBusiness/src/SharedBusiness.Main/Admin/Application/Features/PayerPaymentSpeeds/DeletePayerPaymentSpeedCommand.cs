using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds
{
    public record DeletePayerPaymentSpeedCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeletePayerPaymentSpeedCommandValidator : AbstractValidator<DeletePayerPaymentSpeedCommand>
    {
        public DeletePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeletePayerPaymentSpeedCommandHandler : PayerPaymentSpeedBase, IRequestHandler<DeletePayerPaymentSpeedCommand, ErrorOr<bool>>
    {
        private readonly IPayerPaymentSpeedRepository _repository;

        public DeletePayerPaymentSpeedCommandHandler(IPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var payerPaymentSpeed = await _repository.GetByIdAsync(command.id);

                if (payerPaymentSpeed == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(payerPaymentSpeed, cancellationToken);

            }

            return true;
        }
    }
}
