using System.Security.Cryptography;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Infrastructure.Jwt;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using ACL.Business.Infrastructure.Security;
using Admin.App.Application.Features.Corridors;
using Admin.App.Application.Features.Currencies;
using Admin.App.Application.Features.Payers;
using Admin.App.Application.Features.Providers;
using Admin.App.Application.Features.Regions;
using Admin.App.Application.Features.TransactionTypes;
using Admin.App.Infrastructure.Persistence;
using Admin.App.Presentation;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Cryptography;
using SharedKernel.Main.Infrastructure.Services;
using CountryRepository = SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories.CountryRepository;
using ICountryRepository = SharedBusiness.Main.Common.Application.Services.Repositories.ICountryRepository;

namespace Admin.App.Infrastructure;

public static class AdminInfrastructureDependencyInjection
{
    public static IServiceCollection AddAdminInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        services.AddAdminPersistence(configuration);
        return services;
    }

}