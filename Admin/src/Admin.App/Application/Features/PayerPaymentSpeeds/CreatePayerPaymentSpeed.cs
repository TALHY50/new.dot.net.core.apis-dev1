using ADMIN.App.Application.Features.ServiceMethods;
using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class CreatePayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreatePayerPaymentSpeedUrl, Name = Routes.CreatePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Create(CreatePayerPaymentSpeedCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreatePayerPaymentSpeedCommand(
        uint PayerId,
        sbyte Gmt,
        string WorkingDays
        ) : IRequest<ErrorOr<PayerPaymentSpeed>>;

    internal sealed class CreatePayerPaymentSpeedCommandValidator : AbstractValidator<CreatePayerPaymentSpeedCommand>
    {
        public CreatePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.PayerId).NotEmpty().WithMessage("Payer Id is required");
            RuleFor(x => x.Gmt).NotEmpty().WithMessage("GMT is required");
            RuleFor(x => x.WorkingDays).NotEmpty().WithMessage("Working Days is required");
        }
    }

    internal sealed class CreatePayerPaymentSpeedCommandHandler : IRequestHandler<CreatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
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

            //_context.PayerPaymentSpeed.Add(@payerPaymentSpeed);

            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            //return @payerPaymentSpeed;

            return await _repository.AddAsync(payerPaymentSpeed);
        }
    }
}
