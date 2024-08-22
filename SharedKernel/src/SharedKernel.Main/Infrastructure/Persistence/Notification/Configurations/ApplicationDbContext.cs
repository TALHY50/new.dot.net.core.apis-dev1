using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces;
using SharedKernel.Main.Domain.IMT.Entities;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations
{
    public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options), IApplicationDbContext
    {
        public virtual DbSet<Bank> ImtBanks { get; set; }

        public virtual DbSet<City> ImtCities { get; set; }

        public virtual DbSet<Country> ImtCountries { get; set; }

        public virtual DbSet<Currency> ImtCurrencies { get; set; }

        public virtual DbSet<Customer> ImtCustomers { get; set; }

        public virtual DbSet<CustomerBank> ImtCustomerBanks { get; set; }

        public virtual DbSet<MoneyTransfer> ImtMoneyTransfers { get; set; }

        public virtual DbSet<PaymentMethod> ImtPaymentMethods { get; set; }

        public virtual DbSet<Provider> ImtProviders { get; set; }

        public virtual DbSet<ProviderCommission> ImtProviderCommissions { get; set; }

        public virtual DbSet<ProviderPayer> ImtProviderPayers { get; set; }

        public virtual DbSet<ProviderService> ImtProviderServices { get; set; }

        public virtual DbSet<Quotation> ImtQuotations { get; set; }

        public virtual DbSet<Reason> ImtReasons { get; set; }

        public virtual DbSet<Transaction> ImtTransactions { get; set; }

        public virtual DbSet<TransactionLimit> ImtTransactionLimits { get; set; }

        public virtual DbSet<TransactionState> ImtTransactionStates { get; set; }

        public virtual DbSet<TransactionType> ImtTransactionTypes { get; set; }
        public virtual DbSet<ProviderErrorDetail> ImtProviderErrorDetails { get; set; }

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

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("code");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.DisplayName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("display_name");
                entity.Property(e => e.Logo)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("logo");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'1'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("url");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_cities");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.CountryId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("country_id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_countries");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("code");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.IsoCode)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("iso_code");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_currencies");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("code");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.IsoCode)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("iso_code");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.Symbol)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("symbol");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_customers");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("address1");
                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("address2");
                entity.Property(e => e.Category)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("1=verified, 2=not verified, 3=verified+")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("category");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.CustomerNumber)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(20)")
                    .HasColumnName("customer_number");
                entity.Property(e => e.Dob)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("date")
                    .HasColumnName("dob");
                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("email");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("first_name");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("last_name");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("name");
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("password");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("phone");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("1=approved,2= not approvec, 3=active, 4=inactive, 5=suspended, 6=banned etc")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.Tckn)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("tckn is government national id")
                    .HasColumnName("tckn");
                entity.Property(e => e.Type)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("1=individual, 2=corporate etc")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("type");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("username");
            });

            modelBuilder.Entity<CustomerBank>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_customer_banks");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.AccountNo)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("account_no");
                entity.Property(e => e.AccountTitle)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("account_title");
                entity.Property(e => e.BankId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("bank_id");
                entity.Property(e => e.BranchIban)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("branch_iban");
                entity.Property(e => e.CityId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("city_id");
                entity.Property(e => e.CountryId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("country_id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.CustomerId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("customer_id");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("can't delete if already exist")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<MoneyTransfer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_money_transfers");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.CommissionPaidBy)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("commission_paid_by");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.ExchangeRate)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("exchange_rate");
                entity.Property(e => e.ExchangedAmount)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("exchanged_amount");
                entity.Property(e => e.Fee)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("fee");
                entity.Property(e => e.InvoiceId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("invoice_id");
                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("order_id");
                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("payment_id");
                entity.Property(e => e.PaymentMethodId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("payment_method_id");
                entity.Property(e => e.ReasonCode)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("reason_code");
                entity.Property(e => e.ReasonId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("reason_id");
                entity.Property(e => e.ReceiveAmount)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("receive_amount");
                entity.Property(e => e.ReceiverCurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("receiver_currency_id");
                entity.Property(e => e.ReceiverCustomerId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("receiver_customer_id");
                entity.Property(e => e.ReceiverName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("receiver_name");
                entity.Property(e => e.RemoteOrderId)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("remote_order_id");
                entity.Property(e => e.SendAmount)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("send_amount");
                entity.Property(e => e.SenderCurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("sender_currency_id");
                entity.Property(e => e.SenderCustomerId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("sender_customer_id");
                entity.Property(e => e.SenderName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("sender_name");
                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("source");
                entity.Property(e => e.TransactionStateId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("transaction_state_id");
                entity.Property(e => e.TransferType)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("1=instant, 2=regular, 3=same_day etc.")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("transfer_type");
                entity.Property(e => e.Type)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("type 1 = b2b, 2 = c2c, 3=c2b, 4=b2c etc")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("type");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.Vat)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("vat");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_payment_methods");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("description");
                entity.Property(e => e.MethodName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("method_name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("must be soft delete, possible entries=> wallet, debit card, credit card etc")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_providers");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.ApiKey)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("api key and secret must be encrypted")
                    .HasColumnName("api_key");
                entity.Property(e => e.ApiSecret)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("api_secret");
                entity.Property(e => e.BaseUrl)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("base_url");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("code");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<ProviderCommission>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_provider_commissions");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.FromCurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("from_currency_id");
                entity.Property(e => e.ProviderId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("provider_id");
                entity.Property(e => e.ReceiverCommissionFixed)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("receiver_commission_fixed");
                entity.Property(e => e.ReceiverCommissionPercentage)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("receiver_commission_percentage");
                entity.Property(e => e.SenderCommissionFixed)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("sender_commission_fixed");
                entity.Property(e => e.SenderCommissionPercentage)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("sender_commission_percentage");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.ToCurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("to_currency_id");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<ProviderPayer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_provider_payers");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.ImtCountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_country_id");
                entity.Property(e => e.ImtCurrencyId)
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_currency_id");
                entity.Property(e => e.ImtProviderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_provider_id");
                entity.Property(e => e.ImtProviderServiceId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_provider_service_id");
                entity.Property(e => e.Increment)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("still not clear, asked client")
                    .HasColumnName("increment");
                entity.Property(e => e.Precision)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("for declaring precision point after decimal")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("precision");
                entity.Property(e => e.RemotePayerId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("remote_payer_id");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ProviderService>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_provider_services");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.ImtProviderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_provider_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("BankAccount, WalletTransfer etc")
                    .HasColumnName("name");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_quotations");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DestinationAmount)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("destination_amount");
                entity.Property(e => e.ImtDestinationCurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_destination_currency_id");
                entity.Property(e => e.ImtProviderId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_provider_id");
                entity.Property(e => e.ImtProviderServiceId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_provider_service_id");
                entity.Property(e => e.ImtSourceCountryId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_source_country_id");
                entity.Property(e => e.ImtSourceCurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("imt_source_currency_id");
                entity.Property(e => e.Mode)
                    .HasMaxLength(50)
                    .HasComment("DESTINATION_AMOUNT, SOURCE_AMOUNT")
                    .HasColumnName("mode");
                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("order_id");
                entity.Property(e => e.PayerId)
                    .HasMaxLength(50)
                    .HasColumnName("payer_id");
                entity.Property(e => e.SourceAmount)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("source_amount");
                entity.Property(e => e.TransactionType)
                    .HasMaxLength(10)
                    .HasComment("B2B,B2C,C2C,C2B")
                    .HasColumnName("transaction_type");
            });

            modelBuilder.Entity<Reason>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_reasons");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("code");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("description");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'0'")
                    .HasComment("default value 0 means \"Others\"")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("title");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_transactions", tb => tb.HasComment("transaction_type = 1,2,3; 1= send money, 2=receive money etc.transaction_id is sender table id.money_flow = 1/2; 1= incoming and 2 = outgoing, event_type = send money request, send money approved, send money rejected etc."));

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.Amount)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("amount");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("currency_id");
                entity.Property(e => e.CurrentBalance)
                    .HasPrecision(16, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("current_balance");
                entity.Property(e => e.CustomerId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("customer_id");
                entity.Property(e => e.Fee)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("fee");
                entity.Property(e => e.Gross)
                    .HasPrecision(12, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("gross");
                entity.Property(e => e.MoneyFlow)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("1 for incoming, 2 for outgoing")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("money_flow");
                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("payment_id");
                entity.Property(e => e.PreviousBalance)
                    .HasPrecision(16, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("previous_balance");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("send money request, send money approved, etc")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.TransactionId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("transaction_id");
                entity.Property(e => e.TransactionStateId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("transaction_state_id");
                entity.Property(e => e.TransactionType)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("transaction_type = 1 for send, 2 for receive")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("transaction_type");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<TransactionLimit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_transaction_limits");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.CurrencyId)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("currency_id");
                entity.Property(e => e.DailyTotalAmount)
                    .HasPrecision(16, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("daily_total_amount");
                entity.Property(e => e.DailyTotalNumber)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("daily_total_number");
                entity.Property(e => e.MonthlyTotalAmount)
                    .HasPrecision(16, 4)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("monthly_total_amount");
                entity.Property(e => e.MonthlyTotalNumber)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11)")
                    .HasColumnName("monthly_total_number");
                entity.Property(e => e.TransactionType)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("transaction_type");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
                entity.Property(e => e.UserCategory)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("user_category");
            });

            modelBuilder.Entity<TransactionState>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_transaction_states");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("1=completed, 2=pending, 3=approved, 4=")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("imt_transaction_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("created_by_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("send money, receive money, withdrawal etc")
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UpdatedById)
                    .HasDefaultValueSql("'NULL'")
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<ProviderErrorDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imt_provider_error_details");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("error_code");
            entity.Property(e => e.ErrorMessage)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("error_message");
            entity.Property(e => e.ImtProviderId)
                .HasColumnType("int(11)")
                .HasColumnName("imt_provider_id");
            entity.Property(e => e.ReferenceId)
                .HasComment("type-reference table primary key id")
                .HasColumnType("int(11)")
                .HasColumnName("reference_id");
            entity.Property(e => e.Type)
                .HasComment("1: quotation,2: money_transfer")
                .HasColumnType("tinyint(4)")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}