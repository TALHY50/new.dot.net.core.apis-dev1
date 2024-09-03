using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.Regions
{
    public record GetRegionByIdQuery(uint id) : IRequest<ErrorOr<Region>>;

    public class GetRegionByIdQueryValidator : AbstractValidator<GetRegionByIdQuery>
    {
        public GetRegionByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Region ID is required");
        }
    }


    public class GetRegionByIdQueryHandler : RegionBase, IRequestHandler<GetRegionByIdQuery, ErrorOr<Region>>
    {
        private readonly IRegionRepository _repository;

        public GetRegionByIdQueryHandler(IRegionRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
        {
            var region = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (region == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return region;
        }
    }
}
