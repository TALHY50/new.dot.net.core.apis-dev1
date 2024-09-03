
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Corridors
{
    public record GetCorridorByIdQuery(uint id) : IRequest<ErrorOr<Corridor>>;

    public class GetCorridorByIdQueryValidator : AbstractValidator<GetCorridorByIdQuery>
    {
        public GetCorridorByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Corridor ID is required");
        }
    }

    public class GetCorridorByIdQueryHandler 
        : CorridorBase, IRequestHandler<GetCorridorByIdQuery, ErrorOr<Corridor>>
    {
        private readonly ICorridorRepository _repository;

        public GetCorridorByIdQueryHandler(ICorridorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Corridor>> Handle(GetCorridorByIdQuery request, CancellationToken cancellationToken)
        {
            var Corridor = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (Corridor == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return Corridor;
        }
    }
}
