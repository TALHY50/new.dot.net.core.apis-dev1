using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.Countries
{
    public class UpdateCountryController : ApiControllerBase
    {
        [Tags("Country")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateCountryUrl, Name = Routes.UpdateCountryName)]

        public async Task<ActionResult<ErrorOr<Country>>> Update(int Id, UpdateCountryCommand command)
        {
            var commandWithId = command with { Id = Id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateCountryCommand(
            int Id,
            string? Code,
            string? IsoCode,
            string? Name,
            sbyte Status) : IRequest<ErrorOr<Country>>;

        internal sealed class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
        {
            public UpdateCountryCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
            }
        }

        internal sealed class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, ErrorOr<Country>>
        {
            private readonly IAdminCountryRepository _repository;

            public UpdateCountryCommandHandler(IAdminCountryRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<Country>> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
            {
                Country? country = _repository.GetByIntId(command.Id);
                if (country != null)
                {
                    country.Code = command.Code;
                    country.IsoCode = command.IsoCode;
                    country.Name = command.Name;
                    country.Status = command.Status;
                    
                    //if (_user?.UserId != null)
                    //{
                    //    entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
                    //}
                    //else
                    //{
                    //    entity.UpdatedById = 1;
                    //}
                }

                return await _repository.UpdateAsync(country);
            }
        }
    }
}
