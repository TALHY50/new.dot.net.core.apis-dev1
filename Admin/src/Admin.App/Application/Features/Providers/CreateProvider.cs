using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Providers
{
    public class CreateProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateProviderUrl, Name = Routes.CreateProviderName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Create(CreateProviderCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateProviderCommand(
        string? Code,
        string? Name,
        string? BaseUrl,
        string? AppId,
        string? AppSecret,
        sbyte? Status = 1) : IRequest<ErrorOr<Provider>>;


    internal sealed class CreateProviderCommandHandler
        : IRequestHandler<CreateProviderCommand, ErrorOr<Provider>>
    {
        private readonly IImtProviderRepository _providerRepository;
        public CreateProviderCommandHandler(IImtProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<ErrorOr<Provider>> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @provider = new Provider
            {
             //   Code = request.Code,
                Name = request.Name,
                BaseUrl = request.BaseUrl,
                AppId = request.AppId,
                AppSecret = request.AppSecret,
                Status = 1,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };

            return await _providerRepository.AddAsync(@provider);
        }
    }
}
