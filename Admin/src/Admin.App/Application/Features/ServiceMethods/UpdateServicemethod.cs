using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

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
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdateServiceMethodCommand(
            uint Id,
            byte Method,
            uint? CompanyId) : IRequest<ErrorOr<ServiceMethod>>;

        public class UpdateServiceMethodCommandValidator : AbstractValidator<UpdateServiceMethodCommand>
        {
            public UpdateServiceMethodCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ServiceMethod ID is required");
                RuleFor(x => x.Method).NotEmpty().WithMessage("Method  is required");
                RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Company Id  is required");
            }
        }

        public class UpdateServiceMethodCommandHandler : IRequestHandler<UpdateServiceMethodCommand, ErrorOr<ServiceMethod>>
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
                    serviceMethod.UpdatedById = command.Id;
                    serviceMethod.UpdatedAt = DateTime.UtcNow;
                }

                if (serviceMethod == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Service Method not found!");
                }

                return await _repository.UpdateAsync(serviceMethod);
            }
        }

    }
}
