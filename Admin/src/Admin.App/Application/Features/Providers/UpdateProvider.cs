using ACL.Business.Contracts.Responses;
using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Providers.GetProviderByIdController;


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
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdateProviderCommand(
        uint id,
        string? Code,
        string? Name,
        string? BaseUrl,
        string? ApiKey,
        string? ApiSecret,
        byte? Status) : IRequest<ErrorOr<Provider>>;


        public class UpdateProviderCommandValidator : AbstractValidator<UpdateProviderCommand>
        {
            public UpdateProviderCommandValidator()
            {
                RuleFor(v => v.id)
                    .NotEmpty()
                    .WithMessage("ID is required.");
                RuleFor(v => v.Code)
                    .MaximumLength(50)
                    .WithMessage("Maximum length can be 50.");
                RuleFor(v => v.Name)
                    .MaximumLength(50)
                    .WithMessage("Maximum length can be 50.");
                RuleFor(v => v.BaseUrl)
                    .MaximumLength(100)
                    .WithMessage("Maximum length can be 100.");
                RuleFor(v => v.ApiKey)
                    .MaximumLength(100)
                    .WithMessage("Maximum length can be 100.");
                RuleFor(v => v.ApiSecret)
                    .MaximumLength(100)
                    .WithMessage("Maximum length can be 100.");
            }
        }


        public class UpdateProviderCommandHandler
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
                var message = new MessageResponse("Record not found");

                var now = DateTime.UtcNow;
                Provider? providers = _providerRepository.View(request.id);

                if (providers == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                
                providers.Code = request.Code;
                providers.Name = request.Name;
                providers.BaseUrl = request.BaseUrl;
                providers.ApiKey = request.ApiKey;
                providers.ApiSecret = request.ApiSecret;
                providers.Status = request.Status;
                providers.CreatedById = 1;
                providers.UpdatedById = 2;
                providers.CreatedAt = now;
                providers.UpdatedAt = now;

                return _providerRepository.Update(providers);
            }
        }
    }
}

