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
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Common.Constants.Routes;

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

    public class UpdateCurrencyValidator : AbstractValidator<UpdateCurrencyCommand>
    {
        public UpdateCurrencyValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Currency ID is required");
            RuleFor(x => x.Code).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("IsoCodeShort cannot be empty");
            RuleFor(x => x.IsoCode).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("iso_code cannot be empty");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(100).WithMessage("name cannot be empty");
            RuleFor(x => x.Symbol).NotEmpty().MinimumLength(1).MaximumLength(50).WithMessage("Symbol cannot be empty");
        }
    }

    public class UpdateCurrencyCommandHandler 
        : IRequestHandler<UpdateCurrencyCommand, ErrorOr<Currency>>
    {
        private readonly ICurrencyRepository _repository;
        public UpdateCurrencyCommandHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Currency>> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            Currency? entity = _repository.FindById(request.id);
            var now = DateTime.UtcNow;
            if (entity == null)
            {
                return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
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
            return _repository.Update(entity);
        }
    }
}
