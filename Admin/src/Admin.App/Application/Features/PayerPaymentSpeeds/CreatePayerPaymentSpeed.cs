using ACL.App.Contracts.Responses;
using ADMIN.App.Application.Features.ServiceMethods;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class CreatePayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreatePayerPaymentSpeedUrl, Name = Routes.CreatePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Create(CreatePayerPaymentSpeedCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);return Ok(result);
        }
    }

    public record CreatePayerPaymentSpeedCommand(
        uint PayerId,
        string Gmt,
        string WorkingDays
        ) : IRequest<ErrorOr<PayerPaymentSpeed>>;

    public class CreatePayerPaymentSpeedCommandValidator : AbstractValidator<CreatePayerPaymentSpeedCommand>
    {
        public CreatePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.PayerId).NotEmpty().WithMessage("Payer Id is required");
            RuleFor(x => x.Gmt).NotEmpty().WithMessage("GMT is required");
            RuleFor(x => x.WorkingDays).NotEmpty().WithMessage("Working Days is required");
        }
    }

    public class CreatePayerPaymentSpeedCommandHandler : IRequestHandler<CreatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
    {
        private readonly IImtPayerPaymentSpeedRepository _repository;

        public CreatePayerPaymentSpeedCommandHandler(IImtPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<PayerPaymentSpeed>> Handle(CreatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            var payerPaymentSpeed = new PayerPaymentSpeed
            {
                PayerId = command.PayerId,
                ProcessingTime = 1, //Processing time in minutes
                Gmt = command.Gmt,
                OpenAt = DateTime.UtcNow, //Opening time
                CloseAt = DateTime.UtcNow, // Closing time
                WorkingDays = command.WorkingDays, // CSV of weekdays (e.g., Monday,Tuesday)
                IsProcessingDuringBankingHoliday = false, //0 = No, 1 = Yes
                CompanyId = 0, //
                Status = 1, //0=inactive, 1=active, 2=pending, 3=rejected
                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var message = new MessageResponse("Record not found");

            if (payerPaymentSpeed == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return _repository.Add(payerPaymentSpeed);
        }
    }
}
