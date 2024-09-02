using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Infrastructure.Utilities;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence;

public static class SharedBusinessCommonPersistenceDependencyInjection
{
    public static IServiceCollection AddSharedBusinessCommonPersistence(this IServiceCollection services)
    {
        services.AddDbContext<SharedBusiness.Main.Common.Infrastructure.Persistence.Context.ApplicationDbContext>(
            options =>
                options.UseMySQL(ConnectionManager.GetDbConnectionString(), options =>
                {
                    options.EnableRetryOnFailure();
                }),
            ServiceLifetime.Transient);
        services.AddScoped<IMTTRepository, MttRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>(); 
        services.AddScoped<IProviderRepository, ProviderRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<ICorridorRepository, CorridorRepository>();
        services.AddScoped<ICurrencyRepository, AdminCurrencyRepository>();
        services.AddScoped<IPayerRepository, PayerRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<ITaxRateRepository, TaxRateRepository>();
        services.AddScoped<IInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IMTTRepository, MttRepository>();
        services.AddScoped<IBusinessHourAndWeekendRepository, BusinessHourAndWeekendRepository>();
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<ITaxRateRepository, TaxRateRepository>();
        services.AddScoped<IInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IMTTRepository, MttRepository>();
        services.AddScoped<IBusinessHourAndWeekendRepository, BusinessHourAndWeekendRepository>();
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>(); 
        services.AddScoped<IMTTRepository, MttRepository>();
        services.AddScoped<IMTTPaymentSpeedRepository, MTTPaymentSpeedRepository>();
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>();
        services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        services.AddScoped<IInstitutionSettingRepository, InstitutionSettingRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<ITaxRateRepository, TaxRateRepository>();
        services.AddScoped<IInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IInstitutionMttRepository, InstitutionMttRepository>();
        services.AddScoped<ICurrencyConversionRateRepository, CurrencyConversionRateRepository>();
        services.AddScoped<ITransactionLimitRepository, TransactionLimitRepository>();
        return services;
    }
    
}