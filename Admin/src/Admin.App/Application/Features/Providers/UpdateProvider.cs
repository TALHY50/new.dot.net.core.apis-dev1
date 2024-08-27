using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;


namespace Admin.App.Application.Features.Providers
{
    public class UpdateProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateProviderUrl, Name = Routes.UpdateProviderName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Update(int id, UpdateProviderCommand command)
        {
            var commandWithId = command with { id = id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateProviderCommand(
        int id,
        string? Code,
        string? Name,
        string? BaseUrl,
        string? ApiKey,
        string? ApiSecret) : IRequest<ErrorOr<Provider>>;


        //internal sealed class UpdateProviderCommandValidator : AbstractValidator<UpdateProviderCommand>
        //{
        //    public UpdateProviderCommandValidator()
        //    {
        //        RuleFor(v => v.Status)
        //            .NotEmpty()
        //            .WithMessage("Status is required.");
        //    }
        //}


        internal sealed class UpdateProviderCommandHandler
        : IRequestHandler<UpdateProviderCommand, ErrorOr<Provider>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtProviderRepository _providerRepository;

            public UpdateProviderCommandHandler(ICurrentUserService user, IImtProviderRepository providerRepository)
            {
                _user = user;
                _providerRepository = providerRepository;
            }

        public async Task<ErrorOr<Provider>> Handle(UpdateProviderCommand command, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @provider = new Provider
            {
              //  Code = command.Code,
                Name = command.Name,
                BaseUrl = command.BaseUrl,
                AppId = command.ApiKey,
                AppSecret = command.ApiSecret,
                Status = 1,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };
            // _context.Events.Add(@region);

                return await _providerRepository.UpdateAsync(@provider);
            }
        }
    }
}

