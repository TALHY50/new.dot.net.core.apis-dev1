using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class UpdateServiceMethodContorller : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateServiceMethodUrl, Name = Routes.UpdateServiceMethodName)]

        public async Task<ActionResult<ErrorOr<ServiceMethod>>> Update(uint Id, UpdateServiceMethodCommand command)
        {
            var commandWithId = command with { Id = Id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateServiceMethodCommand(
            uint Id,
            byte Method,
            uint? CompanyId) : IRequest<ErrorOr<ServiceMethod>>;

        internal sealed class UpdateServiceMethodCommandValidator : AbstractValidator<UpdateServiceMethodCommand>
        {
            public UpdateServiceMethodCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ServiceMethod ID is required");
            }
        }

        internal sealed class UpdateServiceMethodCommandHandler : IRequestHandler<UpdateServiceMethodCommand, ErrorOr<ServiceMethod>>
        {
            private readonly IImtServiceMethodRepository _repository;

            public UpdateServiceMethodCommandHandler(IImtServiceMethodRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<ServiceMethod>> Handle(UpdateServiceMethodCommand command, CancellationToken cancellationToken)
            {
                ServiceMethod? serviceMethod = _repository.GetByUintId(command.Id);
                if (serviceMethod != null)
                {
                    serviceMethod.Method = command.Method;
                    serviceMethod.CompanyId = command.CompanyId;
                    

                    //if (_user?.UserId != null)
                    //{
                    //    entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
                    //}
                    //else
                    //{
                    //    entity.UpdatedById = 1;
                    //}
                }

                return await _repository.UpdateAsync(serviceMethod);
            }
        }

    }
}
