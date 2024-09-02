using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Application.Features.Regions
{
    public record GetRegionsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Region>>>;

    public class GetRegionsQueryValidator : AbstractValidator<GetRegionsQuery>
    {
        public GetRegionsQueryValidator()
        {
            RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .When(x => x.PageNumber != 0)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber > 0)
                .When(x => x.PageSize != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }


    public class GetRegionsQueryHandler
        : RegionBase, IRequestHandler<GetRegionsQuery, ErrorOr<List<Region>>>
    {
        private readonly IRegionRepository _repository;

        public GetRegionsQueryHandler(IRegionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Region>>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
        {
            List<Region>? regions;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                regions = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                regions = await _repository.ListAsync(cancellationToken);

            }

            if (regions == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Region not found!");
            }

            return regions;
        }
    }
}
