using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Infrastructure.Services;

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
        services.AddScoped<IImtMttsRepository, MttRepository>();
        services.AddScoped<IImtRegionRepository, RegionRepository>(); 
        services.AddScoped<IImtProviderRepository, ProviderRepository>();
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IImtCorridorRepository, CorridorRepository>();
        services.AddScoped<IImtAdminCurrencyRepository, AdminCurrencyRepository>();
        services.AddScoped<IImtPayerRepository, PayerRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IImtServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IImtPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<IImtTaxRateRepository, TaxRateRepository>();
        services.AddScoped<IImtInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IImtMttsRepository, MttRepository>();
        services.AddScoped<IBusinessHourAndWeekendRepository, BusinessHourAndWeekendRepository>();
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IImtServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IImtPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<IImtTaxRateRepository, TaxRateRepository>();
        services.AddScoped<IImtInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IImtMttsRepository, MttRepository>();
        services.AddScoped<IBusinessHourAndWeekendRepository, BusinessHourAndWeekendRepository>();
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>(); 
        services.AddScoped<IImtMttsRepository, MttRepository>();
        services.AddScoped<IImtMttPaymentSpeedRepository, ImtMttPaymentSpeedRepository>();
        services.AddScoped<IHolidaySettingRepository, HolidaySettingRepository>();
        services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        services.AddScoped<IInstitutionSettingRepository, InstitutionSettingRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IImtServiceMethodRepository, ServiceMethodRepository>();
        services.AddScoped<IImtPayerPaymentSpeedRepository, PayerPaymentSpeed>();
        services.AddScoped<IImtTaxRateRepository, TaxRateRepository>();
        services.AddScoped<IImtInstitutionFundRepository, InstitutionFundRepository>();
        services.AddScoped<IImtTransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IImtInstitutionMttRepository, InstitutionMttRepository>();
        services.AddScoped<IImtCurrencyConversionRateRepository, CurrencyConversionRateRepository>();
        services.AddScoped<ITransactionLimitRepository, TransactionLimitRepository>();
        return services;
    }
    
}