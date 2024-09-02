using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Application.Features.Regions
{
    public record DeleteRegionByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteRegionByIdCommandValidator : AbstractValidator<DeleteRegionByIdCommand>
    {
        public DeleteRegionByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }


    public class DeleteRegionByIdCommandHandler : RegionBase, IRequestHandler<DeleteRegionByIdCommand, ErrorOr<bool>>
    {
        private readonly IRegionRepository _repository;

        public DeleteRegionByIdCommandHandler(IRegionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteRegionByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var region = await _repository.GetByIdAsync(command.id);

                if (region == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Region not found");
                }

                await _repository.DeleteAsync(region, cancellationToken);

            }

            return true;
        }
    }
}
