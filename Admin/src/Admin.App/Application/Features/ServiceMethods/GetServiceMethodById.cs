using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class GetServiceMethodByIdController : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetServiceMethodByIdUrl, Name = Routes.GetServiceMethodByIdName)]
        public async Task<ActionResult<ErrorOr<ServiceMethod>>> GetById(uint Id)
        {
            var result = await Mediator.Send(new GetServiceMethodByIdQuery(Id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetServiceMethodByIdQuery(uint Id) : IRequest<ErrorOr<ServiceMethod>>;

        public class GetServiceMethodByIdValidator : AbstractValidator<GetServiceMethodByIdQuery>
        {
            public GetServiceMethodByIdValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
            }
        }

        public class GetServiceMethodByIdQueryHandler : IRequestHandler<GetServiceMethodByIdQuery, ErrorOr<ServiceMethod>>
        {
            private readonly IServiceMethodRepository _repository;

            public GetServiceMethodByIdQueryHandler(IServiceMethodRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<ServiceMethod>> Handle(GetServiceMethodByIdQuery request, CancellationToken cancellationToken)
            {
                var serviceMethod = _repository.View(request.Id);

                if (serviceMethod == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Service Method not found!");
                }

                return serviceMethod;
            }
        }
    }
}
