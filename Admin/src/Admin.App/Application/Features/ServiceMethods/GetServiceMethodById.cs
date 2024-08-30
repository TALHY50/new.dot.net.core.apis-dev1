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
using static Admin.App.Presentation.Endpoints.Country.GetCountryById;

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
            private readonly IImtServiceMethodRepository _repository;

            public GetServiceMethodByIdQueryHandler(IImtServiceMethodRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<ServiceMethod>> Handle(GetServiceMethodByIdQuery request, CancellationToken cancellationToken)
            {
                var serviceMethod = _repository.View(request.Id);

                var message = new MessageResponse("Record not found");

                if (serviceMethod == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return serviceMethod;
            }
        }
    }
}
