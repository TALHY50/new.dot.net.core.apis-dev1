using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;


namespace Admin.App.Application.Features.Providers
{
    public class UpdateProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateProviderUrl, Name = Routes.UpdateProviderName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Update(UpdateProviderCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

    }

    public record UpdateProviderCommand(
        int Id,
        string? Code,
        string? Name,
        string? BaseUrl,
        string? ApiKey,
        string? ApiSecret,
        sbyte? Status = 1) : IRequest<ErrorOr<Provider>>;


    internal sealed class UpdateProviderCommandHandler(ImtApplicationDbContext context)
        : IRequestHandler<UpdateProviderCommand, ErrorOr<Provider>>
    {


        public async Task<ErrorOr<Provider>> Handle(UpdateProviderCommand command, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @provider = new Provider
            {
                Code = command.Code,
                Name = command.Name,
                BaseUrl = command.BaseUrl,
                ApiKey = command.ApiKey,
                ApiSecret = command.ApiSecret,
                Status = 1,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };
            // _context.Events.Add(@region);

            return provider;
        }
    }
}

