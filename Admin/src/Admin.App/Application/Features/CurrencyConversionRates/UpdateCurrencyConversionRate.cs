using ACL.Business.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.CurrencyConversionRates
{
    public class UpdateCurrencyConversionRateController : ApiControllerBase
    {
        [Tags("CurrencyConversionRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateCurrencyConversionRateUrl, Name = Routes.UpdateCurrencyConversionRateName)]

        public async Task<ActionResult<ErrorOr<CurrencyConversionRate>>> Update(uint Id, UpdateCurrencyConversionRateCommand command)
        {
            var commandWithId = command with { Id = Id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdateCurrencyConversionRateCommand(
            uint Id,
            uint CorridorId,
            decimal ExchangeRate,
            decimal FxSpread,
            uint? CompanyId,
            byte Status) : IRequest<ErrorOr<CurrencyConversionRate>>;

        public class UpdateCurrencyConversionRateCommandValidator : AbstractValidator<UpdateCurrencyConversionRateCommand>
        {
            public UpdateCurrencyConversionRateCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("CurrencyConversionRate ID is required");
                RuleFor(x => x.CorridorId).NotEmpty().WithMessage("CorridorId Code  is required");
                RuleFor(x => x.ExchangeRate).NotEmpty().WithMessage("ExchangeRate Code  is required");
                RuleFor(x => x.FxSpread).NotEmpty().WithMessage("FxSpread Code  is required");
            }
        }

        public class UpdateCurrencyConversionRateCommandHandler : IRequestHandler<UpdateCurrencyConversionRateCommand, ErrorOr<CurrencyConversionRate>>
        {
            private readonly ICurrencyConversionRateRepository _repository;

            public UpdateCurrencyConversionRateCommandHandler(ICurrencyConversionRateRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<CurrencyConversionRate>> Handle(UpdateCurrencyConversionRateCommand command, CancellationToken cancellationToken)
            {
                CurrencyConversionRate? currencyConversionRate = _repository.View(command.Id);
                if (currencyConversionRate != null)
                {
                    currencyConversionRate.CorridorId = command.CorridorId;
                    currencyConversionRate.ExchangeRate = command.ExchangeRate;
                    currencyConversionRate.FxSpread = command.FxSpread;
                    currencyConversionRate.CompanyId = command.CompanyId;
                    currencyConversionRate.Status = command.Status;
                    currencyConversionRate.UpdatedById = command.Id;
                    currencyConversionRate.UpdatedAt = DateTime.UtcNow;

                    return _repository.Update(currencyConversionRate)!;
                }
                else
                {
                    return Error.NotFound(description: Language.GetMessage("Record not found"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
            }
        }
    }
}
