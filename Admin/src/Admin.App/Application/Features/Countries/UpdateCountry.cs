using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Countries
{
    public class UpdateCountryController : ApiControllerBase
    {
        [Tags("Country")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateCountryUrl, Name = Routes.UpdateCountryName)]

        public async Task<ActionResult<ErrorOr<Country>>> Update(uint Id, UpdateCountryCommand command)
        {
            var commandWithId = command with { Id = Id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdateCountryCommand(
            uint Id,
            string? Code,
            string? IsoCode,
            string? Name,
            byte Status) : IRequest<ErrorOr<Country>>;

        public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
        {
            public UpdateCountryCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
                RuleFor(x => x.Code).NotEmpty().WithMessage("Country Code  is required");
                RuleFor(x => x.IsoCode).NotEmpty().WithMessage("Country Code  is required");
                RuleFor(x => x.Name).NotEmpty().WithMessage("Country Code  is required");
            }
        }

        public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, ErrorOr<Country>>
        {
            private readonly IAdminCountryRepository _repository;

            public UpdateCountryCommandHandler(IAdminCountryRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<Country>> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
            {
                Country? country = _repository.View(command.Id);
                var message = new MessageResponse("Record not found");
                if (country != null)
                {
                    country.Code = command.Code;
                    country.IsoCode = command.IsoCode;
                    country.Name = command.Name;
                    country.Status = command.Status;
                    country.UpdatedById = command.Id;
                    country.UpdatedAt = DateTime.UtcNow;
                    
                    return _repository.Update(country)!;
                }
                else
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
            }
        }
    }
}
