using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Mtts;
using SharedBusiness.Main.Common.Application.Features.Mtts;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Mtts
{
    [Authorize]
    public record DeleteMttByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteMttByIdCommandValidator : AbstractValidator<DeleteMttByIdCommand>
    {
        public DeleteMttByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

     [ApiExplorerSettings(IgnoreApi = true)]
    public class DeleteMttByIdCommandHandler : MttBase, IRequestHandler<DeleteMttByIdCommand, ErrorOr<bool>>
    {
        private readonly IMTTRepository _repository;

        public DeleteMttByIdCommandHandler(IMTTRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteMttByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var entity = await _repository.GetByIdAsync(command.id);

                if (entity == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Mtt not found");
                }

                await _repository.DeleteAsync(entity, cancellationToken);

            }

            return true;
        }
    }
}
