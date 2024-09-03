using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.PayerPaymentSpeeds
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

        public CreatePayerPaymentSpeedController(ILogger<CreatePayerPaymentSpeedController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
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
            RuleFor(x => x.PayerId).NotEmpty().WithMessage("Payer id is required");
            RuleFor(x => x.Gmt).NotEmpty().WithMessage("GMT is required");
            RuleFor(x => x.WorkingDays).NotEmpty().WithMessage("Working Days is required");
        }
    }

    public class CreatePayerPaymentSpeedCommandHandler : IRequestHandler<CreatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
    {
        private readonly IPayerPaymentSpeedRepository _repository;

        public CreatePayerPaymentSpeedCommandHandler(IPayerPaymentSpeedRepository repository)
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

            if (payerPaymentSpeed == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Payer Payment Speed not found!");
            }

            return await _repository.AddAsync(payerPaymentSpeed);
        }
    }
}
