using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Admin.App.Application.Features.Institutions
{
    public class InstitutionDelete : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteInstitutionUrl, Name = Routes.DeleteInstitutionName)]
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
            private readonly ICurrentUserService _user;
            private readonly IInstitutionRepository _repository;

            public DeleteInstitutionCommandHandler(ICurrentUserService user, IInstitutionRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<bool> Handle(DeleteInstitutionCommand request, CancellationToken cancellationToken)
            {
                return _repository.Delete(request.id);
            }
        }
    }
}
