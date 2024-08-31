using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.MttPaymentSpeeds
{
    public class CreateMttPaymentSpeedController : ApiControllerBase
    {
        [Tags("MttPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateMttPaymentSpeedUrl, Name = Routes.CreateMttPaymentSpeedName)]
        public async Task<ActionResult<ErrorOr<MttPaymentSpeed>>> Create(CreateMttPaymentSpeedCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateMttPaymentSpeedCommand(
        uint MttId,
        uint ProcessingTime,
        string Gmt,
        string WorkingDays,
        bool IsProcessingDuringBankingHoliday,
        uint? CompanyId,
        byte Status) : IRequest<ErrorOr<MttPaymentSpeed>>;


    public class CreateMttPaymentSpeedCommandValidator : AbstractValidator<CreateMttPaymentSpeedCommand>
    {
        public CreateMttPaymentSpeedCommandValidator()
        {
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


    public class CreateMttPaymentSpeedCommandHandler
        : IRequestHandler<CreateMttPaymentSpeedCommand, ErrorOr<MttPaymentSpeed>>
    {
        private readonly IMTTPaymentSpeedRepository _repository;
        private readonly IMTTRepository _mtt_repository;
        public CreateMttPaymentSpeedCommandHandler(IMTTPaymentSpeedRepository repository, IMTTRepository mtt_repository)
        {
            _repository = repository;
            _mtt_repository = mtt_repository;
        }

        public async Task<ErrorOr<MttPaymentSpeed>> Handle(CreateMttPaymentSpeedCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");

            var now = DateTime.UtcNow;
            var mttCheckExist = _mtt_repository.View(request.MttId);
            if (mttCheckExist == null)
            {
                return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            var @mttPaymentSpeed = new MttPaymentSpeed
            {
                MttId = request.MttId,
                ProcessingTime = request.ProcessingTime,
                Gmt = request.Gmt,
                OpensAt = now,
                ClosesAt = now,
                WorkingDays = request.WorkingDays,
                IsProcessingDuringBankingHoliday = request.IsProcessingDuringBankingHoliday,
                CompanyId = request.CompanyId ?? 0,
                Status = request.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now
            };

            return _repository.Add(@mttPaymentSpeed);
        }
    }
}
