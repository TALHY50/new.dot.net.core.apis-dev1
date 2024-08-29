using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Payers
{
    public class UpdatePayerController : ApiControllerBase
    {
        [Tags("Payer")]
        [HttpPut(Routes.UpdatePayerUrl, Name = Routes.UpdatePayerName)]
        public async Task<ActionResult<ErrorOr<Payer>>> UpdatePayer(uint id, UpdatePayerCommand command)
        {
            var commandWithId = command with { id = id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record UpdatePayerCommand(
        uint id,
        string Name,
        uint? ProviderId,
        uint? CorridorId,
        string InternalPayerId,
        uint? FundCurrencyId,
        decimal Increment,
        byte MoneyPrecision,
        uint? ServiceMethodId,
        string TransactionTypeIds,
        decimal SourceAmountMax,
        decimal SourceAmountMin,
        decimal DestinationAmountMax,
        decimal DestinationAmountMin,
        uint? CotCurrencyId,
        decimal CotPercentage,
        decimal CotFixed,
        decimal FxSpread,
        string PaymentSpeed,
        uint? CompanyId) : IRequest<ErrorOr<Payer>>;

    public class UpdateCommandValidator : AbstractValidator<UpdatePayerCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.InternalPayerId).NotEmpty().WithMessage("InternalPayerId is required");
            RuleFor(x => x.Increment).NotEmpty().WithMessage("Increment is required");
            RuleFor(x => x.MoneyPrecision).NotEmpty().WithMessage("MoneyPrecision is required");
            RuleFor(x => x.TransactionTypeIds).NotEmpty().WithMessage("TransactionTypeIds is required");
            RuleFor(x => x.SourceAmountMax).NotEmpty().WithMessage("SourceAmountMax is required");
            RuleFor(x => x.SourceAmountMin).NotEmpty().WithMessage("SourceAmountMin is required");
            RuleFor(x => x.DestinationAmountMax).NotEmpty().WithMessage("DestinationAmountMax is required");
            RuleFor(x => x.DestinationAmountMin).NotEmpty().WithMessage("DestinationAmountMin is required");
            RuleFor(x => x.CotPercentage).NotEmpty().WithMessage("CotPercentage is required");
            RuleFor(x => x.CotFixed).NotEmpty().WithMessage("CotFixed is required");
            RuleFor(x => x.FxSpread).NotEmpty().WithMessage("FxSpread is required");
            RuleFor(x => x.PaymentSpeed).NotEmpty().WithMessage("PaymentSpeed is required");
        }
    }
    public class UpdatePayerHandler :
        IRequestHandler<UpdatePayerCommand, ErrorOr<Payer>>
    {
        private readonly IImtPayerRepository _repository;
        public UpdatePayerHandler(IImtPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Payer>> Handle(UpdatePayerCommand request, CancellationToken cancellationToken)
        {
            Payer? entity = _repository.FindById(request.id);
            var now = DateTime.UtcNow;
            if (entity == null)
            {
                return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Payer not found!");
            }
            entity.Name = request.Name;
            entity.ProviderId = request.ProviderId;
            entity.CorridorId = request.CorridorId;
            entity.InternalPayerId = request.InternalPayerId;
            entity.FundCurrencyId = request.FundCurrencyId;
            entity.Increment = request.Increment;
            entity.MoneyPrecision = request.MoneyPrecision;
            entity.ServiceMethodId = request.ServiceMethodId;
            entity.TransactionTypeIds = request.TransactionTypeIds;
            entity.SourceAmountMax = request.SourceAmountMax;
            entity.SourceAmountMin = request.SourceAmountMin;
            entity.DestinationAmountMax = request.DestinationAmountMax;
            entity.DestinationAmountMin = request.DestinationAmountMin;
            entity.CotCurrencyId = request.CotCurrencyId;
            entity.CotPercentage = request.CotPercentage;
            entity.CotFixed = request.CotFixed;
            entity.FxSpread = request.FxSpread;
            entity.PaymentSpeed = request.PaymentSpeed;
            entity.CompanyId = request.CompanyId;
            entity.Status = 1;
            entity.CreatedById = 1;
            entity.UpdatedById = 2;
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
            return _repository.Update(entity);
        }
    }
}
