using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Domain.IMT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Context
{
    public partial class ImtApplicationDbContext(DbContextOptions<ImtApplicationDbContext> options)
           : DbContext(options), IApplicationDbContext
    {

        public virtual DbSet<Bank> ImtBanks { get; set; }

        public virtual DbSet<BusinessHoursAndWeekend> ImtBusinessHoursAndWeekends { get; set; }

        public virtual DbSet<City> ImtCities { get; set; }

        public virtual DbSet<Corridor> ImtCorridors { get; set; }

        public virtual DbSet<Country> ImtCountries { get; set; }

        public virtual DbSet<Currency> ImtCurrencies { get; set; }

        public virtual DbSet<CurrencyConversionRate> ImtCurrencyConversionRates { get; set; }

        public virtual DbSet<Customer> ImtCustomers { get; set; }

        public virtual DbSet<CustomerBank> ImtCustomerBanks { get; set; }

        public virtual DbSet<HolidaySetting> ImtHolidaySettings { get; set; }

        public virtual DbSet<Institution> ImtInstitutions { get; set; }

        public virtual DbSet<InstitutionFund> ImtInstitutionFunds { get; set; }

        public virtual DbSet<InstitutionMtt> ImtInstitutionMtts { get; set; }

        public virtual DbSet<MoneyTransfer> ImtMoneyTransfers { get; set; }

        public virtual DbSet<MoneyTransferReport> ImtMoneyTransferReports { get; set; }

        public virtual DbSet<Mtt> ImtMtts { get; set; }

        public virtual DbSet<MttPaymentSpeed> ImtMttPaymentSpeeds { get; set; }

        public virtual DbSet<Payer> ImtPayers { get; set; }

        public virtual DbSet<PayerPaymentSpeed> ImtPayerPaymentSpeeds { get; set; }

        public virtual DbSet<PaymentMethod> ImtPaymentMethods { get; set; }

        public virtual DbSet<Provider> ImtProviders { get; set; }

        public virtual DbSet<ProviderCommission> ImtProviderCommissions { get; set; }

        public virtual DbSet<ProviderErrorDetail> ImtProviderErrorDetails { get; set; }

        public virtual DbSet<ProviderPayer> ImtProviderPayers { get; set; }

        public virtual DbSet<ProviderService> ImtProviderServices { get; set; }

        public virtual DbSet<Quotation> ImtQuotations { get; set; }
        public virtual DbSet<QuotationRequest> ImtQuotationRequests { get; set; }
        public virtual DbSet<QuotationInfo> ImtQuotationInfos { get; set; }

        public virtual DbSet<Reason> ImtReasons { get; set; }

        public virtual DbSet<Region> ImtRegions { get; set; }

        public virtual DbSet<ServiceMethod> ImtServiceMethods { get; set; }

        public virtual DbSet<TaxRate> ImtTaxRates { get; set; }

        public virtual DbSet<Transaction> ImtTransactions { get; set; }

        public virtual DbSet<TransactionLimit> ImtTransactionLimits { get; set; }

        public virtual DbSet<TransactionState> ImtTransactionStates { get; set; }

        public virtual DbSet<TransactionType> ImtTransactionTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                DotNetEnv.Env.NoClobber().TraversePath().Load();
                string server = DotNetEnv.Env.GetString("DB_HOST");
                string database = DotNetEnv.Env.GetString("DB_DATABASE");
                string userName = DotNetEnv.Env.GetString("DB_USERNAME");
                string password = DotNetEnv.Env.GetString("DB_PASSWORD");
                string port = DotNetEnv.Env.GetString("DB_PORT");

                var connectionString = $"server={server};port={port};database={database};user={userName};password={password};charset=utf8mb4;";

                optionsBuilder.UseMySQL(connectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_banks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.Logo)
                .HasMaxLength(100)
                .HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive, 2=soft deleted")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("url");
        });

        modelBuilder.Entity<BusinessHoursAndWeekend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_business_hours_and_weekends", tb => tb.HasComment("Type : Master, regular office hours and weekends"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CloseAt)
                .HasColumnType("datetime")
                .HasColumnName("close_at");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Day)
                .HasMaxLength(10)
                .HasComment("Friday, Saturday, Sunday, Monday, etc")
                .HasColumnName("day");
            entity.Property(e => e.Gmt)
                .HasComment("GMT offset in hours (e.g., +5, -3)")
                .HasColumnName("gmt");
            entity.Property(e => e.HourType)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = regular, 1 = special")
                .HasColumnName("hour_type");
            entity.Property(e => e.IsWeekend)
                .HasComment("0=not weekend, 1=weekend")
                .HasColumnName("is_weekend");
            entity.Property(e => e.OpenAt)
                .HasColumnType("datetime")
                .HasColumnName("open_at");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive, 2=soft-deleted")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Corridor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_corridors", tb => tb.HasComment("Type : Master, corridor is setup of source country-currency to destination country-currency, like send GBP Euro to USA USD"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DestinationCountryId).HasColumnName("destination_country_id");
            entity.Property(e => e.DestinationCurrencyId).HasColumnName("destination_currency_id");
            entity.Property(e => e.SourceCountryId).HasColumnName("source_country_id");
            entity.Property(e => e.SourceCurrencyId).HasColumnName("source_currency_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_countries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.IsoCode)
                .HasMaxLength(100)
                .HasColumnName("iso_code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive, 2=soft-deleted")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_currencies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.IsoCode)
                .HasMaxLength(10)
                .HasColumnName("iso_code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive,2=soft-delete ")
                .HasColumnName("status");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .HasColumnName("symbol");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<CurrencyConversionRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_currency_conversion_rates", tb => tb.HasComment("Type : Master, conversion rates based on a corridor"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CorridorId).HasColumnName("corridor_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.ExchangeRate)
                .HasPrecision(16, 4)
                .HasComment("Exchange rate between currencies")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.FxSpread)
                .HasPrecision(16, 4)
                .HasComment("Foreign exchange spread")
                .HasColumnName("fx_spread");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .HasColumnName("address2");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CustomerNumber).HasColumnName("customer_number");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1= active, 2= pending, 3= blocked, 4=banned, 5=expired, 6=rejected, 7 = approved but not active yet")
                .HasColumnName("status");
            entity.Property(e => e.Tckn)
                .HasMaxLength(100)
                .HasColumnName("tckn");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<CustomerBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_customer_banks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(100)
                .HasColumnName("account_no");
            entity.Property(e => e.AccountTitle)
                .HasMaxLength(100)
                .HasColumnName("account_title");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.BranchIban)
                .HasMaxLength(100)
                .HasColumnName("branch_iban");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive, 2= soft-deleted")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<HolidaySetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_holiday_settings", tb => tb.HasComment("Type : Master, contrywise holidays"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CloseAt)
                .HasComment("Time to end if type is not full")
                .HasColumnType("datetime")
                .HasColumnName("close_at");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Gmt)
                .HasComment("GMT offset in hours (e.g., +5, -3)")
                .HasColumnName("gmt");
            entity.Property(e => e.OpenAt)
                .HasComment("Time to start if type is not full")
                .HasColumnType("datetime")
                .HasColumnName("open_at");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("0 = full, 1 = half, 2 = quarter, 3 = special")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_institutions", tb => tb.HasComment("Type : Master, we onboard an institution, and perform transactions under it, like the merchants of a payment system"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Name of the institution")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'2'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasComment("Url of the official site")
                .HasColumnName("url");
        });

        modelBuilder.Entity<InstitutionFund>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_institution_funds", tb => tb.HasComment("Type : Master, fund deposited for an institution like Sipay in a provider account (Thunes)"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(255)
                .HasComment("Account number for the wallet")
                .HasColumnName("account_number");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CurrentAmount)
                .HasPrecision(16, 4)
                .HasComment("Current amount in the wallet")
                .HasColumnName("current_amount");
            entity.Property(e => e.FundCountryId).HasColumnName("fund_country_id");
            entity.Property(e => e.FundCurrencyId).HasColumnName("fund_currency_id");
            entity.Property(e => e.InstitutionId).HasColumnName("institution_id");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.StartingAmount)
                .HasPrecision(16, 4)
                .HasComment("Starting amount in the wallet")
                .HasColumnName("starting_amount");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<InstitutionMtt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_institution_mtts", tb => tb.HasComment("Type : Master, mtt(s) assigned to an institution"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionCurrencyId).HasColumnName("commission_currency_id");
            entity.Property(e => e.CommissionFixed)
                .HasPrecision(16, 4)
                .HasColumnName("commission_fixed");
            entity.Property(e => e.CommissionPercentage)
                .HasPrecision(16, 4)
                .HasColumnName("commission_percentage");
            entity.Property(e => e.CommissionType)
                .HasComment("1 = Regular, 2 = Some-other-type")
                .HasColumnName("commission_type");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.InstitutionId).HasColumnName("institution_id");
            entity.Property(e => e.MttId).HasColumnName("mtt_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<MoneyTransfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_money_transfers");

            entity.Property(e => e.Id).HasColumnName("id");
            /*entity.Property(e => e.CommissionPaidBy)
                .HasDefaultValueSql("'1'")
                .HasComment("1=paid by sender, 2=paid by receiver")
                .HasColumnName("commission_paid_by");*/
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExchangeRate)
                .HasPrecision(12, 4)
                .HasColumnName("exchange_rate");
            /*entity.Property(e => e.ExchangedAmount)
                .HasPrecision(12, 4)
                .HasColumnName("exchanged_amount");*/
            /*entity.Property(e => e.Fee)
                .HasPrecision(12, 4)
                .HasColumnName("fee");*/
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            /*entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.ReasonCode)
                .HasMaxLength(10)
                .HasColumnName("reason_code");*/
            /*entity.Property(e => e.ReasonId).HasColumnName("reason_id");
            entity.Property(e => e.ReceiveAmount)
                .HasPrecision(12, 4)
                .HasColumnName("receive_amount");*/
            /*entity.Property(e => e.ReceiverCurrencyId).HasColumnName("receiver_currency_id");
            entity.Property(e => e.ReceiverCustomerId).HasColumnName("receiver_customer_id");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(50)
                .HasColumnName("receiver_name");*/
            entity.Property(e => e.RemoteOrderId)
                .HasMaxLength(50)
                .HasColumnName("remote_order_id");
            entity.Property(e => e.SendAmount)
                .HasPrecision(12, 4)
                .HasColumnName("send_amount");
            /*entity.Property(e => e.SenderCurrencyId).HasColumnName("sender_currency_id");
            entity.Property(e => e.SenderCustomerId).HasColumnName("sender_customer_id");
            entity.Property(e => e.SenderName)
                .HasMaxLength(50)
                .HasColumnName("sender_name");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'1'")
                .HasComment("1=from api, 2= from admin")
                .HasColumnName("source");*/
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            /*entity.Property(e => e.TransferType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=regular, 2 = instant, 3 = same day")
                .HasColumnName("transfer_type");*/
            /*entity.Property(e => e.Type)
                .HasDefaultValueSql("'2'")
                .HasComment("1 = b2b, 2 = c2c, 3=c2b, 4=b2c ")
                .HasColumnName("type");*/
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            /*entity.Property(e => e.Vat)
                .HasPrecision(12, 4)
                .HasColumnName("vat");*/
        });

        modelBuilder.Entity<MoneyTransferReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_money_transfer_reports");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MoneyTransferCommission)
                .HasPrecision(12, 9)
                .HasColumnName("money_transfer_commission");
            entity.Property(e => e.MoneyTransferCot)
                .HasPrecision(12, 9)
                .HasColumnName("money_transfer_cot");
            entity.Property(e => e.MoneyTransferCurrencyId).HasColumnName("money_transfer_currency_id");
            entity.Property(e => e.MoneyTransferExchangeRate)
                .HasPrecision(12, 9)
                .HasColumnName("money_transfer_exchange_rate");
            entity.Property(e => e.MoneyTransferInstitutionId).HasColumnName("money_transfer_institution_id");
            entity.Property(e => e.MoneyTransferInvoiceId)
                .HasMaxLength(50)
                .HasColumnName("money_transfer_invoice_id");
            entity.Property(e => e.MoneyTransferMode).HasColumnName("money_transfer_mode");
            entity.Property(e => e.MoneyTransferMttId).HasColumnName("money_transfer_mtt_id");
            entity.Property(e => e.MoneyTransferOrderId)
                .HasMaxLength(50)
                .HasColumnName("money_transfer_order_id");
            entity.Property(e => e.MoneyTransferPaymentId)
                .HasMaxLength(50)
                .HasColumnName("money_transfer_payment_id");
            entity.Property(e => e.MoneyTransferQuotationId).HasColumnName("money_transfer_quotation_id");
            entity.Property(e => e.MoneyTransferRemoteOrderId)
                .HasMaxLength(50)
                .HasComment("Transaction id  by providers")
                .HasColumnName("money_transfer_remote_order_id");
            entity.Property(e => e.MoneyTransferRequestAmount)
                .HasPrecision(12, 4)
                .HasColumnName("money_transfer_request_amount");
            entity.Property(e => e.MoneyTransferSendAmount)
                .HasPrecision(12, 9)
                .HasColumnName("money_transfer_send_amount");
            entity.Property(e => e.MoneyTransferTax)
                .HasPrecision(12, 9)
                .HasColumnName("money_transfer_tax");
            entity.Property(e => e.MoneyTransferTransactionStateId).HasColumnName("money_transfer_transaction_state_id");
            entity.Property(e => e.RemoteTransactionDatetime)
                .HasColumnType("datetime")
                .HasColumnName("remote_transaction_datetime");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Mtt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_mtts", tb => tb.HasComment("Type : Master, transaction setup between providers and us, like POS of a payment system"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CorridorId).HasColumnName("corridor_id");
            entity.Property(e => e.CotCurrencyId).HasColumnName("cot_currency_id");
            entity.Property(e => e.CotFixed)
                .HasPrecision(16, 4)
                .HasColumnName("cot_fixed");
            entity.Property(e => e.CotPercentage)
                .HasPrecision(16, 4)
                .HasColumnName("cot_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.FxSpread)
                .HasPrecision(16, 4)
                .HasColumnName("fx_spread");
            entity.Property(e => e.Increment)
                .HasPrecision(16, 4)
                .HasComment("Increment value, definition may vary")
                .HasColumnName("increment");
            entity.Property(e => e.MarkUpCurrencyId).HasColumnName("mark_up_currency_id");
            entity.Property(e => e.MarkUpFixed)
                .HasPrecision(16, 4)
                .HasColumnName("mark_up_fixed");
            entity.Property(e => e.MarkUpPercentage)
                .HasPrecision(16, 4)
                .HasColumnName("mark_up_percentage");
            entity.Property(e => e.MoneyPrecision).HasColumnName("money_precision");
            entity.Property(e => e.PayerId).HasColumnName("payer_id");
            entity.Property(e => e.ServiceMethodId).HasColumnName("service_method_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.TransactionTypeId)
                .HasMaxLength(255)
                .HasColumnName("transaction_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<MttPaymentSpeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_mtt_payment_speeds", tb => tb.HasComment("Type : Master, time to complete a transaction."));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClosesAt)
                .HasComment("Closing time")
                .HasColumnType("datetime")
                .HasColumnName("closes_at");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Gmt)
                .HasComment("GMT offset (e.g., +5, -3)")
                .HasColumnName("gmt");
            entity.Property(e => e.IsProcessingDuringBankingHoliday)
                .HasComment("0 = No, 1 = Yes")
                .HasColumnName("is_processing_during_banking_holiday");
            entity.Property(e => e.MttId).HasColumnName("mtt_id");
            entity.Property(e => e.OpensAt)
                .HasComment("Opening time")
                .HasColumnType("datetime")
                .HasColumnName("opens_at");
            entity.Property(e => e.ProcessingTime)
                .HasComment("Processing time in minutes")
                .HasColumnName("processing_time");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.WorkingDays)
                .HasMaxLength(255)
                .HasComment("CSV of weekdays (e.g., Monday,Tuesday)")
                .HasColumnName("working_days");
        });

        modelBuilder.Entity<Payer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_payers", tb => tb.HasComment("Type : Master, payers are the corridor setups under a provider like Thunes, a payer is acting like a bank terminal, most of the data are operational, will be set as MTT's values, here to crosscheck"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CorridorId).HasColumnName("corridor_id");
            entity.Property(e => e.CotCurrencyId).HasColumnName("cot_currency_id");
            entity.Property(e => e.CotFixed)
                .HasPrecision(16, 4)
                .HasColumnName("cot_fixed");
            entity.Property(e => e.CotPercentage)
                .HasPrecision(16, 4)
                .HasColumnName("cot_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DestinationAmountMax)
                .HasPrecision(16, 4)
                .HasColumnName("destination_amount_max");
            entity.Property(e => e.DestinationAmountMin)
                .HasPrecision(16, 4)
                .HasColumnName("destination_amount_min");
            entity.Property(e => e.FundCurrencyId).HasColumnName("fund_currency_id");
            entity.Property(e => e.FxSpread)
                .HasPrecision(16, 4)
                .HasColumnName("fx_spread");
            entity.Property(e => e.Increment)
                .HasPrecision(16, 4)
                .HasColumnName("increment");
            entity.Property(e => e.InternalPayerId)
                .HasMaxLength(50)
                .HasColumnName("internal_payer_id");
            entity.Property(e => e.MoneyPrecision).HasColumnName("money_precision");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PaymentSpeed)
                .HasColumnType("text")
                .HasColumnName("payment_speed");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.ServiceMethodId).HasColumnName("service_method_id");
            entity.Property(e => e.SourceAmountMax)
                .HasPrecision(16, 4)
                .HasColumnName("source_amount_max");
            entity.Property(e => e.SourceAmountMin)
                .HasPrecision(16, 4)
                .HasColumnName("source_amount_min");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.TransactionTypeIds)
                .HasMaxLength(255)
                .HasComment("CSV of transaction_type_id values")
                .HasColumnName("transaction_type_ids");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<PayerPaymentSpeed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_payer_payment_speeds", tb => tb.HasComment("Type : Master, for every transaction it takes time to process the transactions, this is the setup in payers' context"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CloseAt)
                .HasComment("Closing time")
                .HasColumnType("datetime")
                .HasColumnName("close_at");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Gmt)
                .HasComment("GMT offset in hours (e.g., +5, -3)")
                .HasColumnName("gmt");
            entity.Property(e => e.IsProcessingDuringBankingHoliday)
                .HasComment("0 = No, 1 = Yes")
                .HasColumnName("is_processing_during_banking_holiday");
            entity.Property(e => e.OpenAt)
                .HasComment("Opening time")
                .HasColumnType("datetime")
                .HasColumnName("open_at");
            entity.Property(e => e.PayerId).HasColumnName("payer_id");
            entity.Property(e => e.ProcessingTime)
                .HasComment("Processing time in minutes")
                .HasColumnName("processing_time");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.WorkingDays)
                .HasMaxLength(255)
                .HasComment("CSV of weekdays (e.g., Monday,Tuesday)")
                .HasColumnName("working_days");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_payment_methods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .HasColumnName("method_name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1= active, 0=inactive, 2=soft-deleted")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_providers", tb => tb.HasComment("Type : Master, channels being used for money transfers, like Thunes, PayAll, Mastercard"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppId)
                .HasMaxLength(255)
                .HasColumnName("app_id");
            entity.Property(e => e.AppSecret)
                .HasMaxLength(255)
                .HasColumnName("app_secret");
            entity.Property(e => e.BaseUrl)
                .HasMaxLength(255)
                .HasComment("base_url of the APIs")
                .HasColumnName("base_url");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<ProviderCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_provider_commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.FromCurrencyId).HasColumnName("from_currency_id");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.ReceiverCommissionFixed)
                .HasPrecision(12, 4)
                .HasColumnName("receiver_commission_fixed");
            entity.Property(e => e.ReceiverCommissionPercentage)
                .HasPrecision(12, 4)
                .HasColumnName("receiver_commission_percentage");
            entity.Property(e => e.SenderCommissionFixed)
                .HasPrecision(12, 4)
                .HasColumnName("sender_commission_fixed");
            entity.Property(e => e.SenderCommissionPercentage)
                .HasPrecision(12, 4)
                .HasColumnName("sender_commission_percentage");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive, 2=soft-deleted")
                .HasColumnName("status");
            entity.Property(e => e.ToCurrencyId).HasColumnName("to_currency_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<ProviderErrorDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_provider_error_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(20)
                .HasColumnName("error_code");
            entity.Property(e => e.ErrorMessage)
                .HasMaxLength(255)
                .HasColumnName("error_message");
            entity.Property(e => e.ImtProviderId).HasColumnName("imt_provider_id");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProviderPayer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_provider_payers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ImtCountryId).HasColumnName("imt_country_id");
            entity.Property(e => e.ImtCurrencyId).HasColumnName("imt_currency_id");
            entity.Property(e => e.ImtProviderId).HasColumnName("imt_provider_id");
            entity.Property(e => e.ImtProviderServiceId).HasColumnName("imt_provider_service_id");
            entity.Property(e => e.Increment)
                .HasPrecision(12, 4)
                .HasColumnName("increment");
            entity.Property(e => e.Precision).HasColumnName("precision");
            entity.Property(e => e.RemotePayerId).HasColumnName("remote_payer_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProviderService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_provider_services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.ImtProviderId).HasColumnName("imt_provider_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_quotations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DestinationAmount)
                .HasPrecision(16, 4)
                .HasColumnName("destination_amount");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expiration_date");
            entity.Property(e => e.InstitutionId).HasColumnName("institution_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.Mode)
                .HasComment("SOURCE_AMOUNT,DESTINATION_AMOUNT")
                .HasColumnName("mode");
            entity.Property(e => e.MttId).HasColumnName("mtt_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.SourceAmount)
                .HasPrecision(16, 4)
                .HasColumnName("source_amount");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Reason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_reasons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = inactive, 1=active, 2=soft=deleted")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_regions", tb => tb.HasComment("Type : Master; Regions like Asia Pacific, SARC. Every country belongs to a region"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Example : EuroZone, Asia Pacific")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<ServiceMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_service_methods", tb => tb.HasComment("Type : Master, delivery methods of transactions"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Method)
                .HasComment("1 = Bank Account, 2 = Wallet, 3 = Cash Pickup, 4 = Card")
                .HasColumnName("method");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_tax_rates", tb => tb.HasComment("Type : Master, government tax rates based on countries for each transaction"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CorridorId).HasColumnName("corridor_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.TaxCurrencyId).HasColumnName("tax_currency_id");
            entity.Property(e => e.TaxFixed)
                .HasPrecision(16, 4)
                .HasColumnName("tax_fixed");
            entity.Property(e => e.TaxPercentage)
                .HasPrecision(16, 4)
                .HasColumnName("tax_percentage");
            entity.Property(e => e.TaxType)
                .HasComment("1 = Regular, 2 = Corridor tax, 3 = Country tax")
                .HasColumnName("tax_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_transactions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(12, 4)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrentBalance)
                .HasPrecision(16, 4)
                .HasColumnName("current_balance");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Fee)
                .HasPrecision(12, 4)
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasPrecision(12, 4)
                .HasColumnName("gross");
            entity.Property(e => e.MoneyFlow)
                .HasDefaultValueSql("'0'")
                .HasComment("1= incoming and 2 = outgoing")
                .HasColumnName("money_flow");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.PreviousBalance)
                .HasPrecision(16, 4)
                .HasColumnName("previous_balance");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=pending, 1=approved, 2=reject")
                .HasColumnName("status");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TransactionReferenceId)
                .HasComment("For refund, it would be corresponding sale id")
                .HasColumnName("transaction_reference_id");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.TransactionType)
                .HasDefaultValueSql("'0'")
                .HasComment("1= send money, 2=receive money ")
                .HasColumnName("transaction_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TransactionLimit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_transaction_limits", tb => tb.HasComment("Type : Master, transaction limits based on various entity like corridors, countries, mtts"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AggregationType)
                .HasComment("Aggregation type of transactions")
                .HasColumnType("enum('single','summation')")
                .HasColumnName("aggregation_type");
            entity.Property(e => e.AmountCurrencyId)
                .HasComment("Currency ID for the amount")
                .HasColumnName("amount_currency_id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.EntityId)
                .HasComment("ID of the entity")
                .HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasComment("Type of entity (mtts, corridors, countries)")
                .HasColumnType("enum('mtts','corridors','countries')")
                .HasColumnName("entity_type");
            entity.Property(e => e.Max)
                .HasPrecision(16, 4)
                .HasComment("Maximum transaction amount")
                .HasColumnName("max");
            entity.Property(e => e.Min)
                .HasPrecision(16, 4)
                .HasComment("Minimum transaction amount")
                .HasColumnName("min");
            entity.Property(e => e.PeriodicityType)
                .HasComment("Periodicity of the limit")
                .HasColumnType("enum('daily','weekly','monthly','yearly')")
                .HasColumnName("periodicity_type");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.TransferPoint)
                .HasComment("Transfer point (source or destination)")
                .HasColumnType("enum('source','destination')")
                .HasColumnName("transfer_point");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<TransactionState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_transaction_states");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_transaction_types", tb => tb.HasComment("Type : Master, transaction models for business and consumers"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1=active, 2=pending, 3=rejected ")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("1 = B2B, 2 = B2C, 3 = C2B, 4 = C2C, 5 = M2M")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
