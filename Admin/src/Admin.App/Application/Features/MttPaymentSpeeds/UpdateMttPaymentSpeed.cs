using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.MttPaymentSpeeds
{
    public class UpdateMttPaymentSpeedController : ApiControllerBase
    {
        [Tags("MttPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateMttPaymentSpeedUrl, Name = Routes.UpdateMttPaymentSpeedName)]
        public async Task<ActionResult<ErrorOr<MttPaymentSpeed>>> Update(uint id, UpdateMttPaymentSpeedCommand command)
        {
            var commandWithId = command with { id = id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }


        public record UpdateMttPaymentSpeedCommand(
            uint id,
            uint MttId,
            uint ProcessingTime,
            string Gmt,
            string WorkingDays,
            bool IsProcessingDuringBankingHoliday,
            uint? CompanyId,
            byte Status) : IRequest<ErrorOr<MttPaymentSpeed>>;


        public class UpdateMttPaymentSpeedCommandValidator : AbstractValidator<UpdateMttPaymentSpeedCommand>
        {
            public UpdateMttPaymentSpeedCommandValidator()
            {
                RuleFor(v => v.id)
                    .NotEmpty()
                    .WithMessage("MttId is required.");
                RuleFor(v => v.MttId)
                    .NotEmpty()
                    .WithMessage("MttId is required.");
                RuleFor(v => v.ProcessingTime)
                    .NotEmpty()
                    .WithMessage("ProcessingTime is required.");
                RuleFor(v => v.Gmt)
                    .NotEmpty()
                    .WithMessage("Gmt is required.");
                RuleFor(v => v.WorkingDays)
                    .NotEmpty()
                    .WithMessage("WorkingDays is required.");
                RuleFor(v => v.IsProcessingDuringBankingHoliday)
                    .NotEmpty()
                    .WithMessage("IsProcessingDuringBankingHoliday is required.");
                RuleFor(v => v.Status)
                    .NotEmpty()
                    .WithMessage("Status is required.");
            }
        }


        public class UpdateMttPaymentSpeedCommandHandler
        : IRequestHandler<UpdateMttPaymentSpeedCommand, ErrorOr<MttPaymentSpeed>>
        {
            private readonly ICurrentUser _user;
            private readonly IMTTPaymentSpeedRepository _repository;
            private readonly IMTTRepository _mtt_repository;

            public UpdateMttPaymentSpeedCommandHandler(ICurrentUser user, IMTTPaymentSpeedRepository repository, IMTTRepository mtt_repository)
            {
                _user = user;
                _repository = repository;
                _mtt_repository = mtt_repository;
            }

            public async Task<ErrorOr<MttPaymentSpeed>> Handle(UpdateMttPaymentSpeedCommand request, CancellationToken cancellationToken)
            {
                var message = new MessageResponse("Record not found");

                var now = DateTime.UtcNow;
                MttPaymentSpeed? mttPaymentSpeed = _repository.View(request.id);
                if (mttPaymentSpeed == null)
                {
                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                var mttCheckExist = _mtt_repository.GetByIdAsync(request.MttId);
                if (mttCheckExist == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "MttId not found!");
                }

                mttPaymentSpeed.MttId = request.MttId;
                mttPaymentSpeed.ProcessingTime = request.ProcessingTime;
                mttPaymentSpeed.Gmt = request.Gmt;
                mttPaymentSpeed.OpensAt = now;
                mttPaymentSpeed.ClosesAt = now;
                mttPaymentSpeed.WorkingDays = request.WorkingDays;
                mttPaymentSpeed.IsProcessingDuringBankingHoliday = request.IsProcessingDuringBankingHoliday;
                mttPaymentSpeed.CompanyId = request.CompanyId ?? 0;
                mttPaymentSpeed.Status = request.Status;
                mttPaymentSpeed.CreatedById = 1;
                mttPaymentSpeed.UpdatedById = 2;
                mttPaymentSpeed.CreatedAt = now;
                mttPaymentSpeed.UpdatedAt = now;



                return _repository.Update(mttPaymentSpeed);
            }
        }
    }
}
