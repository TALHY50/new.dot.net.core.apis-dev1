//using ErrorOr;
//using FluentValidation;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SharedBusiness.Main.Admin.Weblication.Features.Mtts;
//using SharedBusiness.Main.Common.Application.Services.Repositories;
//using SharedBusiness.Main.Common.Domain.Entities;
//using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
//using SharedKernel.Main.Contracts;
//using SharedKernel.Main.Presentation;
//using SharedKernel.Main.Presentation.Routes;

//namespace Admin.Web.Application.Features.Mtts
//{
//    [Authorize]
//    public record GetMttsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Mtt>>>;

//    public class GetMttsQueryValidator : AbstractValidator<GetMttsQuery>
//    {
//        public GetMttsQueryValidator()
//        {
//            RuleFor(x => x.PageNumber)
//                .GreaterThanOrEqualTo(1)
//                .When(x => x.PageNumber != 0)
//                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

//            RuleFor(x => x.PageSize)
//                .GreaterThanOrEqualTo(1)
//                .When(x => x.PageNumber > 0)
//                .When(x => x.PageSize != 0)
//                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
//        }
//    }

//    [ApiExplorerSettings(IgnoreApi = true)]
//    public class GetMttsQueryHandler
//      : MttBase, IRequestHandler<GetMttsQuery, ErrorOr<List<Mtt>>>
//    {
//        private readonly IMTTRepository _repository;

//        public GetMttsQueryHandler(IMTTRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<ErrorOr<List<Mtt>>> Handle(GetMttsQuery request, CancellationToken cancellationToken)
//        {
//            List<Mtt>? entities;

//            if (request.PageNumber > 0 && request.PageSize > 0)
//            {
//                entities = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

//            }
//            else
//            {
//                entities = await _repository.ListAsync(cancellationToken);

//            }

//            if (entities == null)
//            {
//                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Mtts not found!");
//            }

//            return entities;
//        }
//    }
//}
