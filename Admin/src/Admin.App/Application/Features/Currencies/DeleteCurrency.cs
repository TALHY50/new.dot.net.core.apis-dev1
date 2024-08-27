﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Currencies
{
    public class DeleteCurrencyController : ApiControllerBase
    {
        [Tags("Currency")]
        // [Authorize]
        [HttpDelete(Routes.DeleteCurrencyUrl, Name = Routes.DeleteCurrencyName)]
        public async Task<bool> DeleteCurrency(int id)
        {
            return await Mediator.Send(new DeleteCurrencyCommand(id)).ConfigureAwait(false);
        }
    }

    public record DeleteCurrencyCommand(int id) : IRequest<bool>;

    internal sealed class DeleteCurrencyCommandValidator : AbstractValidator<DeleteCurrencyCommand>
    {
        public DeleteCurrencyCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    internal sealed class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, bool>
    {
        private readonly IImtAdminCurrencyRepository _repository;
        public DeleteCurrencyCommandHandler(IImtAdminCurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            if (request.id > 0)
            {
                var entity = _repository.GetByIntId(request.id);

                if (entity != null)
                {
                    return await _repository.DeleteAsync(entity);
                }

                return await _repository.DeleteAsync(entity);
            }

            return false;
        }
    }
}
