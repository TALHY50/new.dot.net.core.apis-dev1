using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class UpdatePayerPaymentSpeedController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdatePayerPaymentSpeedUrl, Name = Routes.UpdatePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Update(UpdatePayerPaymentSpeedCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record UpdatePayerPaymentSpeedCommand(
            uint PayerId,
            sbyte Gmt,
            string WorkingDays
            ) : IRequest<ErrorOr<PayerPaymentSpeed>>;
        internal sealed class UpdatePayerPaymentSpeedCommandValidator : AbstractValidator<UpdatePayerPaymentSpeedCommand>
        {
            public UpdatePayerPaymentSpeedCommandValidator()
            {
                RuleFor(x => x.PayerId).NotEmpty().WithMessage("Payer Id is required");
                RuleFor(x => x.Gmt).NotEmpty().WithMessage("GMT is required");
                RuleFor(x => x.WorkingDays).NotEmpty().WithMessage("Working Days is required");
            }
        }

        internal sealed class UpdatePayerPaymentSpeedCommandHandler(ImtApplicationDbContext context) : IRequestHandler<UpdatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
        {
            private readonly ImtApplicationDbContext _context = context;

            public async Task<ErrorOr<PayerPaymentSpeed>> Handle(UpdatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
            {
                var payerPaymentSpeed = new PayerPaymentSpeed
                {
                    PayerId = command.PayerId,
                    //ProcessingTime = 1, //Processing time in minutes
                    Gmt = command.Gmt,
                    //OpenAt = DateTime.UtcNow, //Opening time
                    //CloseAt = DateTime.UtcNow, // Closing time
                    WorkingDays = command.WorkingDays, // CSV of weekdays (e.g., Monday,Tuesday)
                    IsProcessingDuringBankingHoliday = false, //0 = No, 1 = Yes
                   // CompanyId = 0, //
                 //   Status = 1, //0=inactive, 1=active, 2=pending, 3=rejected
                    //CreatedById = 1,
                    //UpdatedById = 1,
                   // CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                //_context.PayerPaymentSpeeds.Add(@PayerPaymentSpeed);

                //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return @payerPaymentSpeed;
            }
        }

    }
}
