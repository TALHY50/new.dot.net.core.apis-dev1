using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

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
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
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

        internal sealed class UpdateTaxRateCommandValidator : AbstractValidator<UpdateTaxRateCommand>
        {
            public UpdateTaxRateCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("TaxRate ID is required");
            }
        }

        internal sealed class UpdateTaxRateCommandHandler : IRequestHandler<UpdateTaxRateCommand, ErrorOr<TaxRate>>
        {
            private readonly IImtTaxRateRepository _repository;

            public UpdateTaxRateCommandHandler(IImtTaxRateRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<TaxRate>> Handle(UpdateTaxRateCommand command, CancellationToken cancellationToken)
            {
                TaxRate? taxRate = _repository.GetByUintId(command.Id);
                if (taxRate != null)
                {
                    taxRate.TaxType = command.TaxType;
                    taxRate.CorridorId = command.CorridorId;
                    taxRate.CountryId = command.CountryId;
                    taxRate.TaxCurrencyId = command.TaxCurrencyId;
                    taxRate.TaxPercentage = command.TaxPercentage;
                    taxRate.TaxFixed = command.TaxFixed;
                    taxRate.CompanyId = command.CompanyId;
                    taxRate.Status = command.Status;

                    //if (_user?.UserId != null)
                    //{
                    //    entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
                    //}
                    //else
                    //{
                    //    entity.UpdatedById = 1;
                    //}
                }

                return await _repository.UpdateAsync(taxRate!);
            }
        }
    }
}
