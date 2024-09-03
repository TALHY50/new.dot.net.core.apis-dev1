using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Application.Features.ServiceMethods
{
    public record UpdateServiceMethodCommand(
        uint id,
        byte method,
        uint? company_id,
        StatusValues status) : IRequest<ErrorOr<ServiceMethod>>;

    public class UpdateServiceMethodCommandValidator : AbstractValidator<UpdateServiceMethodCommand>
    {
        public UpdateServiceMethodCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ServiceMethod ID is required");
            RuleFor(x => x.method).MethodRule();
            RuleFor(x => x.company_id).CompanyIdRule();
            RuleFor(x => x.status).IsInEnum();
        }
    }

    public class UpdateServiceMethodCommandHandler : ServiceMethodBase, IRequestHandler<UpdateServiceMethodCommand, ErrorOr<ServiceMethod>>
    {
        private readonly IServiceMethodRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateServiceMethodCommandHandler(IServiceMethodRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<ServiceMethod>> Handle(UpdateServiceMethodCommand command, CancellationToken cancellationToken)
        {
            ServiceMethod? serviceMethod = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (serviceMethod == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => serviceMethod.Method = value, command.method);
            _guard.UpdateIfNotNullOrEmpty(value => serviceMethod.CompanyId = value, command.company_id);
            
            serviceMethod.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(serviceMethod, cancellationToken);

            return serviceMethod;


        }

    }
}
