﻿using Admin.Web.Presentation.Routes;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Presentation.Endpoints.Institutions
{
    public class InstitutionDelete : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(InstitutionRoutes.DeleteInstitutionUrl, Name = InstitutionRoutes.DeleteInstitutionName)]
        public async Task<bool> Delete(DeleteInstitutionCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record DeleteInstitutionCommand(uint id)
           : IRequest<bool>;


        public class DeleteInstitutionCommandValidator : AbstractValidator<DeleteInstitutionCommand>
        {
            public DeleteInstitutionCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        public class DeleteInstitutionCommandHandler : IRequestHandler<DeleteInstitutionCommand, bool>
        {
            private readonly ICurrentUser _user;
            private readonly IInstitutionRepository _repository;

            public DeleteInstitutionCommandHandler(ICurrentUser user, IInstitutionRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<bool> Handle(DeleteInstitutionCommand request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(request.id);
                await _repository.DeleteAsync(result);
                return true;
            }
        }
    }
}
