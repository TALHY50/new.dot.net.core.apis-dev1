using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;


namespace Admin.App.Application.Features.Providers
{
    public class UpdateProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateProviderUrl, Name = Routes.UpdateProviderName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Update(uint id, UpdateProviderCommand command)
        {
            var commandWithId = command with { id = id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateProviderCommand(
        uint id,
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

            public async Task<ErrorOr<Provider>> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
            {
                var now = DateTime.UtcNow;
                Provider? providers = _providerRepository.GetByUintId(request.id);

                if (providers != null)
                {
                    providers.Code = request.Code;
                    providers.Name = request.Name;
                    providers.BaseUrl = request.BaseUrl;
                    providers.ApiKey = request.ApiKey;
                    providers.ApiSecret = request.ApiSecret;
                    providers.Status = 1;
                    providers.CreatedById = 1;
                    providers.UpdatedById = 2;
                    providers.CreatedAt = now;
                    providers.UpdatedAt = now;
                };

                return await _providerRepository.UpdateAsync(providers);
            }
        }
    }
}

