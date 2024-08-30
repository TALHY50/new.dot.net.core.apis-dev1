﻿using ACL.Business.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Mtts.InstitutionDelete;

namespace Admin.App.Application.Features.Providers
{
    public class DeleteProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteProviderUrl, Name = Routes.DeleteProviderName)]
        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
        {
            var result = await Mediator.Send(new DeleteProviderCommand(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
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
                var message = new MessageResponse("Record not found");

                var providers = _providerRepository.View(request.id);

                if (providers == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _providerRepository.Delete(providers);
            }
        }
    }
}
