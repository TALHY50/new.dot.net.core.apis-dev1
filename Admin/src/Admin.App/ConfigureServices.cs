// <copyright file="ConfigureServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Security.Cryptography;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Infrastructure.Persistence.Repositories;
using ACL.Business.Infrastructure.Security;
using Admin.App.Application.Features.Corridors;
using Admin.App.Application.Features.Currencies;
using Admin.App.Application.Features.Currencies;
using Admin.App.Application.Features.Payers;
using Admin.App.Application.Features.Providers;
using Admin.App.Infrastructure;
using Admin.App.Infrastructure.Persistence;
using Admin.App.Presentation;
using DotNetEnv;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Cryptography;
using SharedKernel.Main.Infrastructure.Services;
using ACLApplicationDbContext = ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext;
using CountryRepository = SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories.CountryRepository;
using ICountryRepository = SharedBusiness.Main.Common.Application.Services.Repositories.ICountryRepository;

namespace Admin.App;

public static class DependencyInjection
{

}