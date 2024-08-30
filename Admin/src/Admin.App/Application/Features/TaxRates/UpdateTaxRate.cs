using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.TaxRates
{
    public class UpdateTaxRateController : ApiControllerBase
    {
        [Tags("TaxRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateTaxRateUrl, Name = Routes.UpdateTaxRateName)]

        public async Task<ActionResult<ErrorOr<TaxRate>>> Update(uint Id, UpdateTaxRateCommand command)
        {
            var commandWithId = command with { Id = Id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdateTaxRateCommand(
            uint Id,
            byte TaxType,
            uint? CorridorId,
            uint? CountryId,
            uint? TaxCurrencyId,
            decimal TaxPercentage,
            decimal TaxFixed,
            uint? CompanyId,
            byte Status) : IRequest<ErrorOr<TaxRate>>;

        public class UpdateTaxRateCommandValidator : AbstractValidator<UpdateTaxRateCommand>
        {
            public UpdateTaxRateCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("TaxRate ID is required");
            }
        }

        public class UpdateTaxRateCommandHandler : IRequestHandler<UpdateTaxRateCommand, ErrorOr<TaxRate>>
        {
            private readonly IImtTaxRateRepository _repository;

            public UpdateTaxRateCommandHandler(IImtTaxRateRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<TaxRate>> Handle(UpdateTaxRateCommand command, CancellationToken cancellationToken)
            {
                TaxRate? taxRate = _repository.View(command.Id);
                if (taxRate == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Tax Rate not found!");
                }
                taxRate.TaxType = command.TaxType;
                taxRate.CorridorId = command.CorridorId;
                taxRate.CountryId = command.CountryId;
                taxRate.TaxCurrencyId = command.TaxCurrencyId;
                taxRate.TaxPercentage = command.TaxPercentage;
                taxRate.TaxFixed = command.TaxFixed;
                taxRate.CompanyId = command.CompanyId;
                taxRate.Status = command.Status;

                return _repository.Update(taxRate)!;
            }
        }
    }
}
