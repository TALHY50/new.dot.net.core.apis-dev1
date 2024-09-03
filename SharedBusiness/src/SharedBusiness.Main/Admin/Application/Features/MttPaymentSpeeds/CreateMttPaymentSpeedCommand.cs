using ACL.Business.Infrastructure.Persistence.Context;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds
{
    //[Authorize]
    public record CreateMttPaymentSpeedCommand(
        uint mtt_id,
        uint processing_time,
        string gmt,
        DateTime opens_at,
        DateTime closes_at,
        string working_days,
        bool is_processing_during_banking_holiday,
        uint? company_id,
        StatusValues status
        ) : IRequest<ErrorOr<MttPaymentSpeed>>;

    public class CreateMttPaymentSpeedCommandValidator : AbstractValidator<CreateMttPaymentSpeedCommand>
    {
        public CreateMttPaymentSpeedCommandValidator()
        {
            RuleFor(v => v.processing_time).NotEmpty().MttPaymentSpeedProcessingTime();
            RuleFor(v => v.gmt).NotEmpty().MttPaymentSpeedGmt();
            RuleFor(v => v.working_days).NotEmpty().MttPaymentSpeedWorkingDays();
            RuleFor(v => v.is_processing_during_banking_holiday).NotEmpty().WithMessage("IsProcessingDuringBankingHoliday is bool");
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }

    public class CreateMttPaymentSpeedCommandHandler(IMTTRepository mtt_repository, ILogger<CreateMttPaymentSpeedCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IMTTPaymentSpeedRepository repository)
        : MttPaymentSpeedBaseCommand, IRequestHandler<CreateMttPaymentSpeedCommand, ErrorOr<MttPaymentSpeed>>
    {
        private readonly IMTTRepository _mtt_repository = mtt_repository;
        private readonly ILogger<CreateMttPaymentSpeedCommandHandler> _logger = logger;
        

        public async Task<ErrorOr<MttPaymentSpeed>> Handle(CreateMttPaymentSpeedCommand command, CancellationToken cancellationToken)
        {

            //var mttCheckExist = await _mtt_repository.GetByIdAsync(command.mtt_id);
            //if (mttCheckExist == null)
            //{
            //    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            //}
            var mttPaymentSpeed = new MttPaymentSpeed
            {
                MttId = command.mtt_id,
                ProcessingTime = command.processing_time,
                Gmt = command.gmt,
                OpensAt = command.opens_at,
                ClosesAt = command.closes_at,
                WorkingDays = command.working_days,
                IsProcessingDuringBankingHoliday = command.is_processing_during_banking_holiday,
                CompanyId = command.company_id,
                Status = (byte)command.status,
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await transactionHandler.ExecuteWithTransactionAsync<MttPaymentSpeed>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(mttPaymentSpeed, cancellationToken);
                    return obj;

                }, dbContext, 3, cancellationToken
            );

            if (result.IsError)
            {
                return result;
            }

            return result.Value;
        }
    }
}
