using ACL.Business.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.MttPaymentSpeeds.DeleteMttPaymentSpeedController;

namespace Admin.App.Application.Features.MttPaymentSpeeds
{
    public class DeleteMttPaymentSpeedController : ApiControllerBase
    {
        [Tags("MttPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteMttPaymentSpeedUrl, Name = Routes.DeleteMttPaymentSpeedName)]
        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
        {

            var result = await Mediator.Send(new DeleteMttPaymentSpeedCommand(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }


        public record DeleteMttPaymentSpeedCommand(uint id)
            : IRequest<ErrorOr<bool>>;

        public class DeleteMttPaymentSpeedCommandValidator : AbstractValidator<DeleteMttPaymentSpeedCommand>
        {
            public DeleteMttPaymentSpeedCommandValidator()
            {
                RuleFor(r => r.id)
                    .NotEmpty()
                    .WithMessage("ID is required");
            }
        }

        public class DeleteMttPaymentSpeedCommandHandler
        : IRequestHandler<DeleteMttPaymentSpeedCommand, ErrorOr<bool>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtMttPaymentSpeedRepository _repository;
            public DeleteMttPaymentSpeedCommandHandler(ICurrentUserService user, IImtMttPaymentSpeedRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<ErrorOr<bool>> Handle(DeleteMttPaymentSpeedCommand request, CancellationToken cancellationToken)
            {
                var message = new MessageResponse("Record not found");

                var mttPaymentSpeeds = _repository.View(request.id);

                if (mttPaymentSpeeds == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(mttPaymentSpeeds);
            }
        }
    }
}

