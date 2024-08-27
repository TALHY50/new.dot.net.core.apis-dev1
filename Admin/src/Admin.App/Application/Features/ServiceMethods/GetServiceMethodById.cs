using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using static Admin.App.Application.Features.Countries.GetCountryByIdController;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class GetServiceMethodByIdController : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetServiceMethodByIdUrl, Name = Routes.GetServiceMethodByIdName)]
        public async Task<ActionResult<ErrorOr<ServiceMethod>>> GetById(uint Id)
        {
            return await Mediator.Send(new GetServiceMethodByIdQuery(Id)).ConfigureAwait(false);
        }

        public record GetServiceMethodByIdQuery(uint Id) : IRequest<ErrorOr<ServiceMethod>>;

        internal sealed class GetServiceMethodByIdValidator : AbstractValidator<GetServiceMethodByIdQuery>
        {
            public GetServiceMethodByIdValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
            }
        }

        internal sealed class GetServiceMethodByIdQueryHandler : IRequestHandler<GetServiceMethodByIdQuery, ErrorOr<ServiceMethod>>
        {
            private readonly IImtServiceMethodRepository _repository;

            public GetServiceMethodByIdQueryHandler(IImtServiceMethodRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<ServiceMethod>> Handle(GetServiceMethodByIdQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetByUintId(request.Id);
            }
        }
    }
}
