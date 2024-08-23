using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class DeletePayerPaymentSpeedController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeletePayerPaymentSpeedUrl, Name = Routes.DeletePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Delete(DeletePayerPaymentSpeedCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record DeletePayerPaymentSpeedCommand(int Id) : IRequest<ErrorOr<PayerPaymentSpeed>>;

    internal sealed class DeletePayerPaymentSpeedCommandValidator : AbstractValidator<DeletePayerPaymentSpeedCommand>
    {
        public DeletePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    internal sealed class DeletePayerPaymentSpeedCommandHandler: IRequestHandler<DeletePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
    {
        private readonly IImtPayerPaymentSpeedRepository _repository;

        public DeletePayerPaymentSpeedCommandHandler(IImtPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<PayerPaymentSpeed>> Handle(DeletePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
