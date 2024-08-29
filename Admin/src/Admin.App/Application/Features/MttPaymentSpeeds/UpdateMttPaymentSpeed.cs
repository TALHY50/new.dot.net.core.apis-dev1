using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Regions.UpdateRegionController;

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
            private readonly ICurrentUserService _user;
            private readonly IImtMttPaymentSpeedRepository _repository;
            private readonly IImtMttsRepository _mtt_repository;

            public UpdateMttPaymentSpeedCommandHandler(ICurrentUserService user, IImtMttPaymentSpeedRepository repository, IImtMttsRepository mtt_repository)
            {
                _user = user;
                _repository = repository;
                _mtt_repository = mtt_repository;
            }

            public async Task<ErrorOr<MttPaymentSpeed>> Handle(UpdateMttPaymentSpeedCommand request, CancellationToken cancellationToken)
            {
                var now = DateTime.UtcNow;
                MttPaymentSpeed? mttPaymentSpeed = _repository.View(request.id);
                if (mttPaymentSpeed == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "MttPaymentSpeed not found!");
                }

                var mttCheckExist = _mtt_repository.GetByUintId(request.MttId);
                if (mttCheckExist == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "MttId not found!");
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
