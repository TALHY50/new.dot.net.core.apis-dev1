using ADMIN.App.Application.Features.ServiceMethods;
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
    public class CreatePayerPaymentSpeedController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreatePayerPaymentSpeedUrl, Name = Routes.CreatePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Create(CreatePayerPaymentSpeedCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreatePayerPaymentSpeedCommand(PayerPaymentSpeed PayerPaymentSpeed) : IRequest<ErrorOr<PayerPaymentSpeed>>;

    internal sealed class CreatePayerPaymentSpeedCommandValidator : AbstractValidator<CreatePayerPaymentSpeedCommand>
    {
        public CreatePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.PayerPaymentSpeed.PayerId).NotEmpty().WithMessage("Payer Id is required");
            RuleFor(x => x.PayerPaymentSpeed.Gmt).NotEmpty().WithMessage("GMT is required");
            RuleFor(x => x.PayerPaymentSpeed.WorkingDays).NotEmpty().WithMessage("Working Days is required");
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
                PayerId = command.PayerPaymentSpeed.PayerId,
                ProcessingTime = 1, //Processing time in minutes
                Gmt = command.PayerPaymentSpeed.Gmt,
                OpenAt = DateTime.UtcNow, //Opening time
                CloseAt = DateTime.UtcNow, // Closing time
                WorkingDays = command.PayerPaymentSpeed.WorkingDays, // CSV of weekdays (e.g., Monday,Tuesday)
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

            return _repository.AddAsync(payerPaymentSpeed).Result;
        }
    }
}
