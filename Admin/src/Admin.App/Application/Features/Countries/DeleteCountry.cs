using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Countries
{
    public class DeleteCountryController : ApiControllerBase
    {
        [Tags("Country")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteCountryUrl, Name = Routes.DeleteCountryName)]

        public async Task<ActionResult<ErrorOr<bool>>> Delete(DeleteCountryCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeleteCountryCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
        }
    }

    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, ErrorOr<bool>>
    {
        private readonly IAdminCountryRepository _repository;

        public DeleteCountryCommandHandler(IAdminCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            if(command.Id > 0)
            {
                var country = _repository.GetByUintId(command.Id);

                if (country == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Country not found!");
                }

               return await _repository.DeleteAsync(country);
            }

            return false;
        }
    }
}
