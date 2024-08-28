using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Mtts.MttsDelete;

namespace Admin.App.Application.Features.Providers
{
    public class DeleteProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteProviderUrl, Name = Routes.DeleteProviderName)]
        public async Task<ErrorOr<bool>> Delete(uint id)
        {
            return await Mediator.Send(new DeleteProviderCommand(id)).ConfigureAwait(false);
        }

        public record DeleteProviderCommand(uint id) 
            : IRequest<ErrorOr<bool>>;

        public class DeleteProviderCommandValidator : AbstractValidator<DeleteProviderCommand>
        {
            public DeleteProviderCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        public class DeleteProviderCommandHandler
        : IRequestHandler<DeleteProviderCommand, ErrorOr<bool>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtProviderRepository _providerRepository;
            
            public DeleteProviderCommandHandler(ICurrentUserService user, IImtProviderRepository providerRepository)
            {
                _user = user;
                _providerRepository = providerRepository;
            }

            public async Task<ErrorOr<bool>> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
            {
                var providers = _providerRepository.GetByUintId(request.id);

                if (providers == null)
                {
                    return Error.NotFound(description: "Provider not found", code: AppStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return await _providerRepository.DeleteAsync(providers);
            }
        }
    }
}
