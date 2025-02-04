﻿//using Ardalis.SharedKernel;
//using ErrorOr;
//using FluentValidation;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SharedBusiness.Main.Common.Application.Services.Repositories;
//using SharedBusiness.Main.Common.Domain.Entities;
//using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
//using SharedKernel.Main.Presentation;
//using SharedKernel.Main.Presentation.Routes;

//namespace Admin.App.Application.Features.Providers
//{
//    public class CreateProviderController : ApiControllerBase
//    {
//        [Tags("Providers")]
//        //[Authorize(Policy = "HasPermission")]
//        [HttpPost(Routes.CreateProviderUrl, Name = Routes.CreateProviderName)]
//        public async Task<ActionResult<ErrorOr<Provider>>> Create(CreateProviderCommand command)
//        {
//            var result = await Mediator.Send(command).ConfigureAwait(false);

//            return result.Match(
//                reminder => Ok(result.Value),
//                Problem);
//        }
//    }

//    public record CreateProviderCommand(
//        string? Code,
//        string? Name,
//        string? BaseUrl,
//        string? ApiKey,
//        string? ApiSecret,
//        byte? Status) : IRequest<ErrorOr<Provider>>;

//    public class CreateProviderCommandValidator : AbstractValidator<CreateProviderCommand>
//    {
//        public CreateProviderCommandValidator()
//        {
//            RuleFor(v => v.Code)
//                .MaximumLength(50)
//                .WithMessage("Maximum length can be 50.");
//            RuleFor(v => v.Name)
//                .MaximumLength(50)
//                .WithMessage("Maximum length can be 50.");
//            RuleFor(v => v.BaseUrl)
//                .MaximumLength(100)
//                .WithMessage("Maximum length can be 100.");
//            RuleFor(v => v.ApiKey)
//                .MaximumLength(100)
//                .WithMessage("Maximum length can be 100.");
//            RuleFor(v => v.ApiSecret)
//                .MaximumLength(100)
//                .WithMessage("Maximum length can be 100.");
//        }
//    }


//    public class CreateProviderCommandHandler
//        : IRequestHandler<CreateProviderCommand, ErrorOr<Provider>>
//    {
//        private readonly IProviderRepository _providerRepository;
//        public CreateProviderCommandHandler(IProviderRepository providerRepository)
//        {
//            _providerRepository = providerRepository;
//        }

//        public async Task<ErrorOr<Provider>> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
//        {
//            var now = DateTime.UtcNow;
//            var @provider = new Provider
//            {
//                Code = request.Code,
//                Name = request.Name,
//                BaseUrl = request.BaseUrl,
//                ApiKey = request.ApiKey,
//                ApiSecret = request.ApiSecret,
//                Status = request.Status??1,
//                CreatedById = 1,
//                UpdatedById = 2,
//                CreatedAt = now,
//                UpdatedAt = now,
//            };

//            return await _providerRepository.GetByIdAsync(@provider);
//        }
//    }
//}
