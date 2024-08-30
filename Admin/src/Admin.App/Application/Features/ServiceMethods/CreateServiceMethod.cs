using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class CreateServiceMethodController : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateServiceMethodUrl, Name = Routes.CreateServiceMethodName)]

        public async Task<ActionResult<ErrorOr<ServiceMethod>>> Create(CreateServiceMethodCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record CreateServiceMethodCommand(
        byte Method,
        uint? CompanyId
        ) : IRequest<ErrorOr<ServiceMethod>>;

    public class CreateServiceMethodCommandValidator : AbstractValidator<CreateServiceMethodCommand>
    {
        public CreateServiceMethodCommandValidator()
        {
            RuleFor(x => x.Method).NotEmpty().WithMessage("Method  is required");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Company Id  is required");
        }
    }

    public class CreateServiceMethodCommandHandler : IRequestHandler<CreateServiceMethodCommand, ErrorOr<ServiceMethod>>
    {
        private readonly IImtServiceMethodRepository _repository;

        public CreateServiceMethodCommandHandler(IImtServiceMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<ServiceMethod>> Handle(CreateServiceMethodCommand command, CancellationToken cancellationToken)
        {
            var serviceMethod = new ServiceMethod
            {
                Method = command.Method, //1 = Bank Account, 2 = Wallet, 3 = Cash Pickup, 4 = Card
                CompanyId = command.CompanyId,
                Status = 1, //0=inactive, 1=active, 2=pending, 3=rejected 
                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (serviceMethod == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return _repository.Add(serviceMethod)!;
        }
    }
}
