﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Payers
{
    public class CreatePayerController : ApiControllerBase
    {
        [Tags("Payer")]
        //[Authorize]
        [HttpPost(Routes.CreatePayerUrl, Name = Routes.CreatePayerName)]
        public async Task<ActionResult<ErrorOr<Payer>>> Create(CreatePayerCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreatePayerCommand(
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

    public class CreatePayerCommandValidator : AbstractValidator<CreatePayerCommand>
    {
        public CreatePayerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name is required");
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

    public class CreatePayerCommandHandler 
        : IRequestHandler<CreatePayerCommand, ErrorOr<Payer>>
    {
        private readonly IPayerRepository _repository;
        public CreatePayerCommandHandler(IPayerRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Payer>> Handle(CreatePayerCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @payer = new Payer
            {
                Name = request.Name,
                ProviderId = request.ProviderId,
                CorridorId = request.CorridorId,
                InternalPayerId = request.InternalPayerId,
                FundCurrencyId = request.FundCurrencyId,
                Increment = request.Increment,
                MoneyPrecision = request.MoneyPrecision,
                ServiceMethodId = request.ServiceMethodId,
                TransactionTypeIds = request.TransactionTypeIds,
                SourceAmountMax = request.SourceAmountMax,
                SourceAmountMin = request.SourceAmountMin,
                DestinationAmountMax = request.DestinationAmountMax,
                DestinationAmountMin = request.DestinationAmountMin,
                CotCurrencyId = request.CotCurrencyId,
                CotPercentage = request.CotPercentage,
                CotFixed = request.CotFixed,
                FxSpread = request.FxSpread,
                PaymentSpeed = request.PaymentSpeed,
                CompanyId = request.CompanyId,
                Status = 1,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };
            return await _repository.AddAsync(@payer);
        }
    }
}