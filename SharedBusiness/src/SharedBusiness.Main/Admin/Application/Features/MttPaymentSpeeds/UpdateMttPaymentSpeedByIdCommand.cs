using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds
{
    public record UpdateMttPaymentSpeedByIdCommand(
        uint id,
        uint mtt_id,
        uint processing_time,
        string gmt,
        DateTime opens_at,
        DateTime closes_at,
        string working_days,
        bool is_processing_during_banking_holiday,
        uint? company_id,
        StatusValues status) : IRequest<ErrorOr<MttPaymentSpeed>>;


    public class UpdateMttPaymentSpeedByIdCommandValidator : AbstractValidator<UpdateMttPaymentSpeedByIdCommand>
    {
        public UpdateMttPaymentSpeedByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("MttPaymentSpeed ID is required");
            RuleFor(v => v.processing_time).NotEmpty().MttPaymentSpeedProcessingTime();
            RuleFor(v => v.gmt).NotEmpty().MttPaymentSpeedGmt();
            RuleFor(v => v.working_days).NotEmpty().MttPaymentSpeedWorkingDays();
            RuleFor(v => v.is_processing_during_banking_holiday).NotEmpty().WithMessage("IsProcessingDuringBankingHoliday is bool");
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }

    public class UpdateMttPaymentSpeedByIdCommandHandler : MttPaymentSpeedBaseCommand, IRequestHandler<UpdateMttPaymentSpeedByIdCommand, ErrorOr<MttPaymentSpeed>>
    {
        private readonly IMTTPaymentSpeedRepository _repository;
        private readonly IMTTRepository _mTTRepository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateMttPaymentSpeedByIdCommandHandler(IMTTPaymentSpeedRepository repository, IMTTRepository mTTRepository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _mTTRepository = mTTRepository;
            _guard = guard;
        }

        public async Task<ErrorOr<MttPaymentSpeed>> Handle(UpdateMttPaymentSpeedByIdCommand command, CancellationToken cancellationToken)
        {
            MttPaymentSpeed? mttPaymentSpeed = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (mttPaymentSpeed == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }
            //var mttCheckExist = _mTTRepository.GetByIdAsync(command.mtt_id);
            //if (mttCheckExist == null)
            //{
            //    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            //}


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.MttId = value, command.mtt_id);
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.ProcessingTime = value, command.processing_time);
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.Gmt = value, command.gmt);
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.OpensAt = value, command.opens_at);
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.ClosesAt = value, command.closes_at);
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.WorkingDays = value, command.working_days);
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.IsProcessingDuringBankingHoliday = value, command.is_processing_during_banking_holiday);
            _guard.UpdateIfNotNullOrEmpty(value => mttPaymentSpeed.CompanyId = value, command.company_id);


            mttPaymentSpeed.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(mttPaymentSpeed, cancellationToken);

            return mttPaymentSpeed;


        }

    }
}
