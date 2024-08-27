﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using static Admin.App.Application.Features.Mtts.MttsDelete;

namespace Admin.App.Application.Features.Providers
{
    public class DeleteProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteProviderUrl, Name = Routes.DeleteProviderName)]
        public async Task<bool> Delete(uint id)
        {
            return await Mediator.Send(new DeleteProviderCommand(id)).ConfigureAwait(false);
        }

        public record DeleteProviderCommand(uint id) 
            : IRequest<bool>;

        internal sealed class DeleteProviderCommandValidator : AbstractValidator<DeleteProviderCommand>
        {
            public DeleteProviderCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        internal sealed class DeleteProviderCommandHandler
        : IRequestHandler<DeleteProviderCommand, bool>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtProviderRepository _providerRepository;
            
            public DeleteProviderCommandHandler(ICurrentUserService user, IImtProviderRepository providerRepository)
            {
                _user = user;
                _providerRepository = providerRepository;
            }

            public async Task<bool> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
            {
                if (request.id > 0)
                {
                    var providers = _providerRepository.GetByUintId(request.id);

                    if (providers != null)
                    {
                        return await _providerRepository.DeleteAsync(providers);
                    }

                    return await _providerRepository.DeleteAsync(providers);
                }

                return false;
            }
        }
    }
}
