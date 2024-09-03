using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds
{
    public record DeleteMttPaymentSpeedByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteMttPaymentSpeedByIdCommandValidator : AbstractValidator<DeleteMttPaymentSpeedByIdCommand>
    {
        public DeleteMttPaymentSpeedByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteMttPaymentSpeedByIdCommandHandler : MttPaymentSpeedBaseCommand, IRequestHandler<DeleteMttPaymentSpeedByIdCommand, ErrorOr<bool>>
    {
        private readonly IMTTPaymentSpeedRepository _repository;

        public DeleteMttPaymentSpeedByIdCommandHandler(IMTTPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteMttPaymentSpeedByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var mttPaymentSpeed = await _repository.GetByIdAsync(command.id);

                if (mttPaymentSpeed == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(mttPaymentSpeed, cancellationToken);

            }

            return true;
        }
    }
}
