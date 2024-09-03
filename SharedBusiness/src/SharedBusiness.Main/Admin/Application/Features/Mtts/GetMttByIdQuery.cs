using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Admin.Weblication.Features.Mtts;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.Mtts
{
    [Authorize]
    public record GetMttByIdQuery(uint id) : IRequest<ErrorOr<Mtt>>;

    public class GetMttByIdQueryValidator : AbstractValidator<GetMttByIdQuery>
    {
        public GetMttByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Mtt ID is required");
        }
    }

     [ApiExplorerSettings(IgnoreApi = true)]
    public class GetMttByIdQueryHandler : MttBase, IRequestHandler<GetMttByIdQuery, ErrorOr<Mtt>>
    {
        private readonly IMTTRepository _repository;

        public GetMttByIdQueryHandler(IMTTRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Mtt>> Handle(GetMttByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (entity == null)
            {
                return Error.NotFound(description: "Mtt not found!", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return entity;
        }
    }
}
