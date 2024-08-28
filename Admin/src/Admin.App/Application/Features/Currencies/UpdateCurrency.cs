using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using System.Reflection.Metadata;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Currencies
{
    public class UpdateCurrencyController : ApiControllerBase
    {
        [Tags("Currency")]
        //[Authorize]//(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateCurrencyUrl, Name = Routes.UpdateCurrencyName)]

        public async Task<ActionResult<ErrorOr<Currency>>> Update(uint id, UpdateCurrencyCommand command)
        {
            var commandWithId = command with { id = id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record UpdateCurrencyCommand(uint id,
    string? Code,
    string? IsoCode,
    string? Name,
    string? Symbol) : IRequest<ErrorOr<Currency>>;

    public class UpdateCurrencyValidator : AbstractValidator<GetCurrencyByIdQuery>
    {
        public UpdateCurrencyValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Currencyts ID is required");
        }
    }

    public class UpdateCurrencyCommandHandler 
        : IRequestHandler<UpdateCurrencyCommand, ErrorOr<Currency>>
    {
        private readonly IImtAdminCurrencyRepository _repository;
        public UpdateCurrencyCommandHandler(IImtAdminCurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Currency>> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            Currency? entity = _repository.GetByUintId(request.id);
            var now = DateTime.UtcNow;
            if (entity == null)
            {
                return Error.NotFound(description: "Currency not found!", code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            entity.Code = request.Code;
            entity.IsoCode = request.IsoCode;
            entity.Name = request.Name;
            entity.Symbol = request.Symbol;
            entity.CreatedById = 1;
            entity.UpdatedById = 2;
            entity.Status = 1;
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
            return await _repository.UpdateAsync(entity);
        }
    }
}
