using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountManager> AccountManagers { get; set; } = null!;

    public virtual DbSet<AdminMakerChecker> AdminMakerCheckers { get; set; } = null!;

    public virtual DbSet<AdminNotification> AdminNotifications { get; set; } = null!;

    public virtual DbSet<Allocation> Allocations { get; set; } = null!;

    public virtual DbSet<Aml> Amls { get; set; } = null!;

    public virtual DbSet<AmlActiveRecord> AmlActiveRecords { get; set; } = null!;

    public virtual DbSet<AmlRule> AmlRules { get; set; } = null!;

    public virtual DbSet<AmlRuleAttribute> AmlRuleAttributes { get; set; } = null!;

    public virtual DbSet<AmlRuleAttributeValue> AmlRuleAttributeValues { get; set; } = null!;

    public virtual DbSet<AmlRuleViolationRecord> AmlRuleViolationRecords { get; set; } = null!;

    public virtual DbSet<Announcement> Announcements { get; set; } = null!;

    public virtual DbSet<ArchivedRequest> ArchievedRequests { get; set; } = null!;

    public virtual DbSet<ArchievedSale> ArchievedSales { get; set; } = null!;

    public virtual DbSet<ArchievedSaleBilling> ArchievedSaleBillings { get; set; } = null!;

    public virtual DbSet<ArchievedWalletLog> ArchievedWalletLogs { get; set; } = null!;

    public virtual DbSet<AuditTrail> AuditTrails { get; set; } = null!;

    public virtual DbSet<AwaitingRequest> AwaitingRequests { get; set; } = null!;

    public virtual DbSet<B2BPaymentHistory> B2bpaymentHistories { get; set; } = null!;

    public virtual DbSet<B2UPaymentHistory> B2uPaymentHistories { get; set; } = null!;

    public virtual DbSet<Bank> Banks { get; set; } = null!;

    public virtual DbSet<BankCardBrand> BankCardBrands { get; set; } = null!;

    public virtual DbSet<BankCot> BankCots { get; set; } = null!;

    public virtual DbSet<BankReferenceInformation> BankReferenceInformations { get; set; } = null!;

    public virtual DbSet<BinDetail> BinDetails { get; set; } = null!;

    public virtual DbSet<BinRangeQp> BinRangeQps { get; set; } = null!;

    public virtual DbSet<BinRangeResponse> BinRangeResponses { get; set; } = null!;

    public virtual DbSet<BinResponse> BinResponses { get; set; } = null!;

    public virtual DbSet<BinRussium> BinRussia { get; set; } = null!;

    public virtual DbSet<BinStatistic> BinStatistics { get; set; } = null!;

    public virtual DbSet<BinTurkey> BinTurkeys { get; set; } = null!;

    public virtual DbSet<BlockTimeSetting> BlockTimeSettings { get; set; } = null!;

    public virtual DbSet<BrandBankAccount> BrandBankAccounts { get; set; } = null!;

    public virtual DbSet<BulkChargebackHistory> BulkChargebackHistories { get; set; } = null!;

    public virtual DbSet<C2BHistory> C2bHistories { get; set; } = null!;

    public virtual DbSet<CardTokenRequest> CardTokenRequests { get; set; } = null!;

    public virtual DbSet<Cashout> Cashouts { get; set; } = null!;

    public virtual DbSet<CashoutBankSetting> CashoutBankSettings { get; set; } = null!;

    public virtual DbSet<CashoutFileHistory> CashoutFileHistories { get; set; } = null!;

    public virtual DbSet<Category> Categories { get; set; } = null!;

    public virtual DbSet<CCBlockList> CcBlockLists { get; set; } = null!;

    public virtual DbSet<ChangePasswordHistory> ChangePasswordHistories { get; set; } = null!;

    public virtual DbSet<Chat> Chats { get; set; } = null!;

    public virtual DbSet<ChatAttachment> ChatAttachments { get; set; } = null!;

    public virtual DbSet<ChatMessage> ChatMessages { get; set; } = null!;

    public virtual DbSet<ChatUser> ChatUsers { get; set; } = null!;

    public virtual DbSet<ChecklistControl> ChecklistControls { get; set; } = null!;

    public virtual DbSet<City> Cities { get; set; } = null!;

    public virtual DbSet<CommercialCardCommission> CommercialCardCommissions { get; set; } = null!;

    public virtual DbSet<Commission> Commissions { get; set; } = null!;

    public virtual DbSet<Company> Companies { get; set; } = null!;

    public virtual DbSet<Content> Contents { get; set; } = null!;

    public virtual DbSet<Country> Countries { get; set; } = null!;

    public virtual DbSet<CronjobLog> CronjobLogs { get; set; } = null!;

    public virtual DbSet<CronjobSetting> CronjobSettings { get; set; } = null!;

    public virtual DbSet<CurrenciesSetting> CurrenciesSettings { get; set; } = null!;

    public virtual DbSet<Currency> Currencies { get; set; } = null!;

    public virtual DbSet<CurrencyConversionRate> CurrencyConversionRates { get; set; } = null!;

    public virtual DbSet<CurrencyDepositMethod> CurrencyDepositMethods { get; set; } = null!;

    public virtual DbSet<CurrencyExchangeCommission> CurrencyExchangeCommissions { get; set; } = null!;

    public virtual DbSet<CurrencyExchangeRate> CurrencyExchangeRates { get; set; } = null!;

    public virtual DbSet<CurrencyWithdrawalMethod> CurrencyWithdrawalMethods { get; set; } = null!;

    public virtual DbSet<DataRow> DataRows { get; set; } = null!;

    public virtual DbSet<DataType> DataTypes { get; set; } = null!;

    public virtual DbSet<Deposit> Deposits { get; set; } = null!;

    public virtual DbSet<DepositMethod> DepositMethods { get; set; } = null!;

    public virtual DbSet<DirectPaymentLink> DirectPaymentLinks { get; set; } = null!;

    public virtual DbSet<DplAgreement> DplAgreements { get; set; } = null!;

    public virtual DbSet<DplChangeHistory> DplChangeHistories { get; set; } = null!;

    public virtual DbSet<DplRecurringSetting> DplRecurringSettings { get; set; } = null!;

    public virtual DbSet<DplResource> DplResources { get; set; } = null!;

    public virtual DbSet<DplSetting> DplSettings { get; set; } = null!;

    public virtual DbSet<DuplicateTesting> DuplicateTestings { get; set; } = null!;

    public virtual DbSet<ErrorMapping> ErrorMappings { get; set; } = null!;

    public virtual DbSet<Exchange> Exchanges { get; set; } = null!;

    public virtual DbSet<FailedJob> FailedJobs { get; set; } = null!;

    public virtual DbSet<FailedLoginList> FailedLoginLists { get; set; } = null!;

    public virtual DbSet<ForeignMastercardBin> ForeignMastercardBins { get; set; } = null!;

    public virtual DbSet<FpWalletTransactionEntity> FpWalletTransactionEntities { get; set; } = null!;

    public virtual DbSet<FraudRule> FraudRules { get; set; } = null!;

    public virtual DbSet<FullCardBlockList> FullCardBlockLists { get; set; } = null!;

    public virtual DbSet<GovBtransEphpycni> GovBtransEphpycnis { get; set; } = null!;

    public virtual DbSet<GovBtransEpkbb> GovBtransEpkbbs { get; set; } = null!;

    public virtual DbSet<GovBtransOkkib> GovBtransOkkibs { get; set; } = null!;

    public virtual DbSet<GovBtransPfRecord> GovBtransPfRecords { get; set; } = null!;

    public virtual DbSet<GovBtransReportHistory> GovBtransReportHistories { get; set; } = null!;

    public virtual DbSet<GovBtransSfp> GovBtransSfps { get; set; } = null!;

    public virtual DbSet<GovBtransYt> GovBtransYts { get; set; } = null!;

    public virtual DbSet<HolidaySetting> HolidaySettings { get; set; } = null!;

    public virtual DbSet<ImportedTransaction> ImportedTransactions { get; set; } = null!;

    public virtual DbSet<ImportedTransactionHistory> ImportedTransactionHistories { get; set; } = null!;

    public virtual DbSet<ImportedWithdrawal> ImportedWithdrawals { get; set; } = null!;

    public virtual DbSet<IncomingWalletEvent> IncomingWalletEvents { get; set; } = null!;

    public virtual DbSet<Integrator> Integrators { get; set; } = null!;

    public virtual DbSet<IntegratorInstallmentCommission> IntegratorInstallmentCommissions { get; set; } = null!;

    public virtual DbSet<IntegratorPermission> IntegratorPermissions { get; set; } = null!;

    public virtual DbSet<Ipv4> Ipv4s { get; set; } = null!;

    public virtual DbSet<Job> Jobs { get; set; } = null!;

    public virtual DbSet<JwtServiceCredential> JwtServiceCredentials { get; set; } = null!;

    public virtual DbSet<KbbVerificationRecord> KbbVerificationRecords { get; set; } = null!;

    public virtual DbSet<Kyc> Kycs { get; set; } = null!;

    public virtual DbSet<Laravel2step> Laravel2steps { get; set; } = null!;

    public virtual DbSet<MarketplaceItemMapping> MarketplaceItemMappings { get; set; } = null!;

    public virtual DbSet<MarketplaceSale> MarketplaceSales { get; set; } = null!;

    public virtual DbSet<MarketplaceSaleMapping> MarketplaceSaleMappings { get; set; } = null!;

    public virtual DbSet<Menu> Menus { get; set; } = null!;

    public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;

    public virtual DbSet<Merchant> Merchants { get; set; } = null!;

    public virtual DbSet<MerchantAgreement> MerchantAgreements { get; set; } = null!;

    public virtual DbSet<MerchantAgreementHistory> MerchantAgreementHistories { get; set; } = null!;

    public virtual DbSet<MerchantAllocation> MerchantAllocations { get; set; } = null!;

    public virtual DbSet<MerchantAnnouncement> MerchantAnnouncements { get; set; } = null!;

    public virtual DbSet<MerchantApplication> MerchantApplications { get; set; } = null!;

    public virtual DbSet<MerchantApplicationAssignmentSchedule> MerchantApplicationAssignmentSchedules { get; set; } = null!;

    public virtual DbSet<MerchantApplicationComment> MerchantApplicationComments { get; set; } = null!;

    public virtual DbSet<MerchantApplicationConversation> MerchantApplicationConversations { get; set; } = null!;

    public virtual DbSet<MerchantApplicationQuestion> MerchantApplicationQuestions { get; set; } = null!;

    public virtual DbSet<MerchantAutomaticReport> MerchantAutomaticReports { get; set; } = null!;

    public virtual DbSet<MerchantAutomaticWithdrawalSetting> MerchantAutomaticWithdrawalSettings { get; set; } = null!;

    public virtual DbSet<MerchantB2bSetting> MerchantB2bSettings { get; set; } = null!;

    public virtual DbSet<MerchantB2cSetting> MerchantB2cSettings { get; set; } = null!;

    public virtual DbSet<MerchantBankAccount> MerchantBankAccounts { get; set; } = null!;

    public virtual DbSet<MerchantBankCommission> MerchantBankCommissions { get; set; } = null!;

    public virtual DbSet<MerchantCardBlacklist> MerchantCardBlacklists { get; set; } = null!;

    public virtual DbSet<MerchantConfiguration> MerchantConfigurations { get; set; } = null!;

    public virtual DbSet<MerchantCustomizedCost> MerchantCustomizedCosts { get; set; } = null!;

    public virtual DbSet<MerchantCustomizedCostSetting> MerchantCustomizedCostSettings { get; set; } = null!;

    public virtual DbSet<MerchantDocument> MerchantDocuments { get; set; } = null!;

    public virtual DbSet<MerchantEmailReceiver> MerchantEmailReceivers { get; set; } = null!;

    public virtual DbSet<MerchantFraud> MerchantFrauds { get; set; } = null!;

    public virtual DbSet<MerchantFtpInfo> MerchantFtpInfos { get; set; } = null!;

    public virtual DbSet<MerchantIk> MerchantIks { get; set; } = null!;

    public virtual DbSet<MerchantIksTerminal> MerchantIksTerminals { get; set; } = null!;

    public virtual DbSet<MerchantIntegrator> MerchantIntegrators { get; set; } = null!;

    public virtual DbSet<MerchantIntegratorInstallmentCommission> MerchantIntegratorInstallmentCommissions { get; set; } = null!;

    public virtual DbSet<MerchantIpAssignment> MerchantIpAssaignments { get; set; } = null!;

    public virtual DbSet<MerchantNote> MerchantNotes { get; set; } = null!;

    public virtual DbSet<MerchantOnboardingApiSetting> MerchantOnboardingApiSettings { get; set; } = null!;

    public virtual DbSet<MerchantOnboardingPosSetting> MerchantOnboardingPosSettings { get; set; } = null!;

    public virtual DbSet<MerchantOperationCommission> MerchantOperationCommissions { get; set; } = null!;

    public virtual DbSet<MerchantOutgoingReportSchedule> MerchantOutgoingReportSchedules { get; set; } = null!;

    public virtual DbSet<MerchantPaybillOption> MerchantPaybillOptions { get; set; } = null!;

    public virtual DbSet<MerchantPaymentRecOption> MerchantPaymentRecOptions { get; set; } = null!;

    public virtual DbSet<MerchantPosCommission> MerchantPosCommissions { get; set; } = null!;

    public virtual DbSet<MerchantPosInstallmentSettlementSetting> MerchantPosInstallmentSettlementSettings { get; set; } = null!;

    public virtual DbSet<MerchantPosPfSetting> MerchantPosPfSettings { get; set; } = null!;

    public virtual DbSet<MerchantReportHistory> MerchantReportHistories { get; set; } = null!;

    public virtual DbSet<MerchantSale> MerchantSales { get; set; } = null!;

    public virtual DbSet<MerchantScheduleReport> MerchantScheduleReports { get; set; } = null!;

    public virtual DbSet<MerchantSetting> MerchantSettings { get; set; } = null!;

    public virtual DbSet<MerchantSettingImage> MerchantSettingImages { get; set; } = null!;

    public virtual DbSet<MerchantSocialLink> MerchantSocialLinks { get; set; } = null!;

    public virtual DbSet<MerchantTerminal> MerchantTerminals { get; set; } = null!;

    public virtual DbSet<MerchantTransactionLimit> MerchantTransactionLimits { get; set; } = null!;

    public virtual DbSet<MerchantVirtualAccount> MerchantVirtualAccounts { get; set; } = null!;

    public virtual DbSet<MerchantVirtualAccountWallet> MerchantVirtualAccountWallets { get; set; } = null!;

    public virtual DbSet<MerchantVirtualAccountWalletCard> MerchantVirtualAccountWalletCards { get; set; } = null!;

    public virtual DbSet<MerchantVknTcknBlacklist> MerchantVknTcknBlacklists { get; set; } = null!;

    public virtual DbSet<MerchantWebHookKey> MerchantWebHookKeys { get; set; } = null!;

    public virtual DbSet<MerchantYapiCredential> MerchantYapiCredentials { get; set; } = null!;

    public virtual DbSet<MerchantsCommission> MerchantsCommissions { get; set; } = null!;

    public virtual DbSet<MerchantsStatus> MerchantsStatuses { get; set; } = null!;

    public virtual DbSet<MetropolUser> MetropolUsers { get; set; } = null!;

    public virtual DbSet<Migration> Migrations { get; set; } = null!;

    public virtual DbSet<Module> Modules { get; set; } = null!;

    public virtual DbSet<Notification> Notifications { get; set; } = null!;

    public virtual DbSet<NotificationAutomation> NotificationAutomations { get; set; } = null!;

    public virtual DbSet<NotificationCategory> NotificationCategories { get; set; } = null!;

    public virtual DbSet<NotificationEvent> NotificationEvents { get; set; } = null!;

    public virtual DbSet<NotificationSubcategory> NotificationSubcategories { get; set; } = null!;

    public virtual DbSet<OauthAccessToken> OauthAccessTokens { get; set; } = null!;

    public virtual DbSet<OauthAuthCode> OauthAuthCodes { get; set; } = null!;

    public virtual DbSet<OauthClient> OauthClients { get; set; } = null!;

    public virtual DbSet<OauthPersonalAccessClient> OauthPersonalAccessClients { get; set; } = null!;

    public virtual DbSet<OauthRefreshToken> OauthRefreshTokens { get; set; } = null!;

    public virtual DbSet<Otpl> Otpls { get; set; } = null!;

    public virtual DbSet<OutGoingEmail> OutGoingEmails { get; set; } = null!;

    public virtual DbSet<OutGoingPushNotification> OutGoingPushNotifications { get; set; } = null!;

    public virtual DbSet<OutGoingSm> OutGoingSms { get; set; } = null!;

    public virtual DbSet<OutgoingCurlRequestRecord> OutgoingCurlRequestRecords { get; set; } = null!;

    public virtual DbSet<Page> Pages { get; set; } = null!;

    public virtual DbSet<PaidBill> PaidBills { get; set; } = null!;

    public virtual DbSet<PasswordReset> PasswordResets { get; set; } = null!;

    public virtual DbSet<PaybillOption> PaybillOptions { get; set; } = null!;

    public virtual DbSet<PaymentRecOption> PaymentRecOptions { get; set; } = null!;

    public virtual DbSet<Permission> Permissions { get; set; } = null!;

    public virtual DbSet<PermissionRole> PermissionRoles { get; set; } = null!;

    public virtual DbSet<PfHistory> PfHistories { get; set; } = null!;

    public virtual DbSet<PhysicalPosSetting> PhysicalPosSettings { get; set; } = null!;

    public virtual DbSet<Pos> Pos { get; set; } = null!;

    public virtual DbSet<PosBankCardBlackList> PosBankCardBlackLists { get; set; } = null!;

    public virtual DbSet<PosCampaign> PosCampaigns { get; set; } = null!;

    public virtual DbSet<PosCampaignsInstallment> PosCampaignsInstallments { get; set; } = null!;

    public virtual DbSet<PosInstallment> PosInstallments { get; set; } = null!;

    public virtual DbSet<PosInstallmentSettlementSetting> PosInstallmentSettlementSettings { get; set; } = null!;

    public virtual DbSet<PosIssuerTag> PosIssuerTags { get; set; } = null!;

    public virtual DbSet<PosRedirection> PosRedirections { get; set; } = null!;

    public virtual DbSet<PosRiskyCountry> PosRiskyCountries { get; set; } = null!;

    public virtual DbSet<Post> Posts { get; set; } = null!;

    public virtual DbSet<ProfileInfo> Profiles { get; set; } = null!;

    public virtual DbSet<ProviderErrorCode> ProviderErrorCodes { get; set; } = null!;

    public virtual DbSet<Purchase> Purchases { get; set; } = null!;

    public virtual DbSet<RandomCustomerId> RandomCustomerIds { get; set; } = null!;

    public virtual DbSet<Reason> Reasons { get; set; } = null!;

    public virtual DbSet<ReasonCategory> ReasonCategories { get; set; } = null!;

    public virtual DbSet<Receife> Receives { get; set; } = null!;

    public virtual DbSet<RefundHistory> RefundHistories { get; set; } = null!;

    public virtual DbSet<RefundPhysicalPo> RefundPhysicalPos { get; set; } = null!;

    public virtual DbSet<PurchaseRequest> Requests { get; set; } = null!;

    public virtual DbSet<RequestMoney> RequestMoneys { get; set; } = null!;

    public virtual DbSet<Role> Roles { get; set; } = null!;

    public virtual DbSet<RolePage> RolePages { get; set; } = null!;

    public virtual DbSet<RolePageHistory> RolePageHistories { get; set; } = null!;

    public virtual DbSet<RoleSetting> RoleSettings { get; set; } = null!;

    public virtual DbSet<RollingBalance> RollingBalances { get; set; } = null!;

    public virtual DbSet<RollingReserve> RollingReserves { get; set; } = null!;

    public virtual DbSet<Sale> Sales { get; set; } = null!;

    public virtual DbSet<SaleActiveFraud> SaleActiveFrauds { get; set; } = null!;

    public virtual DbSet<SaleAsynchronousProcess> SaleAsynchronousProcesses { get; set; } = null!;

    public virtual DbSet<SaleBilling> SaleBillings { get; set; } = null!;

    public virtual DbSet<SaleCurrencyConversion> SaleCurrencyConversions { get; set; } = null!;

    public virtual DbSet<SaleErrorDetail> SaleErrorDetails { get; set; } = null!;

    public virtual DbSet<SaleFailAlert> SaleFailAlerts { get; set; } = null!;

    public virtual DbSet<SaleFraud> SaleFrauds { get; set; } = null!;

    public virtual DbSet<SaleFraudRecord> SaleFraudRecords { get; set; } = null!;

    public virtual DbSet<SaleInfoOutgoingReport> SaleInfoOutgoingReports { get; set; } = null!;

    public virtual DbSet<SaleIntegrator> SaleIntegrators { get; set; } = null!;

    public virtual DbSet<SalePosRedirection> SalePosRedirections { get; set; } = null!;

    public virtual DbSet<SaleProperty> SaleProperties { get; set; } = null!;

    public virtual DbSet<SaleRecurring> SaleRecurrings { get; set; } = null!;

    public virtual DbSet<SaleRecurringCard> SaleRecurringCards { get; set; } = null!;

    public virtual DbSet<SaleRecurringHistory> SaleRecurringHistories { get; set; } = null!;

    public virtual DbSet<SaleRecurringPaymentSchedule> SaleRecurringPaymentSchedules { get; set; } = null!;

    public virtual DbSet<SaleReport> SaleReports { get; set; } = null!;

    public virtual DbSet<SaleTaxInfo> SaleTaxInfos { get; set; } = null!;

    public virtual DbSet<SaleWalletHistory> SaleWalletHistories { get; set; } = null!;

    public virtual DbSet<SalesPfRecord> SalesPfRecords { get; set; } = null!;

    public virtual DbSet<SalesSettlement> SalesSettlements { get; set; } = null!;

    public virtual DbSet<SavedCard> SavedCards { get; set; } = null!;

    public virtual DbSet<Sector> Sectors { get; set; } = null!;

    public virtual DbSet<SecurityImage> SecurityImages { get; set; } = null!;

    public virtual DbSet<Send> Sends { get; set; } = null!;

    public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;

    public virtual DbSet<Setting> Settings { get; set; } = null!;

    public virtual DbSet<Settlement> Settlements { get; set; } = null!;

    public virtual DbSet<SinglePaymentMerchantCommission> SinglePaymentMerchantCommissions { get; set; } = null!;

    public virtual DbSet<SmsArchive> SmsArchives { get; set; } = null!;

    public virtual DbSet<SplitAccount> SplitAccounts { get; set; } = null!;

    public virtual DbSet<StaticContent> StaticContents { get; set; } = null!;

    public virtual DbSet<Statistic> Statistics { get; set; } = null!;

    public virtual DbSet<SubMerchant> SubMerchants { get; set; } = null!;

    public virtual DbSet<SubMerchantAutomaticWithdrawalSetting> SubMerchantAutomaticWithdrawalSettings { get; set; } = null!;

    public virtual DbSet<SubMerchantPf> SubMerchantPfs { get; set; } = null!;

    public virtual DbSet<SubModule> SubModules { get; set; } = null!;

    public virtual DbSet<TemporaryTransaction> TemporaryTransactions { get; set; } = null!;

    public virtual DbSet<TestPo> TestPos { get; set; } = null!;

    public virtual DbSet<TestPosHistory> TestPosHistories { get; set; } = null!;

    public virtual DbSet<TestPosInformation> TestPosInformations { get; set; } = null!;

    public virtual DbSet<Ticket> Tickets { get; set; } = null!;

    public virtual DbSet<TicketConversation> TicketConversations { get; set; } = null!;

    public virtual DbSet<Ticketcategory> Ticketcategories { get; set; } = null!;

    public virtual DbSet<Ticketcomment> Ticketcomments { get; set; } = null!;

    public virtual DbSet<Timezone> Timezones { get; set; } = null!;

    public virtual DbSet<TmpAdvanceCommission> TmpAdvanceCommissions { get; set; } = null!;

    public virtual DbSet<TmpBankResponse> TmpBankResponses { get; set; } = null!;

    public virtual DbSet<TmpFile> TmpFiles { get; set; } = null!;

    public virtual DbSet<TmpGovBtransReportDatum> TmpGovBtransReportData { get; set; } = null!;

    public virtual DbSet<TmpMerchantHashKey> TmpMerchantHashKeys { get; set; } = null!;

    public virtual DbSet<TmpMerchantPosCommission> TmpMerchantPosCommissions { get; set; } = null!;

    public virtual DbSet<TmpObjectStorage> TmpObjectStorages { get; set; } = null!;

    public virtual DbSet<TmpOrderStatus> TmpOrderStatuses { get; set; } = null!;

    public virtual DbSet<TmpPaymentRecord> TmpPaymentRecords { get; set; } = null!;

    public virtual DbSet<TmpPaymentRecordAction> TmpPaymentRecordActions { get; set; } = null!;

    public virtual DbSet<TmpPo> TmpPos { get; set; } = null!;

    public virtual DbSet<TmpPosInstallment> TmpPosInstallments { get; set; } = null!;

    public virtual DbSet<TmpPosIssuerTag> TmpPosIssuerTags { get; set; } = null!;

    public virtual DbSet<TmpRefundRequest> TmpRefundRequests { get; set; } = null!;

    public virtual DbSet<TmpSaleAutomation> TmpSaleAutomations { get; set; } = null!;

    public virtual DbSet<TmpWixForm> TmpWixForms { get; set; } = null!;

    public virtual DbSet<TmpYapiReport> TmpYapiReports { get; set; } = null!;

    public virtual DbSet<TransactionState> TransactionStates { get; set; } = null!;

    public virtual DbSet<Transactionable> Transactionables { get; set; } = null!;

    public virtual DbSet<Translation> Translations { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    public virtual DbSet<UserActionHistory> UserActionHistories { get; set; } = null!;

    public virtual DbSet<UserAnnouncement> UserAnnouncements { get; set; } = null!;

    public virtual DbSet<UserAwaitingCategory> UserAwaitingCategories { get; set; } = null!;

    public virtual DbSet<UserBankAccount> UserBankAccounts { get; set; } = null!;

    public virtual DbSet<UserChangeHistory> UserChangeHistories { get; set; } = null!;

    public virtual DbSet<UserCurrenciesLimit> UserCurrenciesLimits { get; set; } = null!;

    public virtual DbSet<UserDevice> UserDevices { get; set; } = null!;

    public virtual DbSet<UserDocument> UserDocuments { get; set; } = null!;

    public virtual DbSet<UserFavouriteOperation> UserFavouriteOperations { get; set; } = null!;

    public virtual DbSet<UserHideMerchant> UserHideMerchants { get; set; } = null!;

    public virtual DbSet<UserLoginAlertSetting> UserLoginAlertSettings { get; set; } = null!;

    public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

    public virtual DbSet<UserPushNotification> UserPushNotifications { get; set; } = null!;

    public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

    public virtual DbSet<UserSetting> UserSettings { get; set; } = null!;

    public virtual DbSet<UserTrustedDevice> UserTrustedDevices { get; set; } = null!;

    public virtual DbSet<UserUsergroup> UserUsergroups { get; set; } = null!;

    public virtual DbSet<UserUsergroupSetting> UserUsergroupSettings { get; set; } = null!;

    public virtual DbSet<UserViewedNotification> UserViewedNotifications { get; set; } = null!;

    public virtual DbSet<Usergroup> Usergroups { get; set; } = null!;

    public virtual DbSet<UsergroupNotificationSubcategory> UsergroupNotificationSubcategories { get; set; } = null!;

    public virtual DbSet<UsergroupRole> UsergroupRoles { get; set; } = null!;

    public virtual DbSet<UsertypeSubmodule> UsertypeSubmodules { get; set; } = null!;

    public virtual DbSet<VirtualAccountMoneytransferRequest> VirtualAccountMoneytransferRequests { get; set; } = null!;

    public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

    public virtual DbSet<Wallet> Wallets { get; set; } = null!;

    public virtual DbSet<WalletAnnouncement> WalletAnnouncements { get; set; } = null!;

    public virtual DbSet<WalletGateSetting> WalletGateSettings { get; set; } = null!;

    public virtual DbSet<WalletLog> WalletLogs { get; set; } = null!;

    public virtual DbSet<Withdrawal> Withdrawals { get; set; } = null!;

    public virtual DbSet<WithdrawalBankName> WithdrawalBankNames { get; set; } = null!;

    public virtual DbSet<WithdrawalMethod> WithdrawalMethods { get; set; } = null!;

    public virtual DbSet<WithdrawalOperation> WithdrawalOperations { get; set; } = null!;

    public virtual DbSet<WithdrawalOperationsOutgoing> WithdrawalOperationsOutgoings { get; set; } = null!;

    public virtual DbSet<WithdrawalSavedAccount> WithdrawalSavedAccounts { get; set; } = null!;

    public virtual DbSet<WixStateData> WixStateDatas { get; set; } = null!;

    public virtual DbSet<WrongPasswordHistory> WrongPasswordHistories { get; set; } = null!;

    public virtual DbSet<YapiCommission> YapiCommissions { get; set; } = null!;

    public virtual DbSet<YapiToken> YapiTokens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_unicode_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<AccountManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("account_manager")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.MerchantId, e.UserId }, "unique_index").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AdminMakerChecker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin_maker_checker");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasDefaultValueSql("'CREATE'")
                .HasColumnType("enum('CREATE','UPDATE','DELETE')")
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(191)
                .HasColumnName("created_by_name");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.FileParams)
                .HasMaxLength(255)
                .HasColumnName("file_params");
            entity.Property(e => e.GetParams)
                .HasColumnType("text")
                .HasColumnName("get_params");
            entity.Property(e => e.InputParams).HasColumnName("input_params");
            entity.Property(e => e.ProcessMethod)
                .HasDefaultValueSql("'POST'")
                .HasColumnType("enum('POST','GET','DELETE','PUT')")
                .HasColumnName("process_method");
            entity.Property(e => e.ProcessRoute)
                .HasMaxLength(255)
                .HasColumnName("process_route");
            entity.Property(e => e.Section)
                .HasMaxLength(255)
                .HasColumnName("section");
            entity.Property(e => e.Status)
                .HasComment("0=PENDING, 1=APPROVED, 2=REJECTED")
                .HasColumnName("status");
            entity.Property(e => e.UniqueString)
                .HasMaxLength(100)
                .HasColumnName("unique_string");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_id");
            entity.Property(e => e.UpdatedByName)
                .HasMaxLength(191)
                .HasColumnName("updated_by_name");
        });

        modelBuilder.Entity<AdminNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("admin_notifications")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DataEn)
                .HasColumnType("text")
                .HasColumnName("data_en");
            entity.Property(e => e.DataTr)
                .HasColumnType("text")
                .HasColumnName("data_tr");
            entity.Property(e => e.IsEmail).HasColumnName("is_email");
            entity.Property(e => e.IsPush).HasColumnName("is_push");
            entity.Property(e => e.IsRead)
                .HasComment("'0 => Not Read, 1 => Readed'")
                .HasColumnName("is_read");
            entity.Property(e => e.IsSms).HasColumnName("is_sms");
            entity.Property(e => e.NotificationSubcategoryId).HasColumnName("notification_subcategory_id");
            entity.Property(e => e.ReadAt)
                .HasColumnType("datetime")
                .HasColumnName("read_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<Allocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("allocations")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountLimit)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount_limit");
            entity.Property(e => e.CardType)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>all, 1=>credit card, 2=> debit card")
                .HasColumnName("card_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FromTime)
                .HasColumnType("datetime")
                .HasColumnName("from_time");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id");
            entity.Property(e => e.PosName)
                .HasMaxLength(150)
                .HasColumnName("pos_name");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(50)
                .HasColumnName("program_name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1-active;0-inactive;")
                .HasColumnName("status");
            entity.Property(e => e.ToTime)
                .HasColumnType("datetime")
                .HasColumnName("to_time");
            entity.Property(e => e.TransactionLimit).HasColumnName("transaction_limit");
            entity.Property(e => e.TransactionType)
                .HasComment("0->all,1->debit card,2->credit card")
                .HasColumnName("transaction_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Aml>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("amls")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionByIp)
                .HasMaxLength(191)
                .HasColumnName("action_by_ip");
            entity.Property(e => e.ActionByUserId).HasColumnName("action_by_user_id");
            entity.Property(e => e.ActionDatetime)
                .HasColumnType("datetime")
                .HasColumnName("action_datetime");
            entity.Property(e => e.AmlApprovalStatus)
                .HasDefaultValueSql("'3'")
                .HasComment("1=>completed, 2=> Rejected, 3=>pending, 4=>Stand By")
                .HasColumnName("aml_approval_status");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CaseNo).HasColumnName("case_no");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.InputData)
                .HasColumnType("text")
                .HasColumnName("input_data");
            entity.Property(e => e.Panel)
                .HasDefaultValueSql("'0'")
                .HasComment("Old AML => 0, User Panel => 1, Admin Panel => 2, CCPayment Panel => 3, Merchant Panel => 4")
                .HasColumnName("panel");
            entity.Property(e => e.ReceiverTransactionableId).HasColumnName("receiver_transactionable_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .HasColumnName("remarks");
            entity.Property(e => e.ToUserEmail)
                .HasMaxLength(191)
                .HasColumnName("to_user_email");
            entity.Property(e => e.ToUserId).HasColumnName("to_user_id");
            entity.Property(e => e.ToUserName)
                .HasMaxLength(191)
                .HasColumnName("to_user_name");
            entity.Property(e => e.ToUserPhone)
                .HasMaxLength(191)
                .HasColumnName("to_user_phone");
            entity.Property(e => e.TransactionableId).HasColumnName("transactionable_id");
            entity.Property(e => e.TransactionableType)
                .HasMaxLength(191)
                .HasColumnName("transactionable_type");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Old AML, 2 => New AML Rule UnitOfWork")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(191)
                .HasColumnName("user_email");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(191)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(191)
                .HasColumnName("user_phone");
        });

        modelBuilder.Entity<AmlActiveRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aml_active_records")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionByIp)
                .HasMaxLength(191)
                .HasColumnName("action_by_ip");
            entity.Property(e => e.ActionByUserId).HasColumnName("action_by_user_id");
            entity.Property(e => e.ActionDatetime)
                .HasColumnType("datetime")
                .HasColumnName("action_datetime");
            entity.Property(e => e.AmlApprovalStatus)
                .HasDefaultValueSql("'3'")
                .HasComment("1=>completed, 2=> Rejected, 3=>pending, 4=>Stand By")
                .HasColumnName("aml_approval_status");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CaseNo).HasColumnName("case_no");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.InputData)
                .HasColumnType("text")
                .HasColumnName("input_data");
            entity.Property(e => e.Panel)
                .HasDefaultValueSql("'0'")
                .HasComment("Old AML => 0, User Panel => 1, Admin Panel => 2, CCPayment Panel => 3, Merchant Panel => 4")
                .HasColumnName("panel");
            entity.Property(e => e.ReceiverTransactionableId).HasColumnName("receiver_transactionable_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .HasColumnName("remarks");
            entity.Property(e => e.ToUserEmail)
                .HasMaxLength(191)
                .HasColumnName("to_user_email");
            entity.Property(e => e.ToUserId).HasColumnName("to_user_id");
            entity.Property(e => e.ToUserName)
                .HasMaxLength(191)
                .HasColumnName("to_user_name");
            entity.Property(e => e.ToUserPhone)
                .HasMaxLength(191)
                .HasColumnName("to_user_phone");
            entity.Property(e => e.TransactionableId).HasColumnName("transactionable_id");
            entity.Property(e => e.TransactionableType)
                .HasMaxLength(191)
                .HasColumnName("transactionable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(191)
                .HasColumnName("user_email");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(191)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(191)
                .HasColumnName("user_phone");
            entity.Property(e => e.ViolationRecords)
                .HasComment("JSON formatted violation record string")
                .HasColumnType("text")
                .HasColumnName("violation_records");
        });

        modelBuilder.Entity<AmlRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aml_rules")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "aml_rule_code_unique_index").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("Rule unique code.(Constant Value)")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Active, 0 => Inactive")
                .HasColumnName("status");
            entity.Property(e => e.TransactionCodes)
                .HasMaxLength(255)
                .HasComment("Codes of transactions(Constants value)")
                .HasColumnName("transaction_codes");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<AmlRuleAttribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aml_rule_attributes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmlRuleId).HasColumnName("aml_rule_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("Unique code for role attributes(Constant Value)")
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasDefaultValueSql("'text'")
                .HasComment("Type must be format of input field")
                .HasColumnName("type");
        });

        modelBuilder.Entity<AmlRuleAttributeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aml_rule_attribute_values")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmlRuleAttributeId).HasColumnName("aml_rule_attribute_id");
            entity.Property(e => e.AmlRuleId).HasColumnName("aml_rule_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.RuleCategory)
                .HasDefaultValueSql("'2'")
                .HasComment("1 -> Active, 2 -> Passive")
                .HasColumnName("rule_category");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Active, 0 => Inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UserCategories)
                .HasMaxLength(255)
                .HasComment("User Categories in Comma Separated way. Example: 1,2 ")
                .HasColumnName("user_categories");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .HasComment("Value of rule attribute")
                .HasColumnName("value");
        });

        modelBuilder.Entity<AmlRuleViolationRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aml_rule_violation_records")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmlId).HasColumnName("aml_id");
            entity.Property(e => e.AmlRuleId).HasColumnName("aml_rule_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasComment("Type of transactions")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("announcements")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("admin_id");
            entity.Property(e => e.AdminName)
                .HasMaxLength(191)
                .HasColumnName("admin_name");
            entity.Property(e => e.AnnouncementDate)
                .HasColumnType("datetime")
                .HasColumnName("announcement_date");
            entity.Property(e => e.AnnouncementEnd)
                .HasColumnType("datetime")
                .HasColumnName("announcement_end");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EmailAttachment)
                .HasMaxLength(191)
                .HasColumnName("email_attachment");
            entity.Property(e => e.EnBody)
                .HasColumnType("text")
                .HasColumnName("en_body");
            entity.Property(e => e.EnSubject)
                .HasMaxLength(191)
                .HasColumnName("en_subject");
            entity.Property(e => e.IsEmail)
                .HasDefaultValueSql("'0'")
                .HasComment("1=yes, 0=no")
                .HasColumnName("is_email");
            entity.Property(e => e.IsPanel)
                .HasDefaultValueSql("'0'")
                .HasComment("1=yes, 0=no")
                .HasColumnName("is_panel");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasComment("merchant id of receivers submerchant")
                .HasColumnName("merchant_id");
            entity.Property(e => e.PanelAttachment)
                .HasMaxLength(191)
                .HasColumnName("panel_attachment");
            entity.Property(e => e.ReceiversId)
                .HasComment("list of receivers id")
                .HasColumnType("text")
                .HasColumnName("receivers_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'2'")
                .HasComment("2=active, 1=inactive")
                .HasColumnName("status");
            entity.Property(e => e.TrBody)
                .HasColumnType("text")
                .HasColumnName("tr_body");
            entity.Property(e => e.TrSubject)
                .HasMaxLength(191)
                .HasColumnName("tr_subject");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'2'")
                .HasComment("0=customer, 2=merchant, 3 = submerchant")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ArchivedRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("archieved_requests")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.MerchantId, "merchant_id_index");

            entity.HasIndex(e => e.Ref, "requests_ref_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(255)
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.Ip)
                .HasMaxLength(45)
                .HasColumnName("ip");
            entity.Property(e => e.IsDuplicateInvoice)
                .HasDefaultValueSql("'0'")
                .HasComment("For Duplicate Purchase Request\r\n0 = No Duplicate\r\n1 = Found Duplicate\r\n2 = Cacnelled In Bank\r\n3 = Tmp Refund Request Created")
                .HasColumnName("is_duplicate_invoice");
            entity.Property(e => e.IsExpired).HasColumnName("is_expired");
            entity.Property(e => e.Lang)
                .HasMaxLength(4)
                .HasColumnName("lang");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasComment("Merchant Id of a Merchant")
                .HasColumnName("merchant_id");
            entity.Property(e => e.MerchantKey)
                .HasMaxLength(255)
                .HasColumnName("merchant_key");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.MobilePaymentStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("mobile_payment_status");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("order_id");
            entity.Property(e => e.Ref)
                .HasMaxLength(50)
                .HasColumnName("ref")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ArchievedSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("archieved_sales")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminForceChargebackDocument)
                .HasMaxLength(255)
                .HasComment("force chargeback document")
                .HasColumnName("admin_force_chargeback_document");
            entity.Property(e => e.AdminForceChargebackExplanation)
                .HasMaxLength(255)
                .HasComment("force chargeback reason")
                .HasColumnName("admin_force_chargeback_explanation");
            entity.Property(e => e.AdminProcessDate)
                .HasColumnType("timestamp")
                .HasColumnName("admin_process_date");
            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(20)
                .HasColumnName("auth_code")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.CardHolderBank)
                .HasMaxLength(100)
                .HasColumnName("card_holder_bank");
            entity.Property(e => e.CardIssuerName)
                .HasMaxLength(100)
                .HasColumnName("card_issuer_name");
            entity.Property(e => e.CardProgram)
                .HasMaxLength(50)
                .HasColumnName("card_program");
            entity.Property(e => e.ChargebackRejectExplanation)
                .HasMaxLength(255)
                .HasColumnName("chargeback_reject_explanation");
            entity.Property(e => e.CommissionForInstallment)
                .HasMaxLength(100)
                .HasColumnName("commission_for_installment");
            entity.Property(e => e.Cost)
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedAtInt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_at_int");
            entity.Property(e => e.CreditCardNo)
                .HasMaxLength(70)
                .HasColumnName("credit_card_no");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.Document)
                .HasMaxLength(255)
                .HasColumnName("document");
            entity.Property(e => e.DplId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("dpl_id");
            entity.Property(e => e.EndUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("end_user_id");
            entity.Property(e => e.Fee)
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(100)
                .HasColumnName("gsm_number");
            entity.Property(e => e.HostReferenceId)
                .HasMaxLength(50)
                .HasComment("host_refernce_id from provider response")
                .HasColumnName("host_reference_id");
            entity.Property(e => e.Installment).HasColumnName("installment");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("ip");
            entity.Property(e => e.IsBankRefundFailed)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not tried yet or pass, 1 = tried and failed")
                .HasColumnName("is_bank_refund_failed");
            entity.Property(e => e.IsComissionFromUser)
                .HasComment("0 => exiting flow\r\n1 => new calculation with user fee brutally change\r\n2 => new calculation with user fee brutally change as zero")
                .HasColumnName("is_comission_from_user");
            entity.Property(e => e.IsCvvLess)
                .HasComment("0 => with cvv\r\n1 => without cvv")
                .HasColumnName("is_cvv_less");
            entity.Property(e => e.IsDuplicateInvoice)
                .HasDefaultValueSql("'0'")
                .HasComment("If duplicate invoice allowed merchant comes with duplicate invoice we will update all the sales with same invoice_id and merchant_id with 1.\r\n0 = No Duplicate\r\n1 = Found Duplicate\r\n2 = Cacnelled In Bank\r\n3 = Tmp Refund Request Created\r\n")
                .HasColumnName("is_duplicate_invoice");
            entity.Property(e => e.IsInstallmentWiseSettlement)
                .HasDefaultValueSql("'0'")
                .HasComment("To determine if sale settlement is installment wise")
                .HasColumnName("is_installment_wise_settlement");
            entity.Property(e => e.IssuerName)
                .HasMaxLength(100)
                .HasColumnName("issuer_name");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.MaturityPeriod)
                .HasDefaultValueSql("'0'")
                .HasColumnName("maturity_period");
            entity.Property(e => e.MdStatus)
                .HasDefaultValueSql("'-1'")
                .HasComment("mdStatus from bank response ranges from 0-9\r\n0: Card verification failed, do not proceed\r\n1: Verification successful, you can continue with the transaction\r\n2: Card holder or bank is not registered in the system\r\n3: The bank of the card is not registered in the system\r\n4: Verification attempt, cardholder has chosen to register with the system\r\nlater\r\n5: Unable to verify\r\n6: 3-D Secure error\r\n7: System error\r\n8: Unknown card no\r\n9: Member Merchant not registered to 3D-Secure system (merchant or\r\nterminal number is not registered on the back as 3d) ")
                .HasColumnName("md_status");
            entity.Property(e => e.MerchantCommission)
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_commission");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(100)
                .HasColumnName("merchant_name")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'3'")
                .HasColumnName("migration_status");
            entity.Property(e => e.Net)
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.Operator)
                .HasMaxLength(50)
                .HasColumnName("operator");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.PayByTokenFee)
                .HasComment("this amount will be calculated from the percentage and fixed on merchant commission tab")
                .HasColumnType("double(12,4)")
                .HasColumnName("pay_by_token_fee");
            entity.Property(e => e.PaymentCompletedBy)
                .HasDefaultValueSql("'1'")
                .HasComment("This is the source to know the initiator of completePayment (2nd step) of a payment model\r\nComplete Payment By\r\n1 = App\r\n2 = Merchant\r\n")
                .HasColumnName("payment_completed_by");
            entity.Property(e => e.PaymentFrequency)
                .HasDefaultValueSql("'0'")
                .HasColumnName("payment_frequency");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.PaymentSource)
                .HasComment("1=3D branding and paid by CC, 2= 2D branding and paid by CC, 3 = Mobile payment, 4 = wallet payment, 5 = white label 3D, 6=whiite label 2D, 7 = Redirected white label 3D, 8 = Redirected white label 2D, 9 = DPL 3d, 10 = DPL 2d")
                .HasColumnName("payment_source");
            entity.Property(e => e.PaymentTypeId)
                .HasComment("1=>credit card, 2=> mobile, 3=>wallet, 4=>depositEFT")
                .HasColumnName("payment_type_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.PosName)
                .HasMaxLength(50)
                .HasColumnName("pos_name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("double(12,4)")
                .HasColumnName("product_price");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.RecurringId)
                .HasComment("0 = Sale, 1 = Recurring, 2 = DPL")
                .HasColumnName("recurring_id");
            entity.Property(e => e.RefundReason)
                .HasMaxLength(255)
                .HasColumnName("refund_reason");
            entity.Property(e => e.RefundRequestAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_request_amount");
            entity.Property(e => e.RefundRequestDate)
                .HasColumnType("timestamp")
                .HasColumnName("refund_request_date");
            entity.Property(e => e.RefundedChargebackFee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("refunded_chargeback_fee");
            entity.Property(e => e.RemoteOrderId)
                .HasMaxLength(40)
                .HasColumnName("remote_order_id");
            entity.Property(e => e.RemoteTransactionDatetime)
                .HasColumnType("datetime")
                .HasColumnName("remote_transaction_datetime");
            entity.Property(e => e.Result)
                .HasMaxLength(255)
                .HasColumnName("result")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.RollingAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("rolling_amount");
            entity.Property(e => e.SaleType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=auth , 2=PreAuth")
                .HasColumnName("sale_type");
            entity.Property(e => e.SaleVersion)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_version");
            entity.Property(e => e.SaleWebHookKey)
                .HasMaxLength(100)
                .HasColumnName("sale_web_hook_key");
            entity.Property(e => e.SettlementDateBank)
                .HasColumnType("timestamp")
                .HasColumnName("settlement_date_bank");
            entity.Property(e => e.SettlementDateMerchant)
                .HasColumnType("timestamp")
                .HasColumnName("settlement_date_merchant");
            entity.Property(e => e.TotalRefundedAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_refunded_amount");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedAtInt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_at_int");
            entity.Property(e => e.UserCommission)
                .HasColumnType("double(12,4)")
                .HasColumnName("user_commission");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name")
                .UseCollation("utf8mb3_unicode_ci");
        });

        modelBuilder.Entity<ArchievedSaleBilling>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("archieved_sale_billings")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillAddress1)
                .HasMaxLength(100)
                .HasColumnName("bill_address1")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillAddress2)
                .HasMaxLength(100)
                .HasColumnName("bill_address2")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillCity)
                .HasMaxLength(30)
                .HasColumnName("bill_city")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillCountry)
                .HasMaxLength(20)
                .HasColumnName("bill_country")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillEmail)
                .HasMaxLength(25)
                .HasColumnName("bill_email")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillName)
                .HasMaxLength(30)
                .HasColumnName("bill_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillPhone)
                .HasMaxLength(20)
                .HasColumnName("bill_phone");
            entity.Property(e => e.BillPostcode)
                .HasMaxLength(10)
                .HasColumnName("bill_postcode");
            entity.Property(e => e.BillState)
                .HasMaxLength(30)
                .HasColumnName("bill_state")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillSurname)
                .HasMaxLength(90)
                .HasColumnName("bill_surname")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillTaxNo)
                .HasMaxLength(100)
                .HasColumnName("bill_tax_no")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillTaxOffice)
                .HasMaxLength(150)
                .HasColumnName("bill_tax_office")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillTckn)
                .HasMaxLength(50)
                .HasColumnName("bill_tckn")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(120)
                .HasColumnName("card_holder_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(70)
                .HasColumnName("card_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasComment("created by merchant user id")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(191)
                .HasComment("created by merchant user name")
                .HasColumnName("created_by_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CustomerType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("customer_type");
            entity.Property(e => e.Cvv)
                .HasMaxLength(50)
                .HasColumnName("cvv");
            entity.Property(e => e.ExpiryMonth)
                .HasMaxLength(50)
                .HasColumnName("expiry_month");
            entity.Property(e => e.ExpiryYear)
                .HasMaxLength(50)
                .HasColumnName("expiry_year");
            entity.Property(e => e.ExtraCardHolderName)
                .HasMaxLength(120)
                .HasColumnName("extra_card_holder_name");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MigrationStatus).HasColumnName("migration_status");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ArchievedWalletLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("archieved_wallet_logs")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.UniqueString, "unique_string").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionName)
                .HasMaxLength(30)
                .HasColumnName("action_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.AfterAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("after_amount");
            entity.Property(e => e.AfterLog)
                .HasColumnType("text")
                .HasColumnName("after_log");
            entity.Property(e => e.AfterNonwithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("after_nonwithdrawable_amount");
            entity.Property(e => e.AfterRollingAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("after_rolling_amount");
            entity.Property(e => e.AfterWithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("after_withdrawable_amount");
            entity.Property(e => e.BeforeAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("before_amount");
            entity.Property(e => e.BeforeLog)
                .HasColumnType("text")
                .HasColumnName("before_log");
            entity.Property(e => e.BeforeNonwithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("before_nonwithdrawable_amount");
            entity.Property(e => e.BeforeRollingAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("before_rolling_amount");
            entity.Property(e => e.BeforeWithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("before_withdrawable_amount");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EffectAmount)
                .HasMaxLength(15)
                .HasColumnName("effect_amount");
            entity.Property(e => e.EffectNonwithdrawableAmount)
                .HasMaxLength(15)
                .HasColumnName("effect_nonwithdrawable_amount");
            entity.Property(e => e.EffectRollingAmount)
                .HasMaxLength(15)
                .HasColumnName("effect_rolling_amount");
            entity.Property(e => e.EffectWithdrawableAmount)
                .HasMaxLength(15)
                .HasColumnName("effect_withdrawable_amount");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .HasColumnName("event_name");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.ReferenceId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("reference_id");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(20)
                .HasColumnName("reference_type");
            entity.Property(e => e.UniqueString).HasColumnName("unique_string");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AuditTrail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("audit_trails")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiName)
                .HasColumnType("text")
                .HasColumnName("api_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Ip)
                .HasMaxLength(25)
                .HasColumnName("ip");
            entity.Property(e => e.RequestJson).HasColumnName("request_json");
            entity.Property(e => e.ResponseJson)
                .HasColumnType("text")
                .HasColumnName("response_json");
            entity.Property(e => e.Token)
                .HasColumnType("text")
                .HasColumnName("token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AwaitingRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("awaiting_requests")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionBy).HasColumnName("action_by");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.JsonData)
                .HasComment("for keeping filter params while export")
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RejectReason)
                .HasMaxLength(255)
                .HasColumnName("reject_reason")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RequestedUserId).HasColumnName("requested_user_id");
            entity.Property(e => e.Status)
                .HasComment("0=>pending;1=>approved;2=>rejected;")
                .HasColumnName("status");
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .HasColumnName("table_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<B2BPaymentHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("b2bpayment_histories")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("currency_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(50)
                .HasColumnName("gsm_number");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Receipts)
                .HasMaxLength(150)
                .HasColumnName("receipts")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ReceiveId).HasColumnName("receive_id");
            entity.Property(e => e.ReceiveTransaction).HasColumnName("receive_transaction");
            entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");
            entity.Property(e => e.SendId).HasColumnName("send_id");
            entity.Property(e => e.SendTransaction).HasColumnName("send_transaction");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TransferType)
                .HasDefaultValueSql("'1'")
                .HasComment("1-> b2b, 2-> b2u")
                .HasColumnName("transfer_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });

        modelBuilder.Entity<B2UPaymentHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("b2u_payment_histories")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.B2bPaymentId, "b2b_payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.B2bPaymentId)
                .HasMaxLength(50)
                .HasColumnName("b2b_payment_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ReceiverAddress)
                .HasMaxLength(200)
                .HasColumnName("receiver_address");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(100)
                .HasColumnName("receiver_name");
            entity.Property(e => e.ReceiverPhone)
                .HasMaxLength(20)
                .HasColumnName("receiver_phone");
            entity.Property(e => e.ReceiverTckn)
                .HasMaxLength(20)
                .HasColumnName("receiver_tckn");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .HasColumnName("reference_number");
            entity.Property(e => e.SenderName)
                .HasMaxLength(100)
                .HasColumnName("sender_name");
            entity.Property(e => e.SenderPhone)
                .HasMaxLength(20)
                .HasColumnName("sender_phone");
            entity.Property(e => e.SenderTckn)
                .HasMaxLength(100)
                .HasColumnName("sender_tckn");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'3'")
                .HasComment("1-> completed, 2-> rejected, 3-> pending")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("banks")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.ApiPassword)
                .HasMaxLength(200)
                .HasColumnName("api_password");
            entity.Property(e => e.ApiUrl)
                .HasMaxLength(100)
                .HasColumnName("api_url");
            entity.Property(e => e.ApiUserName)
                .HasMaxLength(200)
                .HasColumnName("api_user_name");
            entity.Property(e => e.BankIdentity)
                .HasMaxLength(20)
                .HasColumnName("bank_identity");
            entity.Property(e => e.ClientId)
                .HasMaxLength(200)
                .HasColumnName("client_id");
            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .HasColumnName("code");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .HasColumnName("country");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Gate2dUrl)
                .HasMaxLength(100)
                .HasColumnName("gate_2d_url");
            entity.Property(e => e.Gate3dUrl)
                .HasMaxLength(100)
                .HasColumnName("gate_3d_url");
            entity.Property(e => e.IbanCode)
                .HasMaxLength(6)
                .HasDefaultValueSql("'-1'")
                .HasColumnName("iban_code");
            entity.Property(e => e.InsurancePaymentUrl)
                .HasMaxLength(255)
                .HasComment("Url for insurance payment")
                .HasColumnName("insurance_payment_url");
            entity.Property(e => e.IsActualBank)
                .HasDefaultValueSql("'1'")
                .HasComment("is_actual_bank = 1 means ccpayment real integration(2d,3d, order statuus,, refund etc) banks. otherwise, it is dummy entry to show list on withdrawal and manual deposit screen")
                .HasColumnName("is_actual_bank");
            entity.Property(e => e.IsAllow2d)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_allow_2d");
            entity.Property(e => e.IsAllow2dCvvless)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1 = allowed")
                .HasColumnName("is_allow_2d_cvvless");
            entity.Property(e => e.IsAllow3d)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_allow_3d");
            entity.Property(e => e.IsAllow3dCvvless)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1 = allowed")
                .HasColumnName("is_allow_3d_cvvless");
            entity.Property(e => e.IsAllowOrderStatus)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_allow_order_status");
            entity.Property(e => e.IsAllowRecurring)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_allow_recurring");
            entity.Property(e => e.IsAllowRefund)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_allow_refund");
            entity.Property(e => e.IsShownInAdmin)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_shown_in_admin");
            entity.Property(e => e.IsShownInMerchant)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_shown_in_merchant");
            entity.Property(e => e.IsShownInUser)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_shown_in_user");
            entity.Property(e => e.IssuerName)
                .HasMaxLength(100)
                .HasColumnName("issuer_name");
            entity.Property(e => e.LinkGenerateUrl)
                .HasMaxLength(100)
                .HasColumnName("link_generate_url");
            entity.Property(e => e.Logo)
                .HasMaxLength(150)
                .HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.PaymentProvider)
                .HasMaxLength(20)
                .HasColumnName("payment_provider");
            entity.Property(e => e.PosnetId)
                .HasMaxLength(100)
                .HasComment("posnet id from posnet unitOfWork")
                .HasColumnName("posnet_id");
            entity.Property(e => e.RefundUrl)
                .HasMaxLength(100)
                .HasColumnName("refund_url");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=> active, 0=>inactive")
                .HasColumnName("status");
            entity.Property(e => e.StoreKey)
                .HasMaxLength(200)
                .HasColumnName("store_key");
            entity.Property(e => e.StoreType)
                .HasMaxLength(50)
                .HasDefaultValueSql("'3d_pay_hosting'")
                .HasColumnName("store_type");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(50)
                .HasComment("Terminal ID ")
                .HasColumnName("terminal_id");
            entity.Property(e => e.TokenUrl)
                .HasMaxLength(130)
                .HasColumnName("token_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<BankCardBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bank_card_brand")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.BankCode, "bank_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("bank_code");
            entity.Property(e => e.CardBrandCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasComment("card brand code of a bank")
                .HasColumnName("card_brand_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<BankCot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bank_cots")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("bank_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.InterBankCotFixed).HasColumnName("inter_bank_cot_fixed");
            entity.Property(e => e.InterBankCotPercentage).HasColumnName("inter_bank_cot_percentage");
            entity.Property(e => e.Max).HasColumnName("max");
            entity.Property(e => e.Min).HasColumnName("min");
            entity.Property(e => e.SameBankCotFixed).HasColumnName("same_bank_cot_fixed");
            entity.Property(e => e.SameBankCotPercentage).HasColumnName("same_bank_cot_percentage");
            entity.Property(e => e.StaticBankId).HasColumnName("static_bank_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TransactionType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>Withdrawal, 2=>B2C to Bank")
                .HasColumnName("transaction_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'2'")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<BankReferenceInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bank_reference_informations")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.OrderId, "order_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("order_id");
            entity.Property(e => e.Provider)
                .HasMaxLength(30)
                .HasColumnName("provider")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.ReferenceInfo)
                .HasColumnType("text")
                .HasColumnName("reference_info")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<BinDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bin_details");

            entity.HasIndex(e => e.BinNumber, "bin_number_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BinNumber).HasColumnName("bin_number");
            entity.Property(e => e.BrandName)
                .HasMaxLength(16)
                .HasColumnName("brand_name");
            entity.Property(e => e.CardType)
                .HasMaxLength(13)
                .HasColumnName("card_type");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .HasColumnName("country_code");
            entity.Property(e => e.IssuerBank)
                .HasMaxLength(100)
                .HasColumnName("issuer_bank");
        });

        modelBuilder.Entity<BinRangeQp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bin_range_qp")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.BinFrom, e.BinTo }, "bin_from_bin_to");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankCardBrandId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bank_card_brand_id");
            entity.Property(e => e.BinFrom)
                .HasMaxLength(20)
                .HasComment("Bin start form")
                .HasColumnName("bin_from");
            entity.Property(e => e.BinLength)
                .HasDefaultValueSql("'8'")
                .HasComment("6  = 6 digit bin range, 8 = 8 digit bin range")
                .HasColumnName("bin_length");
            entity.Property(e => e.BinTo)
                .HasMaxLength(20)
                .HasComment("Bin to")
                .HasColumnName("bin_to");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Response)
                .HasComment("Response as json format")
                .HasColumnType("text")
                .HasColumnName("response");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<BinRangeResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bin_range_responses")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.BinFrom, e.BinTo }, "bin_search");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BinDigit)
                .HasDefaultValueSql("'2'")
                .HasComment("1  = 6 digit bin range, 2 = 8 digit bin range")
                .HasColumnName("bin_digit");
            entity.Property(e => e.BinFrom)
                .HasMaxLength(20)
                .HasComment("Bin start form")
                .HasColumnName("bin_from");
            entity.Property(e => e.BinTo)
                .HasMaxLength(20)
                .HasComment("Bin to")
                .HasColumnName("bin_to");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Response)
                .HasComment("Response as json format")
                .HasColumnType("text")
                .HasColumnName("response");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<BinResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bin_responses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempt).HasColumnName("attempt");
            entity.Property(e => e.Bin)
                .HasMaxLength(10)
                .HasColumnName("bin");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Response)
                .HasColumnType("text")
                .HasColumnName("response");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<BinRussium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bin_russia")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualIssuerName)
                .HasMaxLength(100)
                .HasColumnName("actual_issuer_name");
            entity.Property(e => e.BinFrom).HasColumnName("bin_from");
            entity.Property(e => e.BinTo).HasColumnName("bin_to");
            entity.Property(e => e.BrandName)
                .HasMaxLength(3)
                .HasColumnName("brand_name");
            entity.Property(e => e.CardType)
                .HasMaxLength(1)
                .HasColumnName("card_type");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .HasColumnName("country_code");
            entity.Property(e => e.IssuerName)
                .HasMaxLength(4)
                .HasColumnName("issuer_name");
        });

        modelBuilder.Entity<BinStatistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bin_statistics")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bin)
                .HasMaxLength(10)
                .HasColumnName("bin");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(10)
                .HasColumnName("brand_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DestinationApi)
                .HasMaxLength(2)
                .HasComment("cg=craft_gate, mu=msu")
                .HasColumnName("destination_api");
            entity.Property(e => e.Response)
                .HasColumnType("text")
                .HasColumnName("response");
        });

        modelBuilder.Entity<BinTurkey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bin_turkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BinFrom).HasColumnName("bin_from");
            entity.Property(e => e.BinTo).HasColumnName("bin_to");
            entity.Property(e => e.BrandName)
                .HasMaxLength(3)
                .HasColumnName("brand_name");
            entity.Property(e => e.CardType)
                .HasMaxLength(1)
                .HasColumnName("card_type");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .HasColumnName("country_code");
            entity.Property(e => e.IssuerBank)
                .HasMaxLength(4)
                .HasColumnName("issuer_bank");
        });

        modelBuilder.Entity<BlockTimeSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("block_time_setting")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FirstTime).HasColumnName("first_time");
            entity.Property(e => e.SecondTime).HasColumnName("second_time");
            entity.Property(e => e.SessionTime)
                .HasDefaultValueSql("'10'")
                .HasComment("as define it will be 10 min. ")
                .HasColumnName("session_time");
            entity.Property(e => e.ThirdTime).HasColumnName("third_time");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });

        modelBuilder.Entity<BrandBankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("brand_bank_accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(150)
                .HasColumnName("account_holder_name");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(50)
                .HasColumnName("account_no");
            entity.Property(e => e.AvailableFor)
                .HasComment("1=>Deposit")
                .HasColumnName("available_for");
            entity.Property(e => e.BankName)
                .HasMaxLength(150)
                .HasColumnName("bank_name");
            entity.Property(e => e.BranchCode)
                .HasMaxLength(20)
                .HasColumnName("branch_code");
            entity.Property(e => e.BranchName)
                .HasMaxLength(50)
                .HasComment("Sipay Bank Account Branch Name")
                .HasColumnName("branch_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.IsPosAccount)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = Not POS account, 1 = POS Account")
                .HasColumnName("is_pos_account");
            entity.Property(e => e.IsSenderBank)
                .HasComment("0=Not a sender bank, 1=Sender bank")
                .HasColumnName("is_sender_bank");
            entity.Property(e => e.StaticBankId)
                .HasComment("primary key of banks table")
                .HasColumnName("static_bank_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>active;0=>inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'2'")
                .HasComment("customer => 0, merchant => 2")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<BulkChargebackHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bulk_chargeback_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PaymentId, "unique_payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("transaction amount")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'1'")
                .HasComment("transaction currency id")
                .HasColumnName("currency_id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasComment("chargeback failed response")
                .HasColumnName("note");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasComment("chargeback reason")
                .HasColumnName("reason");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=success, 2=failed, 3=partially success")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1=force, 2=request chargeback")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<C2BHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("c2b_histories")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(10)
                .HasColumnName("currency_symbol")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("timestamp")
                .HasColumnName("effective_date");
            entity.Property(e => e.MerchantCommissionFixed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_commission_fixed");
            entity.Property(e => e.MerchantCommissionPercentage)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_commission_percentage");
            entity.Property(e => e.MerchantRollingPercentage)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_rolling_percentage");
            entity.Property(e => e.ReceiverGsmNumber)
                .HasMaxLength(50)
                .HasColumnName("receiver_gsm_number")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");
            entity.Property(e => e.ReceiverMerchantId).HasColumnName("receiver_merchant_id");
            entity.Property(e => e.ReceiverMerchantName)
                .HasMaxLength(100)
                .HasColumnName("receiver_merchant_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SendId).HasColumnName("send_id");
            entity.Property(e => e.SenderGsmNumber)
                .HasMaxLength(50)
                .HasColumnName("sender_gsm_number")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.SenderName)
                .HasMaxLength(100)
                .HasColumnName("sender_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>Awaiting, 1=>Processed")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CardTokenRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("card_token_requests")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CancelUrl)
                .HasColumnType("text")
                .HasColumnName("cancel_url");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("invoice_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantKey)
                .HasMaxLength(255)
                .HasColumnName("merchant_key");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("order_id");
            entity.Property(e => e.ParentInvoiceId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("parent_invoice_id");
            entity.Property(e => e.ParentMerchantId).HasColumnName("parent_merchant_id");
            entity.Property(e => e.ParentMerchantKey)
                .HasMaxLength(255)
                .HasColumnName("parent_merchant_key");
            entity.Property(e => e.ReturnUrl)
                .HasColumnType("text")
                .HasColumnName("return_url");
            entity.Property(e => e.TransactionStateId)
                .HasComment("0= not sent to bank yet. others will follow transaction_states table")
                .HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Cashout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("cashouts")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.HasIndex(e => e.UniqueId, "unique_id").IsUnique();

            entity.HasIndex(e => e.UniqueString, "unique_string").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.AdminApproveById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("admin_approve_by_id");
            entity.Property(e => e.AdminApprroveByName)
                .HasMaxLength(100)
                .HasColumnName("admin_apprrove_by_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BankStaticId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bank_static_id");
            entity.Property(e => e.CashoutFileHistoriesId).HasColumnName("cashout_file_histories_id");
            entity.Property(e => e.Cost)
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Currency)
                .HasMaxLength(5)
                .HasColumnName("currency")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(5)
                .HasColumnName("currency_symbol")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Fee)
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.FlowType)
                .HasComment("0=default (finflow disable & manually approve/reject); 1 = sent to finflow from merchant panel and successful; 2 = sent to finflow from merchant panel and rejected, now admin can send again or manually approve/reject; 3 = sent to finflow from admin panel and successful; 4 = sent to finflow from admin panel and rejected; 5 = Auto Deduct Customized Cost")
                .HasColumnName("flow_type");
            entity.Property(e => e.Gross)
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(100)
                .HasColumnName("gsm_number")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Iban)
                .HasMaxLength(100)
                .HasColumnName("iban")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IdTckn)
                .HasMaxLength(100)
                .HasColumnName("id_tckn")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Net)
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RejectReason)
                .HasMaxLength(255)
                .HasColumnName("reject_reason")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RemoteAccountNumber)
                .HasMaxLength(50)
                .HasComment("wallet gate account number")
                .HasColumnName("remote_account_number");
            entity.Property(e => e.SipayBankAccountId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sipay_bank_account_id");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'1'")
                .HasComment("1=cashout requested from merchant panel; 2=cashout requested from api;")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'3'")
                .HasComment("1/2/3 (1=Completed, 2=Rejected, 3=Pending)")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("1=>send money, 2=>btob, 3=>btoc, 4=>sendmoney to nonbrand, 5=>sendmoney to bank, 6=>sendmoney to merchant, 7=>request money, 8=>btou, 9=>ctoc cashout to bank")
                .HasColumnName("type");
            entity.Property(e => e.UniqueId)
                .HasMaxLength(50)
                .HasColumnName("unique_id")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UniqueString)
                .HasColumnName("unique_string")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'2'")
                .HasComment("0=customer, 2=merchant")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<CashoutBankSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cashout_bank_settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bank_id");
            entity.Property(e => e.Code)
                .HasComment("1=User withdrawal, 2=Merchant withdrawal, 3=B2C cashout to bank")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasComment("1=TRY, 2=USD, 3=EUR")
                .HasColumnName("currency_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CashoutFileHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cashout_file_histories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.FileShow)
                .HasDefaultValueSql("'1'")
                .HasComment("0=hide, 1= show ")
                .HasColumnName("file_show");
            entity.Property(e => e.FileSize)
                .HasMaxLength(20)
                .HasColumnName("file_size")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Status)
                .HasComment("0=failed, 1= success")
                .HasColumnName("status");
            entity.Property(e => e.TotalRows).HasColumnName("total_rows");
            entity.Property(e => e.Type)
                .HasComment("1->cashout to bank;2->cashout to wallet")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("categories")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ParentId, "categories_parent_id_foreign");

            entity.HasIndex(e => e.Slug, "categories_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'1'")
                .HasColumnName("order");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("categories_parent_id_foreign");
        });

        modelBuilder.Entity<CCBlockList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("cc_block_list")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlockReason)
                .HasMaxLength(70)
                .HasColumnName("block_reason")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BlockedFrom)
                .HasColumnType("datetime")
                .HasColumnName("blocked_from");
            entity.Property(e => e.BlockedTo)
                .HasColumnType("datetime")
                .HasColumnName("blocked_to");
            entity.Property(e => e.BlockerEmail)
                .HasMaxLength(191)
                .HasColumnName("blocker_email")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BlockerId).HasColumnName("blocker_id");
            entity.Property(e => e.BlockerName)
                .HasMaxLength(191)
                .HasColumnName("blocker_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(70)
                .HasColumnName("card_holder_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CardNo)
                .HasMaxLength(70)
                .HasColumnName("card_no")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EditorEmail)
                .HasMaxLength(70)
                .HasColumnName("editor_email")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.EditorId).HasColumnName("editor_id");
            entity.Property(e => e.EditorName)
                .HasMaxLength(70)
                .HasColumnName("editor_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.IsBlockTemporarily)
                .HasDefaultValueSql("'0'")
                .HasComment("0=forever, 1=temporary")
                .HasColumnName("is_block_temporarily");
            entity.Property(e => e.MerchantId)
                .HasComment("0=All merchant")
                .HasColumnName("merchant_id");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'3'")
                .HasComment("1=blocked, 2=unblocked, 3=pending from unblocked to block, 4=pending from blocked to unblock")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1=card, 2=bin, 3=full card")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChangePasswordHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("change_password_histories")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Passwords)
                .HasMaxLength(191)
                .HasColumnName("passwords");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("chats")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasDefaultValueSql("'single'")
                .HasComment("single or group")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChatAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("chat_attachments")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.File)
                .HasMaxLength(255)
                .HasColumnName("file");
            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("chat_messages")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChatId).HasColumnName("chat_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedFor)
                .HasColumnType("json")
                .HasColumnName("deleted_for");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.ReadBy)
                .HasColumnType("json")
                .HasColumnName("read_by");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChatUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("chat_user")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChatId).HasColumnName("chat_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IsMuted)
                .HasComment("1=>true, 0=>false")
                .HasColumnName("is_muted");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<ChecklistControl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("checklist_controls")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Information)
                .HasMaxLength(255)
                .HasColumnName("information");
            entity.Property(e => e.IsRequired)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = required, 0 = not required")
                .HasColumnName("is_required");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = active, 0 = inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UploadFile)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = active, 0 = inactive")
                .HasColumnName("upload_file");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("cities")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .HasColumnType("mediumint unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country_code");
            entity.Property(e => e.CountryId)
                .HasColumnType("mediumint unsigned")
                .HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'2013-12-31 22:31:01'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CommercialCardCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("commercial_card_commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasComment("admin id")
                .HasColumnName("created_by_id");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EndUserComFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(8,4)")
                .HasColumnName("end_user_com_fixed");
            entity.Property(e => e.EndUserComPercentage)
                .HasColumnType("double(8,4)")
                .HasColumnName("end_user_com_percentage");
            entity.Property(e => e.InstallmentNumber).HasColumnName("installment_number");
            entity.Property(e => e.MerchantComFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(8,4)")
                .HasColumnName("merchant_com_fixed");
            entity.Property(e => e.MerchantComPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(8,4)")
                .HasColumnName("merchant_com_percentage");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Program)
                .HasMaxLength(100)
                .HasComment("Card program")
                .HasColumnName("program");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = Inactive, 1 = Active")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasComment("admin id")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Commission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionType)
                .HasDefaultValueSql("'0'")
                .HasComment("1 -> send money 4 -> to_non_supay 5 -> to_banks 6 -> C2B payment ")
                .HasColumnName("action_type");
            entity.Property(e => e.CommissionAmount).HasColumnName("commission_amount");
            entity.Property(e => e.CommissionPercentage).HasColumnName("commission_percentage");
            entity.Property(e => e.CostOfTransactionAmount).HasColumnName("cost_of_transaction_amount");
            entity.Property(e => e.CostOfTransactionPercentage).HasColumnName("cost_of_transaction_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.OperatorId).HasColumnName("operator_id");
            entity.Property(e => e.PosId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("pos_id");
            entity.Property(e => e.ProviderId)
                .HasComment("1=> wirecard, 2=> payten")
                .HasColumnName("provider_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .HasColumnName("service_name")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(30)
                .HasColumnName("transaction_type")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserCategory)
                .HasDefaultValueSql("'0'")
                .HasComment("1=>Not Verified, 2=>Verified, 3=>Verified Plus")
                .HasColumnName("user_category");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>customer, 2=>merchant")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("companies")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasDefaultValueSql("'1'")
                .HasColumnName("added_by");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .HasColumnName("address2");
            entity.Property(e => e.AverageTurnover)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("average_turnover");
            entity.Property(e => e.Cemail)
                .HasMaxLength(100)
                .HasColumnName("cemail");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.CmmiLevel)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cmmi_level");
            entity.Property(e => e.Cname)
                .HasMaxLength(100)
                .HasColumnName("cname");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DailyRate)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("daily_rate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .HasColumnName("fax");
            entity.Property(e => e.HourlyRate)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("hourly_rate");
            entity.Property(e => e.Logo)
                .HasMaxLength(191)
                .HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NoOfEmployees)
                .HasDefaultValueSql("'0'")
                .HasColumnName("no_of_employees");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Postcode)
                .HasMaxLength(10)
                .HasColumnName("postcode");
            entity.Property(e => e.RegistrationNo)
                .HasMaxLength(40)
                .HasColumnName("registration_no");
            entity.Property(e => e.Sector)
                .HasMaxLength(191)
                .HasColumnName("sector");
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .HasColumnName("state");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=active,0=inactive")
                .HasColumnName("status");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(40)
                .HasColumnName("tax_no");
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(191)
                .HasColumnName("tax_office");
            entity.Property(e => e.Timezone).HasColumnName("timezone");
            entity.Property(e => e.TimezoneValue)
                .HasMaxLength(20)
                .HasColumnName("timezone_value");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.YearlyRevenue)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("yearly_revenue");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("contents")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentEn)
                .HasColumnType("mediumtext")
                .HasColumnName("content_en");
            entity.Property(e => e.ContentTr)
                .HasColumnType("mediumtext")
                .HasColumnName("content_tr");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("countries")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(100)
                .HasColumnName("country_code");
            entity.Property(e => e.CountryCodeThreeDigit)
                .HasMaxLength(100)
                .HasColumnName("country_code_three_digit");
            entity.Property(e => e.CountryName)
                .HasMaxLength(500)
                .HasColumnName("country_name");
            entity.Property(e => e.CountryNameTr)
                .HasMaxLength(500)
                .HasColumnName("country_name_tr");
        });

        modelBuilder.Entity<CronjobLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("cronjob_logs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LogData)
                .HasColumnType("text")
                .HasColumnName("log_data");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PanelName)
                .HasMaxLength(70)
                .HasColumnName("panel_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CronjobSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("cronjob_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FrequencyType)
                .HasDefaultValueSql("'0'")
                .HasComment("0=fixed time, 1=per minute, 2=per hour, 3=per day, 4=custom")
                .HasColumnName("frequency_type");
            entity.Property(e => e.FrequencyValue)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasComment("every frequency_value of minute/hour/day")
                .HasColumnName("frequency_value");
            entity.Property(e => e.NextExecuteAt)
                .HasComment("next datetime to execute")
                .HasColumnType("datetime")
                .HasColumnName("next_execute_at");
            entity.Property(e => e.Panel)
                .HasDefaultValueSql("'1'")
                .HasComment("0=user, 1=admin, 2=merchant, 3=ccpayment")
                .HasColumnName("panel");
            entity.Property(e => e.RunTime)
                .HasComment("fixed run time for everyday")
                .HasColumnType("time")
                .HasColumnName("run_time");
            entity.Property(e => e.Signature)
                .HasMaxLength(100)
                .HasComment("signature of the cronjob")
                .HasColumnName("signature");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CurrenciesSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currencies_settings")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmlMaxAllowedCreditCard)
                .HasDefaultValueSql("'2'")
                .HasColumnName("aml_max_allowed_credit_card");
            entity.Property(e => e.AmlMaxInputValue)
                .HasColumnType("double(12,4)")
                .HasColumnName("aml_max_input_value");
            entity.Property(e => e.AmlMaxP2pTransactionable)
                .HasColumnType("double(12,4)")
                .HasColumnName("aml_max_p2p_transactionable");
            entity.Property(e => e.AmlMaxTotalAllowedAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("aml_max_total_allowed_amount");
            entity.Property(e => e.AmlMaxTotalAllowedRange)
                .HasColumnType("double(12,4)")
                .HasColumnName("aml_max_total_allowed_range");
            entity.Property(e => e.AmlMaxTransactionable)
                .HasColumnType("double(12,4)")
                .HasColumnName("aml_max_transactionable");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.MaxAutomationB2cLimit)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_automation_b2c_limit");
            entity.Property(e => e.MaxAutomationCashoutLimit)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_automation_cashout_limit");
            entity.Property(e => e.MaxAutomationCashoutLimitMerchant)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_automation_cashout_limit_merchant");
            entity.Property(e => e.MaxAutomationWalletgateLimit)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_automation_walletgate_limit");
            entity.Property(e => e.MaxB2cLimitOffTime)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("max b2c to bank limit for finflow during off hour or off day")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_b2c_limit_off_time");
            entity.Property(e => e.MaxBalanceLimitContractor)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_balance_limit_contractor");
            entity.Property(e => e.MaxBalanceLimitUnknown)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_balance_limit_unknown");
            entity.Property(e => e.MaxBalanceLimitUnverified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_balance_limit_unverified");
            entity.Property(e => e.MaxBalanceLimitVerified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_balance_limit_verified");
            entity.Property(e => e.MaxBalanceOfNonVerifiedUser)
                .HasColumnType("double(12,4)")
                .HasColumnName("max_balance_of_non_verified_user");
            entity.Property(e => e.MaxCashoutLimitOffTime)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("max withdrawal limit for finflow during off hour or off day")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_cashout_limit_off_time");
            entity.Property(e => e.MaxDepositContractor)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_deposit_contractor");
            entity.Property(e => e.MaxDepositUnknown)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_deposit_unknown");
            entity.Property(e => e.MaxDepositUnverified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_deposit_unverified");
            entity.Property(e => e.MaxDepositVerified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_deposit_verified");
            entity.Property(e => e.MaxKycB2cLimit)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("if total  sent amount  is more than  75K, validate  tckn  for  merchant, if total  received amount  is more than  75K, validate  tckn  for  customer")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_kyc_b2c_limit");
            entity.Property(e => e.MaxMoneyTransferContractorWalletToIban)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_contractor_wallet_to_iban");
            entity.Property(e => e.MaxMoneyTransferContractorWalletToWallet)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_contractor_wallet_to_wallet");
            entity.Property(e => e.MaxMoneyTransferUnknownWalletToIban)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_unknown_wallet_to_iban");
            entity.Property(e => e.MaxMoneyTransferUnknownWalletToWallet)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_unknown_wallet_to_wallet");
            entity.Property(e => e.MaxMoneyTransferUnverifiedWalletToIban)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_unverified_wallet_to_iban");
            entity.Property(e => e.MaxMoneyTransferUnverifiedWalletToWallet)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_unverified_wallet_to_wallet");
            entity.Property(e => e.MaxMoneyTransferVerifiedWalletToIban)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_verified_wallet_to_iban");
            entity.Property(e => e.MaxMoneyTransferVerifiedWalletToWallet)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_money_transfer_verified_wallet_to_wallet");
            entity.Property(e => e.MaxReceiveMoneyContractor)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_receive_money_contractor");
            entity.Property(e => e.MaxReceiveMoneyUnknown)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_receive_money_unknown");
            entity.Property(e => e.MaxReceiveMoneyUnverified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_receive_money_unverified");
            entity.Property(e => e.MaxReceiveMoneyVerified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_receive_money_verified");
            entity.Property(e => e.MaxWithdrawContractor)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_withdraw_contractor");
            entity.Property(e => e.MaxWithdrawUnknown)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_withdraw_unknown");
            entity.Property(e => e.MaxWithdrawUnverified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_withdraw_unverified");
            entity.Property(e => e.MaxWithdrawVerified)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_withdraw_verified");
            entity.Property(e => e.MinCashoutToBank)
                .HasColumnType("double(12,4)")
                .HasColumnName("min_cashout_to_bank");
            entity.Property(e => e.MinWithdrawAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("min_withdraw_amount");
            entity.Property(e => e.TotalMoneyTransferCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_money_transfer_commission");
            entity.Property(e => e.TotalMoneyTransferMaxLimit)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_money_transfer_max_limit");
            entity.Property(e => e.TotalMoneyTransferMaxTransaction)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_money_transfer_max_transaction");
            entity.Property(e => e.TotalReceiveMoneyCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_receive_money_commission");
            entity.Property(e => e.TotalReceiveMoneyMaxLimit)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_receive_money_max_limit");
            entity.Property(e => e.TotalReceiveMoneyMaxTransaction)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_receive_money_max_transaction");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currencies")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Code, "currencies_code_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IsMerchantDefaultCurrency)
                .HasComment("for merchant default currency ")
                .HasColumnName("is_merchant_default_currency");
            entity.Property(e => e.IsWalletUserDefaultCurrency)
                .HasComment("for default wallet user currency")
                .HasColumnName("is_wallet_user_default_currency");
            entity.Property(e => e.IsoCode).HasColumnName("iso_code");
            entity.Property(e => e.MaxInputValue).HasColumnName("max_input_value");
            entity.Property(e => e.MaxP2pTransactionable).HasColumnName("max_p2p_transactionable");
            entity.Property(e => e.MaxTotalAllowedAmount).HasColumnName("max_total_allowed_amount");
            entity.Property(e => e.MaxTotalAllowedRange).HasColumnName("max_total_allowed_range");
            entity.Property(e => e.MaxTransactionable).HasColumnName("max_transactionable");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .HasMaxLength(255)
                .HasColumnName("symbol");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CurrencyConversionRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currency_conversion_rates")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(6)
                .HasColumnName("id")
                .UseCollation("utf8mb4_bin");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FromCurrencyCode)
                .HasMaxLength(3)
                .HasColumnName("from_currency_code");
            entity.Property(e => e.Rate)
                .HasColumnType("double(12,4)")
                .HasColumnName("rate");
            entity.Property(e => e.ToCurrencyCode)
                .HasMaxLength(3)
                .HasColumnName("to_currency_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CurrencyDepositMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currency_deposit_methods")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.DepositMethodId, "currencie_deposit_deposit_method_id_index");

            entity.HasIndex(e => e.CurrencyId, "currency_depositmethod_currency_id_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DepositMethodId).HasColumnName("deposit_method_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CurrencyExchangeCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currency_exchange_commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_amount");
            entity.Property(e => e.CommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_percentage");
            entity.Property(e => e.FromCurrencyId).HasColumnName("from_currency_id");
            entity.Property(e => e.ToCurrencyId).HasColumnName("to_currency_id");
        });

        modelBuilder.Entity<CurrencyExchangeRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currency_exchange_rates")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExchangesToSecondCurrencyValue).HasColumnName("exchanges_to_second_currency_value");
            entity.Property(e => e.FirstCurrencyId).HasColumnName("first_currency_id");
            entity.Property(e => e.SecondCurrencyId).HasColumnName("second_currency_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CurrencyWithdrawalMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currency_withdrawal_methods")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.WithdrawalMethodId).HasColumnName("withdrawal_method_id");
        });

        modelBuilder.Entity<DataRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("data_rows")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.DataTypeId, "data_rows_data_type_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Add)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("add");
            entity.Property(e => e.Browse)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("browse");
            entity.Property(e => e.DataTypeId).HasColumnName("data_type_id");
            entity.Property(e => e.Delete)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("delete");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(191)
                .HasColumnName("display_name");
            entity.Property(e => e.Edit)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("edit");
            entity.Property(e => e.Field)
                .HasMaxLength(191)
                .HasColumnName("field");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'1'")
                .HasColumnName("order");
            entity.Property(e => e.Read)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("read");
            entity.Property(e => e.Required).HasColumnName("required");
            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");

            entity.HasOne(d => d.DataType).WithMany(p => p.DataRows)
                .HasForeignKey(d => d.DataTypeId)
                .HasConstraintName("data_rows_data_type_id_foreign");
        });

        modelBuilder.Entity<DataType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("data_types")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Name, "data_types_name_unique").IsUnique();

            entity.HasIndex(e => e.Slug, "data_types_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Controller)
                .HasMaxLength(191)
                .HasColumnName("controller");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasColumnName("description");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.DisplayNamePlural)
                .HasMaxLength(191)
                .HasColumnName("display_name_plural");
            entity.Property(e => e.DisplayNameSingular)
                .HasMaxLength(191)
                .HasColumnName("display_name_singular");
            entity.Property(e => e.GeneratePermissions).HasColumnName("generate_permissions");
            entity.Property(e => e.Icon)
                .HasMaxLength(191)
                .HasColumnName("icon");
            entity.Property(e => e.ModelName)
                .HasMaxLength(191)
                .HasColumnName("model_name");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.PolicyName)
                .HasMaxLength(191)
                .HasColumnName("policy_name");
            entity.Property(e => e.ServerSide).HasColumnName("server_side");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("deposits")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.HasIndex(e => e.RemoteReceiptNo, "remote_receipt_no").IsUnique();

            entity.HasIndex(e => e.UniqueString, "unique_string").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.AdminProcessDate)
                .HasColumnType("timestamp")
                .HasColumnName("admin_process_date");
            entity.Property(e => e.ApproveRejectById).HasColumnName("approve_reject_by_id");
            entity.Property(e => e.AutomationStatus)
                .HasDefaultValueSql("'2'")
                .HasComment("1=>Automation, Manual=>2")
                .HasColumnName("automation_status");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(120)
                .HasColumnName("card_holder_name");
            entity.Property(e => e.CardType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("card_type");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CreditCardNo)
                .HasMaxLength(70)
                .HasColumnName("credit_card_no");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.CustomerIban)
                .HasMaxLength(100)
                .HasColumnName("customer_iban");
            entity.Property(e => e.DepositMethodId).HasColumnName("deposit_method_id");
            entity.Property(e => e.DepositSource)
                .HasDefaultValueSql("'3'")
                .HasComment("1=>Created by admin, 2=>Finflow, 3=>Manual eft, 4=>Eft automation by sipay")
                .HasColumnName("deposit_source");
            entity.Property(e => e.EndUserCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_fixed");
            entity.Property(e => e.EndUserCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_percentage");
            entity.Property(e => e.Fee)
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(50)
                .HasColumnName("gsm_number");
            entity.Property(e => e.IbanNo)
                .HasMaxLength(100)
                .HasColumnName("iban_no");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Net)
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.NumberOfEdit).HasColumnName("number_of_edit");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.PnrCode)
                .HasMaxLength(200)
                .HasColumnName("pnr_code");
            entity.Property(e => e.PosId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("pos_id");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.RemoteOrderId)
                .HasMaxLength(50)
                .HasColumnName("remote_order_id");
            entity.Property(e => e.RemoteReceiptNo)
                .HasMaxLength(50)
                .HasColumnName("remote_receipt_no");
            entity.Property(e => e.TotalRefundedAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_refunded_amount");
            entity.Property(e => e.TransactionReceipt)
                .HasColumnType("text")
                .HasColumnName("transaction_receipt");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UniqueString).HasColumnName("unique_string");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasComment("0=>Customer, 2=>Merchant")
                .HasColumnName("user_type");
            entity.Property(e => e.WalletId).HasColumnName("wallet_id");
        });

        modelBuilder.Entity<DepositMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("deposit_methods")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.HowTo).HasColumnName("how_to");
            entity.Property(e => e.IsShownInCustomer)
                .HasComment("0=no; 1=yes")
                .HasColumnName("is_shown_in_customer");
            entity.Property(e => e.IsShownInMerchant)
                .HasComment("0=no; 1=yes")
                .HasColumnName("is_shown_in_merchant");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>active;0=>inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DirectPaymentLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("direct_payment_links")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CommissionForInstallment)
                .HasMaxLength(100)
                .HasColumnName("commission_for_installment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasComment("user id of who created dpl link")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(191)
                .HasComment("created by name")
                .HasColumnName("created_by_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Currency).HasColumnName("currency");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.DistanceSaleStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("distance_sale_status");
            entity.Property(e => e.DplPosOption)
                .HasDefaultValueSql("'1'")
                .HasComment("0=2d, 1=3D, 2=Allow 2D And 3D")
                .HasColumnName("dpl_pos_option");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ExpireDate)
                .HasComment("expire date for muti-time")
                .HasColumnType("datetime")
                .HasColumnName("expire_date");
            entity.Property(e => e.ExpireTime)
                .HasComment("time for single time")
                .HasColumnName("expire_time");
            entity.Property(e => e.Gsm)
                .HasMaxLength(100)
                .HasColumnName("gsm")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IsAmountSetByUser)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_amount_set_by_user");
            entity.Property(e => e.IsComissionFromUser)
                .HasDefaultValueSql("'2'")
                .HasComment("1 => take commission from user\r\n\r\n2 => do not take commission from user; user fee forcefully 0")
                .HasColumnName("is_comission_from_user");
            entity.Property(e => e.IsEmailSend)
                .HasComment("cronjob email send for dpl 1 = sent 0= not sent")
                .HasColumnName("is_email_send");
            entity.Property(e => e.IsEnabled)
                .HasDefaultValueSql("'1'")
                .HasComment("0=not enabled, 1= enabled")
                .HasColumnName("is_enabled");
            entity.Property(e => e.IsPreauth)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1=allow")
                .HasColumnName("is_preauth");
            entity.Property(e => e.IsRecurring)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = Not Recurring, 1 = Recurring")
                .HasColumnName("is_recurring");
            entity.Property(e => e.IsShownInList)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>not shown,1=>shown. when this value is true, It should not be listed in merchant panel list and make it expired")
                .HasColumnName("is_shown_in_list");
            entity.Property(e => e.MaxInstallmentLimit)
                .HasDefaultValueSql("'0'")
                .HasColumnName("max_installment_limit");
            entity.Property(e => e.MaxNumberOfUses).HasColumnName("max_number_of_uses");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MinInstallmentLimit).HasColumnName("min_installment_limit");
            entity.Property(e => e.ModifiedBy)
                .HasComment("user id of who modified dpl")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedByName)
                .HasMaxLength(191)
                .HasComment("modified by name")
                .HasColumnName("modified_by_name");
            entity.Property(e => e.NameOfProduct)
                .HasMaxLength(50)
                .HasColumnName("name_of_product")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumberOfUses).HasColumnName("number_of_uses");
            entity.Property(e => e.PaymentMethod)
                .HasComment("id from deposit_method table")
                .HasColumnName("payment_method");
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .HasColumnName("photo")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SavedLinkTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasComment("If this column is not empty, then it will be considered as saved link")
                .HasColumnName("saved_link_title")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'ACTIVE'")
                .HasColumnType("enum('ACTIVE','FAILED','COMPLETED','USED','EXPIRED')")
                .HasColumnName("status")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .HasColumnName("token")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Type)
                .HasComment("1 = first time, 2 = multi-time")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DplAgreement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("dpl_agreements")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgreementContent)
                .HasColumnType("mediumtext")
                .HasColumnName("agreement_content")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.AgreementName)
                .HasMaxLength(70)
                .HasColumnName("agreement_name")
                .UseCollation("utf32_general_ci")
                .HasCharSet("utf32");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DplSettingId).HasColumnName("dpl_setting_id");
            entity.Property(e => e.SerialNo).HasColumnName("serial_no");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DplChangeHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dpl_change_histories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasComment("user id of who created")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(200)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(100)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.DplId).HasColumnName("dpl_id");
            entity.Property(e => e.ExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("expire_date");
            entity.Property(e => e.IsEnabled)
                .HasDefaultValueSql("'1'")
                .HasComment("0=not enabled, 1= enabled")
                .HasColumnName("is_enabled");
            entity.Property(e => e.MaxNumberOfUses).HasColumnName("max_number_of_uses");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.NewData)
                .HasMaxLength(255)
                .HasColumnName("new_data");
            entity.Property(e => e.OldData)
                .HasMaxLength(255)
                .HasColumnName("old_data");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<DplRecurringSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("dpl_recurring_settings")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.DplId, "dpl_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DplId).HasColumnName("dpl_id");
            entity.Property(e => e.PaymentCycle)
                .HasMaxLength(2)
                .HasComment("D=>Day, W=>Week, M=Month, Y=Year")
                .HasColumnName("payment_cycle");
            entity.Property(e => e.PaymentInterval)
                .HasDefaultValueSql("'1'")
                .HasComment("In how many days/week/month/year it will be executed again")
                .HasColumnName("payment_interval");
            entity.Property(e => e.PaymentNumber)
                .HasComment("Number of time(frequency), amount will be deducted")
                .HasColumnName("payment_number");
            entity.Property(e => e.RecurringWebhookKey)
                .HasMaxLength(100)
                .HasColumnName("recurring_webhook_key");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DplResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("dpl_resources")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DirectPaymentLinkId)
                .HasComment("id of direct_payment_link table")
                .HasColumnName("direct_payment_link_id");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasComment("Brandresource path for example \"merchant/dpl/2252/WHgR9BkJYyACPd62YR0NP3rA2Gizn6g2HU6YUL5W.jpg\"")
                .HasColumnName("file_path");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValueSql("'0'")
                .HasComment("1 = primary/cover photo \r\n0 = not primary")
                .HasColumnName("is_primary");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = inactive, 1 = active")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DplSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dpl_settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brand_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DistanceSaleContract)
                .HasColumnType("mediumtext")
                .HasColumnName("distance_sale_contract");
            entity.Property(e => e.Logo)
                .HasMaxLength(70)
                .HasColumnName("logo");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Status)
                .HasComment("1=show distance sale contract, 0=do not show")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DuplicateTesting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("duplicate_testings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DuplicateWalletIdList)
                .HasColumnType("text")
                .HasColumnName("duplicate_wallet_id_list");
            entity.Property(e => e.EffectAmount)
                .HasMaxLength(15)
                .HasDefaultValueSql("''")
                .HasColumnName("effect_amount");
            entity.Property(e => e.EffectNonwithdrawableAmount)
                .HasMaxLength(15)
                .HasDefaultValueSql("''")
                .HasColumnName("effect_nonwithdrawable_amount");
            entity.Property(e => e.EffectRollingAmount)
                .HasMaxLength(15)
                .HasDefaultValueSql("''")
                .HasColumnName("effect_rolling_amount");
            entity.Property(e => e.EffectWithdrawableAmount)
                .HasMaxLength(15)
                .HasDefaultValueSql("''")
                .HasColumnName("effect_withdrawable_amount");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("event_name");
            entity.Property(e => e.Total)
                .HasColumnType("double(12,4)")
                .HasColumnName("total");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WalletLogId).HasColumnName("wallet_log_id");
        });

        modelBuilder.Entity<ErrorMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("error_mappings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => new { e.BankIdentity, e.ErrorCode }, "bank_identity_error_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankIdentity)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("bank_identity")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("error_code")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MessageEn)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("message_en")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MessageTr)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("message_tr")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Exchange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("exchanges")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(8,4)")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.FirstCurrencyId).HasColumnName("first_currency_id");
            entity.Property(e => e.FromAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("from_amount");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(50)
                .HasColumnName("gsm_number");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Net)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.SecondCurrencyId).HasColumnName("second_currency_id");
            entity.Property(e => e.ToAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("to_amount");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("failed_jobs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection)
                .HasColumnType("text")
                .HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue)
                .HasColumnType("text")
                .HasColumnName("queue");
        });

        modelBuilder.Entity<FailedLoginList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("failed_login_list")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FailedLoginTime)
                .HasColumnType("datetime")
                .HasColumnName("failed_login_time");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });

        modelBuilder.Entity<ForeignMastercardBin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("foreign_mastercard_bins")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptanceBrand)
                .HasMaxLength(10)
                .HasColumnName("acceptance_brand");
            entity.Property(e => e.AccountRangeFrom).HasColumnName("account_range_from");
            entity.Property(e => e.AccountRangeTo).HasColumnName("account_range_to");
            entity.Property(e => e.BrandProductCode)
                .HasMaxLength(5)
                .HasColumnName("brand_product_code");
            entity.Property(e => e.BrandProductName)
                .HasMaxLength(100)
                .HasColumnName("brand_product_name");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .HasColumnName("company_name");
            entity.Property(e => e.Country)
                .HasMaxLength(5)
                .HasColumnName("country");
            entity.Property(e => e.Ica)
                .HasMaxLength(10)
                .HasColumnName("ica");
        });

        modelBuilder.Entity<FpWalletTransactionEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fp_wallet_transaction_entities");

            entity.HasIndex(e => new { e.MerchantId, e.OrderId }, "merchant_id_order_id");

            entity.HasIndex(e => e.OrderId, "order_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CashbackAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("cashback_amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FpWalletMerchantId).HasColumnName("fp_wallet_merchant_id");
            entity.Property(e => e.FpWalletMerchantUserId).HasColumnName("fp_wallet_merchant_user_id");
            entity.Property(e => e.FpWalletServiceResponseCode)
                .HasMaxLength(20)
                .HasComment("Response code from FP wallet unitOfWork")
                .HasColumnName("fp_wallet_service_response_code");
            entity.Property(e => e.FpWalletServiceResponseDetails)
                .HasMaxLength(200)
                .HasComment("Response details from FP wallet unitOfWork")
                .HasColumnName("fp_wallet_service_response_details");
            entity.Property(e => e.FpWalletServiceSource)
                .HasMaxLength(20)
                .HasComment("Source/Name of the unitOfWork we are getting the response code from\r\nValues:\r\nwalletCheck,\r\nwalletApprove,\r\nwalletNotify,\r\nwalletCancel")
                .HasColumnName("fp_wallet_service_source")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.FpWalletUserCode)
                .HasMaxLength(10)
                .HasColumnName("fp_wallet_user_code");
            entity.Property(e => e.MerchantId)
                .HasMaxLength(50)
                .HasColumnName("merchant_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.PaymentSource).HasColumnName("payment_source");
            entity.Property(e => e.SaleId)
                .HasMaxLength(50)
                .HasColumnName("sale_id");
            entity.Property(e => e.Status)
                .HasComment("0 => Not Processed,\r\n1 => Processed Asynch\r\n2 => Processed Wallet Event ")
                .HasColumnName("status");
            entity.Property(e => e.TrnCode)
                .HasMaxLength(10)
                .HasColumnName("trn_code")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.TrnCodeDetail)
                .HasMaxLength(10)
                .HasColumnName("trn_code_detail")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.TrnCodeSpecial)
                .HasMaxLength(10)
                .HasColumnName("trn_code_special")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WalletTransactionId)
                .HasMaxLength(50)
                .HasColumnName("wallet_transaction_id");
            entity.Property(e => e.WalletUserFee)
                .HasColumnType("double(12,4)")
                .HasColumnName("wallet_user_fee");
        });

        modelBuilder.Entity<FraudRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fraud_rules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountLists)
                .HasComment("Comma Separated Value")
                .HasColumnType("text")
                .HasColumnName("amount_lists");
            entity.Property(e => e.ApprovedAt)
                .HasColumnType("datetime")
                .HasColumnName("approved_at");
            entity.Property(e => e.ApprovedById).HasColumnName("approved_by_id");
            entity.Property(e => e.ApprovedResponseCodeMinimumOccurrence).HasColumnName("approved_response_code_minimum_occurrence");
            entity.Property(e => e.AssignMerchants)
                .HasComment("0 = Please Select, 1 = All, 2 = Few, 3 = Except Few")
                .HasColumnName("assign_merchants");
            entity.Property(e => e.AssignMerchantsId)
                .HasComment("all the merchant ids presented here as comma separated value")
                .HasColumnType("text")
                .HasColumnName("assign_merchants_id");
            entity.Property(e => e.BannedKeywords)
                .HasComment("Banned keywords in comma separated way")
                .HasColumnType("text")
                .HasColumnName("banned_keywords");
            entity.Property(e => e.CardCategory)
                .HasComment("0 = Please select,\r\n1 = Domestic,\r\n2 = Foreign")
                .HasColumnName("card_category");
            entity.Property(e => e.CardType)
                .HasComment("0=Please Select,1=Any,2=Master Card,3=Visa Card,4=Amex,5=Diners,6=Discover,7=JCB")
                .HasColumnName("card_type");
            entity.Property(e => e.CardTypeNoStartFrom)
                .HasMaxLength(150)
                .HasComment("4343xxxxx")
                .HasColumnName("card_type_no_start_from");
            entity.Property(e => e.CardTypeNoStartTo)
                .HasMaxLength(150)
                .HasComment("43234xxxx")
                .HasColumnName("card_type_no_start_to");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(255)
                .HasComment("All currency add as a comma separated value")
                .HasColumnName("currency_id");
            entity.Property(e => e.DeclinedResponseCode)
                .HasMaxLength(150)
                .HasComment("All response code add as a comma separated value	")
                .HasColumnName("declined_response_code");
            entity.Property(e => e.DeclinedResponseCodeMinimumOccurrence).HasColumnName("declined_response_code_minimum_occurrence");
            entity.Property(e => e.Formula)
                .HasMaxLength(255)
                .HasColumnName("formula");
            entity.Property(e => e.IpCountryType)
                .HasComment("0 = Please Select,1 = IP White List,2 = Ip Black List,3 = Country White List,4 = Country Black List,")
                .HasColumnName("ip_country_type");
            entity.Property(e => e.IpCountryTypeList)
                .HasComment("All IP add as a comma separated value")
                .HasColumnType("text")
                .HasColumnName("ip_country_type_list");
            entity.Property(e => e.IsBinIpCountryActive)
                .HasComment("default=0,0=Not Active,1=Active")
                .HasColumnName("is_bin_ip_country_active");
            entity.Property(e => e.IsFormulaApplied)
                .HasComment("0=Not Applied, 1=Applied")
                .HasColumnName("is_formula_applied");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(255)
                .HasComment("1 = Email,\r\n2 = SMS,\r\n3 = Push Notification")
                .HasColumnName("notification_type");
            entity.Property(e => e.NumberOfDifferentCards).HasColumnName("number_of_different_cards");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasComment("0 = All,1 = Credit Card,2 = Debit Card,3 = Mobile Payment,4 = Wallet, Data add as a comma Separated value")
                .HasColumnName("payment_method");
            entity.Property(e => e.Revenue)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = Disabled, 1 = Greater Than(>), 2 = Less Than(<), 3 = Greater Than Or Equal(>=), 4 = Less Than Or Equal(<=), 5 = Equal(=), 6 = Not Equal(!=)")
                .HasColumnName("revenue");
            entity.Property(e => e.RevenueDurationType)
                .HasComment("1 => Last X Minute, 2 => Last X Hour, 3 => Last X Daily, 4 => Last X Monthly.")
                .HasColumnName("revenue_duration_type");
            entity.Property(e => e.RevenueDurationValue)
                .HasComment("Value of revenue duration")
                .HasColumnName("revenue_duration_value");
            entity.Property(e => e.RevenuePercentage)
                .HasDefaultValueSql("'0'")
                .HasComment("Percentage of revenue to compare")
                .HasColumnName("revenue_percentage");
            entity.Property(e => e.RuleCategory)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = Passive\r\n2 = Active")
                .HasColumnName("rule_category");
            entity.Property(e => e.RuleDescription)
                .HasColumnType("text")
                .HasColumnName("rule_description");
            entity.Property(e => e.RuleName)
                .HasMaxLength(70)
                .HasColumnName("rule_name");
            entity.Property(e => e.RulePaymentType)
                .HasDefaultValueSql("'2'")
                .HasComment("1=all, 2=ccredit card, 3= wallet, 4=mobile payment")
                .HasColumnName("rule_payment_type");
            entity.Property(e => e.RuleType)
                .HasComment("0 = General, 1 = Different Merchant Same Card, 2 = Same Merchant Same Card, 3 = Foreign Credit Card, 4 = Same Merchant, 5 = Different Merchant, 6 = Amount List, 7 = Same Merchant IP, 8 = Different Merchant IP, 9 = Same Card, 10 = Different Card, 11 = Risky Decline Codes, 12 = Rule on Existing Rules")
                .HasColumnName("rule_type");
            entity.Property(e => e.Score)
                .HasComment("1 - 100")
                .HasColumnName("score");
            entity.Property(e => e.Severity)
                .HasComment("0 = Please Select,1 = Low,2 = Medium,3 = High,")
                .HasColumnName("severity");
            entity.Property(e => e.Status)
                .HasComment("0=Not Active, 1=Active, 2=Inactive to waiting for approval, 3=Active to waiting for approval")
                .HasColumnName("status");
            entity.Property(e => e.TotalTransactionAmount)
                .HasComment("0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,")
                .HasColumnName("total_transaction_amount");
            entity.Property(e => e.TotalTransactionAmountFrom).HasColumnName("total_transaction_amount_from");
            entity.Property(e => e.TotalTransactionAmountNoOfDays).HasColumnName("total_transaction_amount_no_of_days");
            entity.Property(e => e.TotalTransactionAmountPeriod)
                .HasComment("0 = today, 1 = Last X days")
                .HasColumnName("total_transaction_amount_period");
            entity.Property(e => e.TotalTransactionAmountTo).HasColumnName("total_transaction_amount_to");
            entity.Property(e => e.TotalTransactionNumber)
                .HasComment("0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,")
                .HasColumnName("total_transaction_number");
            entity.Property(e => e.TotalTransactionNumberFrom).HasColumnName("total_transaction_number_from");
            entity.Property(e => e.TotalTransactionNumberNoOfDays).HasColumnName("total_transaction_number_no_of_days");
            entity.Property(e => e.TotalTransactionNumberPeriod)
                .HasComment("0 = today, 1 = Last X days")
                .HasColumnName("total_transaction_number_period");
            entity.Property(e => e.TotalTransactionNumberTo).HasColumnName("total_transaction_number_to");
            entity.Property(e => e.TransactionAmount)
                .HasComment("0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,")
                .HasColumnName("transaction_amount");
            entity.Property(e => e.TransactionAmountFrom).HasColumnName("transaction_amount_from");
            entity.Property(e => e.TransactionAmountTo).HasColumnName("transaction_amount_to");
            entity.Property(e => e.TransactionPeriod)
                .HasComment("0 = Please Select,1 = Date and Time,2 = Date Only,3 = Time Only,4 = Today,5 = Last x Day,6 = Last x hour,")
                .HasColumnName("transaction_period");
            entity.Property(e => e.TransactionPeriodDateFrom).HasColumnName("transaction_period_date_from");
            entity.Property(e => e.TransactionPeriodDateTo).HasColumnName("transaction_period_date_to");
            entity.Property(e => e.TransactionPeriodDatetimeFrom)
                .HasColumnType("datetime")
                .HasColumnName("transaction_period_datetime_from");
            entity.Property(e => e.TransactionPeriodDatetimeTo)
                .HasColumnType("datetime")
                .HasColumnName("transaction_period_datetime_to");
            entity.Property(e => e.TransactionPeriodOperator)
                .HasComment("0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,")
                .HasColumnName("transaction_period_operator");
            entity.Property(e => e.TransactionPeriodTimeFrom)
                .HasColumnType("time")
                .HasColumnName("transaction_period_time_from");
            entity.Property(e => e.TransactionPeriodTimeTo)
                .HasColumnType("time")
                .HasColumnName("transaction_period_time_to");
            entity.Property(e => e.TransactionPeriodXDays)
                .HasMaxLength(70)
                .HasColumnName("transaction_period_x_days");
            entity.Property(e => e.TransactionPeriodXHours)
                .HasMaxLength(70)
                .HasColumnName("transaction_period_x_hours");
            entity.Property(e => e.TransactionStateType)
                .HasComment(" 0 = Please select, 1 = Approved, 2 = Approved but previously declined, 3 = declined")
                .HasColumnName("transaction_state_type");
            entity.Property(e => e.TransactionType)
                .HasComment("0 = Please Select, 1 = All, 2 = 2d, 3 = 3d")
                .HasColumnName("transaction_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<FullCardBlockList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("full_card_block_list")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CcBlockListId)
                .HasComment("primary key of cc_block_list table")
                .HasColumnName("cc_block_list_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.HashedCard)
                .HasMaxLength(100)
                .HasComment("Card is being stored as hash")
                .HasColumnName("hashed_card");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<GovBtransEphpycni>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gov_btrans_ephpycni")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountType).HasColumnName("account_type");
            entity.Property(e => e.Batch)
                .HasMaxLength(30)
                .HasComment("Unique Batch Number")
                .HasColumnName("batch");
            entity.Property(e => e.ClientDescription)
                .HasMaxLength(300)
                .HasColumnName("client_description");
            entity.Property(e => e.Commission)
                .HasPrecision(16, 2)
                .HasColumnName("commission");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(3)
                .HasComment("company code ex: 048 for sipay")
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .HasComment("TRY, USD, EUR etc")
                .HasColumnName("currency_code");
            entity.Property(e => e.IsClientSender)
                .HasMaxLength(1)
                .HasComment("E/H")
                .HasColumnName("is_client_sender");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_id");
            entity.Property(e => e.MerchantsAddress)
                .HasMaxLength(100)
                .HasColumnName("merchants_address");
            entity.Property(e => e.MerchantsAuthorizedPhone)
                .HasMaxLength(15)
                .HasColumnName("merchants_authorized_phone");
            entity.Property(e => e.MerchantsCity)
                .HasMaxLength(20)
                .HasColumnName("merchants_city");
            entity.Property(e => e.MerchantsCountryCode)
                .HasMaxLength(2)
                .HasComment("(ISO STANDARTS FOR EXAMPLE; TR, US, FR, NL)")
                .HasColumnName("merchants_country_code");
            entity.Property(e => e.MerchantsCurrency)
                .HasMaxLength(3)
                .HasColumnName("merchants_currency");
            entity.Property(e => e.MerchantsDistrict)
                .HasMaxLength(16)
                .HasColumnName("merchants_district");
            entity.Property(e => e.MerchantsLicenseTag)
                .HasMaxLength(3)
                .HasColumnName("merchants_license_tag");
            entity.Property(e => e.MerchantsZipCode)
                .HasMaxLength(5)
                .HasColumnName("merchants_zip_code");
            entity.Property(e => e.MerhcantsAuthorizedEmail)
                .HasMaxLength(30)
                .HasColumnName("merhcants_authorized_email");
            entity.Property(e => e.NetAmount)
                .HasPrecision(16, 2)
                .HasColumnName("net_amount");
            entity.Property(e => e.NetAmountTry)
                .HasPrecision(16, 2)
                .HasColumnName("net_amount_try");
            entity.Property(e => e.OperationType)
                .HasMaxLength(5)
                .HasComment("EP002, OK003 , KK101")
                .HasColumnName("operation_type");
            entity.Property(e => e.ProcessDate)
                .HasMaxLength(8)
                .HasColumnName("process_date");
            entity.Property(e => e.ReceiverBankName)
                .HasMaxLength(50)
                .HasColumnName("receiver_bank_name");
            entity.Property(e => e.ReceiverIdType)
                .HasComment("1= Prepaid Card No, 2= Additional Card 3= Phone No, 4= E-mail Adress, 5=Merchant/User Id, 6=Credit Card No, 7=TCKN, 8=Agent of PF, 9=e-Money account, 10=Payment account")
                .HasColumnName("receiver_id_type");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(50)
                .HasColumnName("receiver_name");
            entity.Property(e => e.ReceiverSurname)
                .HasMaxLength(50)
                .HasColumnName("receiver_surname");
            entity.Property(e => e.ReceiverTckn)
                .HasMaxLength(50)
                .HasColumnName("receiver_tckn");
            entity.Property(e => e.RecordType)
                .HasMaxLength(1)
                .HasComment("E for first send, D for update, S for delete, İ for refund")
                .HasColumnName("record_type");
            entity.Property(e => e.RecordUniqueId)
                .HasMaxLength(100)
                .HasComment("unique id for every record	")
                .HasColumnName("record_unique_id");
            entity.Property(e => e.SenderBrandFullCompanyName)
                .HasMaxLength(300)
                .HasColumnName("sender_brand_full_company_name");
            entity.Property(e => e.SenderBrandVkn)
                .HasMaxLength(10)
                .HasColumnName("sender_brand_vkn");
            entity.Property(e => e.SenderIdType)
                .HasComment("1=T.C. ID Card,2=Old type T.C. ID Card, 3=Driver Licence 4=Passport 5=Other")
                .HasColumnName("sender_id_type");
            entity.Property(e => e.SenderName)
                .HasMaxLength(50)
                .HasColumnName("sender_name");
            entity.Property(e => e.SenderSurname)
                .HasMaxLength(50)
                .HasColumnName("sender_surname");
            entity.Property(e => e.SenderTckn)
                .HasMaxLength(50)
                .HasColumnName("sender_tckn");
            entity.Property(e => e.Source)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=>our system data, 2=> wallet gate data")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasComment("0 => Not Processed,1 => Pending,2 => Rejected,3 => Completed")
                .HasColumnName("status");
            entity.Property(e => e.TransactionChannel)
                .HasComment("1=bank branch, 2= agent of pf, 3=ATM/Kiosk, 4-Other PF company, 5=Mobile App ,6=Web Site")
                .HasColumnName("transaction_channel");
            entity.Property(e => e.TransactionDateTime)
                .HasComment("datetime of transaction")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date_time");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasComment("Transaction Id")
                .HasColumnName("transaction_id");
            entity.Property(e => e.TransactionableType)
                .HasMaxLength(300)
                .HasColumnName("transactionable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<GovBtransEpkbb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gov_btrans_epkbb")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MerchantId, "merchant_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountType)
                .HasComment("1= Prepaid Card Number, 2= Additional Card, 3= Phone Number, 4= Email Address, 5=Customer Number/Merchant Number 6=TCKN,7=e-money,8=Agent of PF, 9=Payment Account")
                .HasColumnName("account_type");
            entity.Property(e => e.Batch)
                .HasMaxLength(30)
                .HasComment("Unique Batch Number")
                .HasColumnName("batch");
            entity.Property(e => e.CardActivationDate)
                .HasMaxLength(8)
                .HasComment("YYYYMMDD")
                .HasColumnName("card_activation_date");
            entity.Property(e => e.CardCloseDate)
                .HasMaxLength(8)
                .HasComment("YYYYMMDD")
                .HasColumnName("card_close_date");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(19)
                .HasComment("19 digits card number")
                .HasColumnName("card_number");
            entity.Property(e => e.CardStatus)
                .HasComment("1= New, 2= Update, 3= Cancel,4=Close")
                .HasColumnName("card_status");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(3)
                .HasComment("company code ex: 048 for sipay")
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantActivationDate)
                .HasMaxLength(8)
                .HasComment("Activation Date")
                .HasColumnName("merchant_activation_date");
            entity.Property(e => e.MerchantAddress)
                .HasMaxLength(100)
                .HasComment("Address 1 of Merchant")
                .HasColumnName("merchant_address");
            entity.Property(e => e.MerchantAuthorizedEmail)
                .HasMaxLength(30)
                .HasComment("Authorized Person Phone Number of Merchant\r\n\"* Authorized Person E-Mail of Merchant")
                .HasColumnName("merchant_authorized_email");
            entity.Property(e => e.MerchantAuthorizedPhone)
                .HasMaxLength(15)
                .HasComment("Authorized Person Phone Number of Merchant\r\n\"* Authorized Person E-Mail of Merchant")
                .HasColumnName("merchant_authorized_phone");
            entity.Property(e => e.MerchantBalance)
                .HasPrecision(16, 2)
                .HasComment("Total Balance of merchant")
                .HasColumnName("merchant_balance");
            entity.Property(e => e.MerchantCity)
                .HasMaxLength(50)
                .HasComment("city of merchant")
                .HasColumnName("merchant_city");
            entity.Property(e => e.MerchantCloseDate)
                .HasMaxLength(20)
                .HasColumnName("merchant_close_date");
            entity.Property(e => e.MerchantCompanyName)
                .HasMaxLength(300)
                .HasComment("Full company name of Merchant")
                .HasColumnName("merchant_company_name");
            entity.Property(e => e.MerchantCountryCode)
                .HasMaxLength(2)
                .HasComment("ex: TR")
                .HasColumnName("merchant_country_code");
            entity.Property(e => e.MerchantCurrencyCode)
                .HasMaxLength(3)
                .HasComment("According to ISO standards For example; TRY, USD, EUR, XAU")
                .HasColumnName("merchant_currency_code");
            entity.Property(e => e.MerchantDistrict)
                .HasMaxLength(50)
                .HasComment("district of merchant")
                .HasColumnName("merchant_district");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantIdType)
                .HasComment("1=TCKN ,2=OLD TCKN,3=Driver license,4=Passsport,5=Other\"")
                .HasColumnName("merchant_id_type");
            entity.Property(e => e.MerchantLicenseTag)
                .HasMaxLength(3)
                .HasComment("License Tag of Merchant ")
                .HasColumnName("merchant_license_tag");
            entity.Property(e => e.MerchantStatus)
                .HasComment("1= When a merchant first activated, \r\n2= Update on balance or address of merchant, \r\n3= Cancel, \r\n4=Closed")
                .HasColumnName("merchant_status");
            entity.Property(e => e.MerchantTckn)
                .HasMaxLength(50)
                .HasComment("TCKN of Merchant")
                .HasColumnName("merchant_tckn");
            entity.Property(e => e.MerchantVkn)
                .HasMaxLength(10)
                .HasComment("VKN / Tax Number of Merchant")
                .HasColumnName("merchant_vkn");
            entity.Property(e => e.MerchantZipCode)
                .HasMaxLength(5)
                .HasComment("Zip Code of Merchant")
                .HasColumnName("merchant_zip_code");
            entity.Property(e => e.OperationType)
                .HasMaxLength(5)
                .HasComment("ex: EP002")
                .HasColumnName("operation_type");
            entity.Property(e => e.RecordType)
                .HasMaxLength(1)
                .HasComment("E for first send, D for edit, S for delete, İ for Refund")
                .HasColumnName("record_type");
            entity.Property(e => e.RecordUniqueId)
                .HasMaxLength(100)
                .HasComment("unique id for every record ")
                .HasColumnName("record_unique_id");
            entity.Property(e => e.Source)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=>our system data, 2=> wallet gate data")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasComment("0 => Not Processed,1 => Pending,2 => Rejected,3 => Completed")
                .HasColumnName("status");
            entity.Property(e => e.TransactionDateTime)
                .HasComment("datetime of transaction")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date_time");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasComment("lref for btrans")
                .HasColumnName("transaction_id");
            entity.Property(e => e.TransactionType)
                .HasComment("1 => name,\r\n2 => balance")
                .HasColumnName("transaction_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsersName)
                .HasMaxLength(50)
                .HasComment("name of merchant")
                .HasColumnName("users_name");
            entity.Property(e => e.UsersSurname)
                .HasMaxLength(50)
                .HasComment("surname of merchant")
                .HasColumnName("users_surname");
        });

        modelBuilder.Entity<GovBtransOkkib>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gov_btrans_okkib")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankAtmCode)
                .HasMaxLength(16)
                .HasColumnName("bank_atm_code");
            entity.Property(e => e.BankEftCode)
                .HasMaxLength(4)
                .HasColumnName("bank_eft_code");
            entity.Property(e => e.BankType)
                .HasMaxLength(1)
                .HasColumnName("bank_type");
            entity.Property(e => e.Batch)
                .HasMaxLength(30)
                .HasComment("Unique Batch Number")
                .HasColumnName("batch");
            entity.Property(e => e.CardHolderIdType)
                .HasMaxLength(1)
                .HasColumnName("card_holder_id_type");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(50)
                .HasColumnName("card_holder_name");
            entity.Property(e => e.CardHolderSurname)
                .HasMaxLength(50)
                .HasColumnName("card_holder_surname");
            entity.Property(e => e.CardHolderTckn)
                .HasMaxLength(50)
                .HasColumnName("card_holder_tckn");
            entity.Property(e => e.CardHolderTitle)
                .HasMaxLength(300)
                .HasColumnName("card_holder_title");
            entity.Property(e => e.CardHolderVkn)
                .HasMaxLength(10)
                .HasColumnName("card_holder_vkn");
            entity.Property(e => e.CardNo)
                .HasMaxLength(16)
                .HasColumnName("card_no");
            entity.Property(e => e.ClientDescription)
                .HasMaxLength(300)
                .HasColumnName("client_description");
            entity.Property(e => e.Commission)
                .HasPrecision(16, 2)
                .HasColumnName("commission");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(3)
                .HasComment("company code ex: 048 for sipay")
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .HasColumnName("currency_code");
            entity.Property(e => e.NetAmount)
                .HasPrecision(16, 2)
                .HasColumnName("net_amount");
            entity.Property(e => e.OperationType)
                .HasMaxLength(5)
                .HasColumnName("operation_type");
            entity.Property(e => e.ProcessDate)
                .HasMaxLength(8)
                .HasColumnName("process_date");
            entity.Property(e => e.RecordType)
                .HasMaxLength(1)
                .HasColumnName("record_type");
            entity.Property(e => e.RecordUniqueId)
                .HasMaxLength(100)
                .HasComment("unique id for every record	")
                .HasColumnName("record_unique_id");
            entity.Property(e => e.Source)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=>our system data, 2=> wallet gate data")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasComment("0 => Not Processed,1 => Pending,2 => Rejected,3 => Completed")
                .HasColumnName("status");
            entity.Property(e => e.TransactionAmount)
                .HasPrecision(16, 2)
                .HasColumnName("transaction_amount");
            entity.Property(e => e.TransactionDateTime)
                .HasComment("datetime of transaction")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date_time");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");
            entity.Property(e => e.TransactionableType)
                .HasMaxLength(300)
                .HasColumnName("transactionable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<GovBtransPfRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gov_btrans_pf_records")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankIssuerDigit)
                .HasMaxLength(5)
                .HasColumnName("bank_issuer_digit");
            entity.Property(e => e.BankTerminalId)
                .HasMaxLength(50)
                .HasColumnName("bank_terminal_id");
            entity.Property(e => e.BrandFullCompanyName)
                .HasMaxLength(300)
                .HasColumnName("brand_full_company_name");
            entity.Property(e => e.BrandVkn)
                .HasMaxLength(10)
                .HasColumnName("brand_vkn");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PosAccountBankCode)
                .HasMaxLength(8)
                .HasColumnName("pos_account_bank_code");
            entity.Property(e => e.PosAccountBankIban)
                .HasMaxLength(26)
                .HasColumnName("pos_account_bank_iban");
            entity.Property(e => e.PosAccountBankName)
                .HasMaxLength(50)
                .HasColumnName("pos_account_bank_name");
            entity.Property(e => e.PosBankName)
                .HasMaxLength(100)
                .HasColumnName("pos_bank_name");
            entity.Property(e => e.ReferenceId)
                .HasDefaultValueSql("'0'")
                .HasComment("Referencable  id against type. Ex. sale id or withdrawal id or deposit id")
                .HasColumnName("reference_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Sale , 2 => Withdrawal, 3 => Deposit")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<GovBtransReportHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gov_btrans_report_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch)
                .HasMaxLength(30)
                .HasComment("Unique Batch Number")
                .HasColumnName("batch");
            entity.Property(e => e.Counter).HasColumnName("counter");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .HasColumnName("file_name");
            entity.Property(e => e.NextProcessDatetime)
                .HasComment("Next Processable Datetime for CronJOB")
                .HasColumnType("datetime")
                .HasColumnName("next_process_datetime");
            entity.Property(e => e.RemoteStatus)
                .HasColumnType("text")
                .HasColumnName("remote_status");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0 => Not Processed , 1 => Pending, 2 => Rejected, 3 => Completed")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'0'")
                .HasComment("1=EPKBB\r\n2=SFP\r\n3=YT")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<GovBtransSfp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gov_btrans_sfp")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Batch, "batch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankCode)
                .HasMaxLength(5)
                .HasColumnName("bank_code");
            entity.Property(e => e.BankTerminalNo)
                .HasMaxLength(50)
                .HasColumnName("bank_terminal_no");
            entity.Property(e => e.Batch)
                .HasMaxLength(30)
                .HasComment("Unique Batch Number")
                .HasColumnName("batch");
            entity.Property(e => e.BrandFullCompanyName)
                .HasMaxLength(300)
                .HasComment("Full Company Name of Brand")
                .HasColumnName("brand_full_company_name");
            entity.Property(e => e.BrandVkn)
                .HasMaxLength(10)
                .HasComment("VKN of Brand")
                .HasColumnName("brand_vkn");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(3)
                .HasComment("company code ex: 048")
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Lref)
                .HasMaxLength(50)
                .HasComment("Unique string every report item")
                .HasColumnName("lref");
            entity.Property(e => e.MerchantAddress)
                .HasMaxLength(100)
                .HasComment("Address 1 of Merchant")
                .HasColumnName("merchant_address");
            entity.Property(e => e.MerchantAuthUserName)
                .HasMaxLength(50)
                .HasComment("USER ")
                .HasColumnName("merchant_auth_user_name");
            entity.Property(e => e.MerchantAuthUserSurname)
                .HasMaxLength(50)
                .HasComment("AUTH USER SURNAME")
                .HasColumnName("merchant_auth_user_surname");
            entity.Property(e => e.MerchantAuthorizedPhone)
                .HasMaxLength(15)
                .HasComment("Authorized Person Phone Number of Merchant")
                .HasColumnName("merchant_authorized_phone");
            entity.Property(e => e.MerchantCity)
                .HasMaxLength(50)
                .HasColumnName("merchant_city");
            entity.Property(e => e.MerchantCountryCode)
                .HasMaxLength(4)
                .HasComment("ex: TR")
                .HasColumnName("merchant_country_code");
            entity.Property(e => e.MerchantDistrict)
                .HasMaxLength(16)
                .HasComment("District of Merchant")
                .HasColumnName("merchant_district");
            entity.Property(e => e.MerchantFullCompanyName)
                .HasMaxLength(300)
                .HasComment("Full Company Name of Merchant")
                .HasColumnName("merchant_full_company_name");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantLicenseTag)
                .HasMaxLength(3)
                .HasComment("License Tag of Merchant ")
                .HasColumnName("merchant_license_tag");
            entity.Property(e => e.MerchantTckn)
                .HasMaxLength(50)
                .HasComment("TCKN of Merchant")
                .HasColumnName("merchant_tckn");
            entity.Property(e => e.MerchantVkn)
                .HasMaxLength(10)
                .HasComment("VKN / Tax Number of Merchant")
                .HasColumnName("merchant_vkn");
            entity.Property(e => e.MerchantZipCode)
                .HasMaxLength(5)
                .HasComment("Zip Code of Merchant")
                .HasColumnName("merchant_zip_code");
            entity.Property(e => e.OperationType)
                .HasMaxLength(5)
                .HasComment("SP002 - Virtual POS, FS001 - Physical POS")
                .HasColumnName("operation_type");
            entity.Property(e => e.PosAccountBankCode)
                .HasMaxLength(8)
                .HasColumnName("pos_account_bank_code");
            entity.Property(e => e.PosAccountBankIban)
                .HasMaxLength(26)
                .HasColumnName("pos_account_bank_iban");
            entity.Property(e => e.PosAccountBankName)
                .HasMaxLength(50)
                .HasColumnName("pos_account_bank_name");
            entity.Property(e => e.PosBankName)
                .HasMaxLength(50)
                .HasColumnName("pos_bank_name");
            entity.Property(e => e.PosId)
                .HasMaxLength(16)
                .HasColumnName("pos_id");
            entity.Property(e => e.RecordType)
                .HasMaxLength(1)
                .HasComment("E - Sending for the first time, D - Update, S - Delete, I - Refund of Withdraw(when we cancel it after its sent to BTrans)")
                .HasColumnName("record_type");
            entity.Property(e => e.SaleCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("sale_created_at");
            entity.Property(e => e.SaleCurrencyCode)
                .HasMaxLength(3)
                .HasComment("ex: TRY/USD")
                .HasColumnName("sale_currency_code");
            entity.Property(e => e.SaleDescription)
                .HasMaxLength(300)
                .HasComment("Description of a sale")
                .HasColumnName("sale_description");
            entity.Property(e => e.SaleGross)
                .HasPrecision(16, 2)
                .HasComment("Sale net amount")
                .HasColumnName("sale_gross");
            entity.Property(e => e.SaleMerchantCommission)
                .HasPrecision(16, 2)
                .HasComment("Sale Merchant Commission")
                .HasColumnName("sale_merchant_commission");
            entity.Property(e => e.SaleNet)
                .HasPrecision(16, 2)
                .HasComment("Sale net amount")
                .HasColumnName("sale_net");
            entity.Property(e => e.SaleNetTry)
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_net_try");
            entity.Property(e => e.SaleSettlementDateMerchant)
                .HasColumnType("datetime")
                .HasColumnName("sale_settlement_date_merchant");
            entity.Property(e => e.Source)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=>our system data, 2=> wallet gate data")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasComment("0 => Not Processed , \r\n1 => Pending,\r\n2 => Rejected,\r\n3 => Completed")
                .HasColumnName("status");
            entity.Property(e => e.TransactionDateTime)
                .HasComment("datetime of transaction")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date_time");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<GovBtransYt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gov_btrans_yt")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MerchantId, "merchant_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivationDate)
                .HasComment("Activation Date")
                .HasColumnName("activation_date");
            entity.Property(e => e.Balance)
                .HasPrecision(16, 2)
                .HasComment("Total Balance of merchant")
                .HasColumnName("balance");
            entity.Property(e => e.Batch)
                .HasMaxLength(30)
                .HasComment("Unique Batch Number yyyy-mm-dd-serial")
                .HasColumnName("batch");
            entity.Property(e => e.BranchAuthorisedCity)
                .HasMaxLength(20)
                .HasColumnName("branch_authorised_city");
            entity.Property(e => e.BranchAuthorisedName)
                .HasMaxLength(300)
                .HasColumnName("branch_authorised_name");
            entity.Property(e => e.BranchAuthorisedVkn)
                .HasMaxLength(10)
                .HasColumnName("branch_authorised_vkn");
            entity.Property(e => e.ClientDescription)
                .HasMaxLength(300)
                .HasColumnName("client_description");
            entity.Property(e => e.Commission)
                .HasPrecision(16, 2)
                .HasComment("total commission")
                .HasColumnName("commission");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(3)
                .HasComment("company code ex: 048 for sipay")
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .HasComment("According to ISO standards For example; TRY, USD, EUR, XAU")
                .HasColumnName("currency_code");
            entity.Property(e => e.IsClientReceiver)
                .HasMaxLength(1)
                .HasComment("E for Yes, H for No")
                .HasColumnName("is_client_receiver");
            entity.Property(e => e.IsClientSender)
                .HasMaxLength(1)
                .HasComment("E for Yes, H for No")
                .HasColumnName("is_client_sender");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.NetAmount)
                .HasPrecision(16, 2)
                .HasComment("total amount")
                .HasColumnName("net_amount");
            entity.Property(e => e.OperationType)
                .HasMaxLength(5)
                .HasComment("ex: 00004")
                .HasColumnName("operation_type");
            entity.Property(e => e.ProcessDate)
                .HasMaxLength(8)
                .HasComment("date of processing")
                .HasColumnName("process_date");
            entity.Property(e => e.ProcessTime)
                .HasMaxLength(6)
                .HasComment("time of processing")
                .HasColumnName("process_time");
            entity.Property(e => e.ReceiverAddress)
                .HasMaxLength(100)
                .HasComment("Address 1 of Merchant")
                .HasColumnName("receiver_address");
            entity.Property(e => e.ReceiverAuthorizedEmail)
                .HasMaxLength(30)
                .HasComment("Authorized Person Phone Number of Merchant\r\n\"* Authorized Person E-Mail of Merchant")
                .HasColumnName("receiver_authorized_email");
            entity.Property(e => e.ReceiverAuthorizedPhone)
                .HasMaxLength(15)
                .HasComment("Authorized Person Phone Number of Merchant")
                .HasColumnName("receiver_authorized_phone");
            entity.Property(e => e.ReceiverBankAccount)
                .HasMaxLength(40)
                .HasComment("bank account of receiver")
                .HasColumnName("receiver_bank_account");
            entity.Property(e => e.ReceiverBankAccountIban)
                .HasMaxLength(40)
                .HasComment("Iban of receiver")
                .HasColumnName("receiver_bank_account_Iban");
            entity.Property(e => e.ReceiverBankBranchCode)
                .HasMaxLength(50)
                .HasComment("branch code of receiver")
                .HasColumnName("receiver_bank_branch_code");
            entity.Property(e => e.ReceiverBankCode)
                .HasMaxLength(8)
                .HasComment("bank code of receiver")
                .HasColumnName("receiver_bank_code");
            entity.Property(e => e.ReceiverBankName)
                .HasMaxLength(50)
                .HasComment("bank name of receiver")
                .HasColumnName("receiver_bank_name");
            entity.Property(e => e.ReceiverBrandBankIban)
                .HasMaxLength(26)
                .HasColumnName("receiver_brand_bank_iban");
            entity.Property(e => e.ReceiverBrandFullCompanyName)
                .HasMaxLength(300)
                .HasComment("brand full company name of receiver")
                .HasColumnName("receiver_brand_full_company_name");
            entity.Property(e => e.ReceiverBrandVkn)
                .HasMaxLength(10)
                .HasComment("brand vkn of receiver")
                .HasColumnName("receiver_brand_vkn");
            entity.Property(e => e.ReceiverCardNo)
                .HasMaxLength(16)
                .HasColumnName("receiver_card_no");
            entity.Property(e => e.ReceiverCity)
                .HasMaxLength(50)
                .HasComment("city of merchant")
                .HasColumnName("receiver_city");
            entity.Property(e => e.ReceiverCompanyName)
                .HasMaxLength(300)
                .HasComment("Full company name of Merchant")
                .HasColumnName("receiver_company_name");
            entity.Property(e => e.ReceiverCountryCode)
                .HasMaxLength(2)
                .HasComment("ex: TR")
                .HasColumnName("receiver_country_code");
            entity.Property(e => e.ReceiverCreditCardNo)
                .HasMaxLength(16)
                .HasColumnName("receiver_credit_card_no");
            entity.Property(e => e.ReceiverDebitCardNo)
                .HasMaxLength(16)
                .HasColumnName("receiver_debit_card_no");
            entity.Property(e => e.ReceiverDistrict)
                .HasMaxLength(10)
                .HasComment("district of receiver merchant")
                .HasColumnName("receiver_district");
            entity.Property(e => e.ReceiverEMoneyAccount)
                .HasMaxLength(16)
                .HasColumnName("receiver_e_money_account");
            entity.Property(e => e.ReceiverIdType)
                .HasComment("1 for tckn")
                .HasColumnName("receiver_id_type");
            entity.Property(e => e.ReceiverLicenseTag)
                .HasMaxLength(3)
                .HasComment("License Tag of Merchant ")
                .HasColumnName("receiver_license_tag");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(50)
                .HasComment("name of merchant")
                .HasColumnName("receiver_name");
            entity.Property(e => e.ReceiverSurname)
                .HasMaxLength(50)
                .HasComment("surname of merchant")
                .HasColumnName("receiver_surname");
            entity.Property(e => e.ReceiverTckn)
                .HasMaxLength(50)
                .HasComment("TCKN of Merchant")
                .HasColumnName("receiver_tckn");
            entity.Property(e => e.ReceiverVkn)
                .HasMaxLength(10)
                .HasComment("VKN / Tax Number of Merchant")
                .HasColumnName("receiver_vkn");
            entity.Property(e => e.ReceiverZipCode)
                .HasMaxLength(5)
                .HasComment("Zip Code of Merchant")
                .HasColumnName("receiver_zip_code");
            entity.Property(e => e.RecordType)
                .HasMaxLength(1)
                .HasComment("	E for first send, D for edit, S for delete, İ for Refund")
                .HasColumnName("record_type");
            entity.Property(e => e.RecordUniqueId)
                .HasMaxLength(100)
                .HasComment("unique id for every record ")
                .HasColumnName("record_unique_id");
            entity.Property(e => e.SenderAddress)
                .HasMaxLength(100)
                .HasComment("Address 1 of Merchant")
                .HasColumnName("sender_address");
            entity.Property(e => e.SenderAuthorizedEmail)
                .HasMaxLength(30)
                .HasComment("Authorized Person Email of Merchant")
                .HasColumnName("sender_authorized_email");
            entity.Property(e => e.SenderAuthorizedPhone)
                .HasMaxLength(15)
                .HasComment("Authorized Person Phone Number of Merchant\r\n\"* Authorized Person E-Mail of Merchant")
                .HasColumnName("sender_authorized_phone");
            entity.Property(e => e.SenderBankAccount)
                .HasMaxLength(40)
                .HasComment("Sender Merchant's IBAN No' last 7 numbers")
                .HasColumnName("sender_bank_account");
            entity.Property(e => e.SenderBankAccountIban)
                .HasMaxLength(40)
                .HasComment("Sender Iban of merchant")
                .HasColumnName("sender_bank_account_Iban");
            entity.Property(e => e.SenderBankBranchCode)
                .HasMaxLength(50)
                .HasComment("Sender branch code of bank")
                .HasColumnName("sender_bank_branch_code");
            entity.Property(e => e.SenderBankCode)
                .HasMaxLength(8)
                .HasComment("Sender bank code")
                .HasColumnName("sender_bank_code");
            entity.Property(e => e.SenderBankName)
                .HasMaxLength(50)
                .HasComment("Sender Bank of Sipay")
                .HasColumnName("sender_bank_name");
            entity.Property(e => e.SenderBrandFullCompanyName)
                .HasMaxLength(300)
                .HasComment("full company name of brand")
                .HasColumnName("sender_brand_full_company_name");
            entity.Property(e => e.SenderBrandVkn)
                .HasMaxLength(10)
                .HasComment("vkn of brand")
                .HasColumnName("sender_brand_vkn");
            entity.Property(e => e.SenderCardNo)
                .HasMaxLength(16)
                .HasColumnName("sender_card_no");
            entity.Property(e => e.SenderCity)
                .HasMaxLength(50)
                .HasComment("city of merchant")
                .HasColumnName("sender_city");
            entity.Property(e => e.SenderCompanyName)
                .HasMaxLength(300)
                .HasComment("Full company name of Merchant")
                .HasColumnName("sender_company_name");
            entity.Property(e => e.SenderCountryCode)
                .HasMaxLength(2)
                .HasComment("ex: TR")
                .HasColumnName("sender_country_code");
            entity.Property(e => e.SenderCreditCardNo)
                .HasMaxLength(16)
                .HasColumnName("sender_credit_card_no");
            entity.Property(e => e.SenderDebitCardNo)
                .HasMaxLength(16)
                .HasColumnName("sender_debit_card_no");
            entity.Property(e => e.SenderDistrict)
                .HasMaxLength(10)
                .HasComment("district of sender merchant")
                .HasColumnName("sender_district");
            entity.Property(e => e.SenderEMoneyAccount)
                .HasMaxLength(26)
                .HasColumnName("sender_e_money_account");
            entity.Property(e => e.SenderIdType)
                .HasComment("1 for tckn")
                .HasColumnName("sender_id_type");
            entity.Property(e => e.SenderLicenseTag)
                .HasMaxLength(3)
                .HasComment("License Tag of Merchant ")
                .HasColumnName("sender_license_tag");
            entity.Property(e => e.SenderName)
                .HasMaxLength(50)
                .HasComment("name of merchant")
                .HasColumnName("sender_name");
            entity.Property(e => e.SenderSurname)
                .HasMaxLength(50)
                .HasComment("surname of merchant")
                .HasColumnName("sender_surname");
            entity.Property(e => e.SenderTckn)
                .HasMaxLength(50)
                .HasComment("TCKN of Merchant")
                .HasColumnName("sender_tckn");
            entity.Property(e => e.SenderVkn)
                .HasMaxLength(10)
                .HasComment("VKN / Tax Number of Merchant")
                .HasColumnName("sender_vkn");
            entity.Property(e => e.SenderZipCode)
                .HasMaxLength(5)
                .HasComment("Zip Code of Merchant")
                .HasColumnName("sender_zip_code");
            entity.Property(e => e.Source)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=>our system data, 2=> wallet gate data")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasComment("0 => Not Processed,1 => Pending,2 => Rejected,3 => Completed")
                .HasColumnName("status");
            entity.Property(e => e.TransactionAmount)
                .HasPrecision(16, 2)
                .HasColumnName("transaction_amount");
            entity.Property(e => e.TransactionChannel)
                .HasComment("Transaction Channel: 1=Branch, 2=Agent, 3=ATM/Kiosk, 4-Other OHS, 5=Mobile and 6=Website")
                .HasColumnName("transaction_channel");
            entity.Property(e => e.TransactionDate)
                .HasMaxLength(8)
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionDateTime)
                .HasComment("datetime of transaction")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date_time");
            entity.Property(e => e.TransactionDescriptionEnum)
                .HasComment("1=Dues, 2=Residence Rent, 3=Education, 4=Credit Card Debt, 5= Personnel Payments, 6=Workplace Rent, 7=Other Rents, 8=e-commerce, 9=Other")
                .HasColumnName("transaction_description_enum");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasComment("lref for btrans")
                .HasColumnName("transaction_id");
            entity.Property(e => e.TransactionTime)
                .HasMaxLength(6)
                .HasColumnName("transaction_time");
            entity.Property(e => e.TransactionType)
                .HasComment("1 => withdraw,\r\n2 => b2b,\r\n3=> b2c bank,\r\n4 => b2c wallet")
                .HasColumnName("transaction_type");
            entity.Property(e => e.TransactionableType)
                .HasMaxLength(300)
                .HasComment("Ex: Para Çekme")
                .HasColumnName("transactionable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<HolidaySetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("holiday_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeginDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("begin_date");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ImportedTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("imported_transactions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.OrderId, "order_id_unique_key").IsUnique();

            entity.HasIndex(e => e.Id, "oxivo_transactions_id_uindex").IsUnique();

            entity.HasIndex(e => new { e.InvoiceId, e.Type }, "unique_imported_transaction_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.ImportedTransactionHistoryId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("imported_transaction_history_id");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(100)
                .HasColumnName("invoice_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantTerminalsId).HasColumnName("merchant_terminals_id");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasComment("Comment if necessary")
                .HasColumnName("note")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasComment("Unique Order ID for every single Imported Transaction")
                .HasColumnName("order_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RemoteAcquirerReference)
                .HasMaxLength(100)
                .HasComment(" Remote(Pavo, Oxivo) Transaction Acquirer Reference ")
                .HasColumnName("remote_acquirer_reference")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.RemoteOriginalReference)
                .HasMaxLength(100)
                .HasComment(" Remote(Pavo) Transaction Original Reference Number")
                .HasColumnName("remote_original_reference");
            entity.Property(e => e.RemoteRrn)
                .HasMaxLength(100)
                .HasComment(" Remote(Pavo) Transaction Retrieval Reference Number")
                .HasColumnName("remote_rrn");
            entity.Property(e => e.RemoteTransactionStateId)
                .HasComment("Remote(Oxivo, Pavo, etc) Transaction State ID. Possible values are stored as constant value of model with prefix PAVO_REMOTE_STATE or OXIVO_REMOTE_STATE etc")
                .HasColumnName("remote_transaction_state_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0 => Pending, 1 => Completed, 2 => Failed, 3 => Refunded, 4 => Partial Refunded, 5 => Ignored, 6 => Exception.")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Oxivo, 2 => Pavo, 3 => Taxi, 4 => MT, 5 => WD, 6 => Hugin, 7 => Sari_Taxi")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ImportedTransactionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("imported_transaction_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("from_date");
            entity.Property(e => e.LastProcessedId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasComment("Used For Import Transaction API")
                .HasColumnName("last_processed_id")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Status)
                .HasComment("pending = 0, processing = 2, completed = 1, failed = 3")
                .HasColumnName("status");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(50)
                .HasColumnName("terminal_id");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("to_date");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Oxivo, 2 => Pavo")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ImportedWithdrawal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("imported_withdrawals")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.UniqueId, "unique_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("withdrawal amount")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasComment("withdrawal currency id")
                .HasColumnName("currency_id");
            entity.Property(e => e.Data)
                .HasComment("withdrawal file data in json format")
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasComment("Comment if necessary")
                .HasColumnName("note")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.RemoteWithdrawalState)
                .HasComment("99 = withdrawal approve , rest of them withdrawal reject")
                .HasColumnName("remote_withdrawal_state");
            entity.Property(e => e.RevertedStatus)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not yet; 2=reverted")
                .HasColumnName("reverted_status");
            entity.Property(e => e.Status)
                .HasComment("0 = pending , 1 = processed, 2 = failed , 3 = uncounted withdrawal, 4 = error exception")
                .HasColumnName("status");
            entity.Property(e => e.TmpFileId)
                .HasDefaultValueSql("'0'")
                .HasComment("0=nothing; id from tmp_files table")
                .HasColumnName("tmp_file_id");
            entity.Property(e => e.UniqueId)
                .HasMaxLength(50)
                .HasComment("withdrawals table unique id for destination type 7")
                .HasColumnName("unique_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<IncomingWalletEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("incoming_wallet_events")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreditAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("credit_amount");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DebitAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("debit_amount");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .HasColumnName("event_name");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(100)
                .HasColumnName("payment_id");
            entity.Property(e => e.ReferenceId)
                .HasMaxLength(100)
                .HasColumnName("reference_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("1=already processed, 0=Not Process yet")
                .HasColumnName("status");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(100)
                .HasColumnName("transaction_type");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Integrator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("integrators")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .HasColumnName("address2");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DefaultCommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("default_commission_fixed");
            entity.Property(e => e.DefaultCommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("default_commission_percentage");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.IntegratorName)
                .HasMaxLength(50)
                .HasColumnName("integrator_name");
            entity.Property(e => e.IsAllowedInstallmentCommission)
                .HasComment("0 = Does not have installment, 1 = Has installments")
                .HasColumnName("is_allowed_installment_commission");
            entity.Property(e => e.IsCustomLogin)
                .HasDefaultValueSql("'0'")
                .HasComment("0=inactive, 1=active")
                .HasColumnName("is_custom_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LoginLogo)
                .HasMaxLength(255)
                .HasComment("custom login logo")
                .HasColumnName("login_logo");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UrlName)
                .HasMaxLength(30)
                .HasComment("unique custom url name")
                .HasColumnName("url_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<IntegratorInstallmentCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("integrator_installment_commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.InstallmentNumber).HasColumnName("installment_number");
            entity.Property(e => e.IntegratorCommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("integrator_commission_fixed");
            entity.Property(e => e.IntegratorCommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("integrator_commission_percentage");
            entity.Property(e => e.IntegratorId).HasColumnName("integrator_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = Inactive, 1 = Active ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<IntegratorPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("integrator_permissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IntegratorId).HasColumnName("integrator_id");
            entity.Property(e => e.Permissions)
                .HasColumnType("text")
                .HasColumnName("permissions");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Ipv4>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ipv4s")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(250)
                .HasColumnName("country_code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(2000)
                .HasColumnName("country_name");
            entity.Property(e => e.EndIpRange).HasColumnName("end_ip_range");
            entity.Property(e => e.StartIpRange).HasColumnName("start_ip_range");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("jobs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Queue, "jobs_queue_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.AvailableAt).HasColumnName("available_at");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue).HasColumnName("queue");
            entity.Property(e => e.ReservedAt).HasColumnName("reserved_at");
        });

        modelBuilder.Entity<JwtServiceCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("jwt_service_credentials")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ServiceClientId)
                .HasMaxLength(255)
                .HasColumnName("service_client_id");
            entity.Property(e => e.ServiceClientSecret)
                .HasMaxLength(255)
                .HasColumnName("service_client_secret");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<KbbVerificationRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kbb_verification_records");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.Tckn)
                .HasMaxLength(50)
                .HasColumnName("tckn");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasComment("(0=customer, 1=admin, 2=merchant) default 0")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<Kyc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kycs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DobYear)
                .HasMaxLength(4)
                .HasColumnName("dob_year");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.Tckn)
                .HasMaxLength(50)
                .HasColumnName("tckn");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Laravel2step>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("laravel2step")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "laravel2step_userid_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(191)
                .HasColumnName("authCode");
            entity.Property(e => e.AuthCount).HasColumnName("authCount");
            entity.Property(e => e.AuthDate)
                .HasColumnType("datetime")
                .HasColumnName("authDate");
            entity.Property(e => e.AuthStatus).HasColumnName("authStatus");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("requestDate");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<MarketplaceItemMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("marketplace_item_mappings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountSettlementStatus)
                .HasComment("Status for settling item_amount to wallet withdrawable_balance\r\n0 = Not Settled\r\n1 = Settled")
                .HasColumnName("amount_settlement_status");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.GlobalInvoiceId)
                .HasMaxLength(50)
                .HasColumnName("global_invoice_id");
            entity.Property(e => e.GlobalOrderId)
                .HasMaxLength(50)
                .HasColumnName("global_order_id");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.IsApproved)
                .HasDefaultValueSql("'0'")
                .HasComment("0=Awaiting, 1 = Approved , Sale approval from marketplace merchant")
                .HasColumnName("is_approved");
            entity.Property(e => e.IsRefunded)
                .HasComment("0 = Not Refunded\r\n1 = Refunded")
                .HasColumnName("is_refunded");
            entity.Property(e => e.ItemAmount)
                .HasComment("Amount to settle after deducting rolling amount")
                .HasColumnType("double(12,4)")
                .HasColumnName("item_amount");
            entity.Property(e => e.ItemApprovedDate)
                .HasComment("To track the time of item approval via Merchant through TransactionApprove API")
                .HasColumnType("datetime")
                .HasColumnName("item_approved_date");
            entity.Property(e => e.ItemId)
                .HasMaxLength(32)
                .HasColumnName("item_id");
            entity.Property(e => e.ItemPrice)
                .HasColumnType("double(12,4)")
                .HasColumnName("item_price");
            entity.Property(e => e.ItemRollingAmount)
                .HasComment("Rolling amount for a single item")
                .HasColumnType("double(12,4)")
                .HasColumnName("item_rolling_amount");
            entity.Property(e => e.ItemRollingSettlementDate)
                .HasColumnType("datetime")
                .HasColumnName("item_rolling_settlement_date");
            entity.Property(e => e.ItemSubMerchantShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("item_sub_merchant_share");
            entity.Property(e => e.ItemUnitPrice)
                .HasComment("To track the original single item_price for quantity based refund")
                .HasColumnType("double(12,4)")
                .HasColumnName("item_unit_price");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.RefundHistoryId).HasColumnName("refund_history_id");
            entity.Property(e => e.RefundRequestedAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_requested_amount");
            entity.Property(e => e.RefundedAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("refunded_amount");
            entity.Property(e => e.RollingSettlementStatus)
                .HasComment("Status for settling item_rolling_amount to wallet withdrawable_balance\r\n0 = Not Settled\r\n1= Settled")
                .HasColumnName("rolling_settlement_status");
            entity.Property(e => e.SaleId)
                .HasComment("id from master sales table")
                .HasColumnName("sale_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MarketplaceSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("marketplace_sales")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.GlobalGross)
                .HasColumnType("double(12,4)")
                .HasColumnName("global_gross");
            entity.Property(e => e.GlobalInvoiceId)
                .HasMaxLength(50)
                .HasColumnName("global_invoice_id");
            entity.Property(e => e.GlobalMerchantShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("global_merchant_share");
            entity.Property(e => e.GlobalNet)
                .HasColumnType("double(12,4)")
                .HasColumnName("global_net");
            entity.Property(e => e.GlobalOrderId)
                .HasMaxLength(50)
                .HasColumnName("global_order_id");
            entity.Property(e => e.GlobalProductPrice)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("Summation of all product_price of each sale of marketplace")
                .HasColumnType("double(12,4)")
                .HasColumnName("global_product_price");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(100)
                .HasColumnName("merchant_name");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MarketplaceSaleMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("marketplace_sale_mappings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.MerchantId, e.GlobalInvoiceId }, "merchant_id_global_invoice_id");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GlobalInvoiceId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasComment("Original Invoice ID from Request")
                .HasColumnName("global_invoice_id")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.GlobalOrderId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasComment("Original Order ID of a Sale")
                .HasColumnName("global_order_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasComment("Sub Merchant Invoice ID from Global Invoice ID")
                .HasColumnName("invoice_id")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantShare)
                .HasComment("Total share from a sale")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_share");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasComment("Sub Merchant Order ID from Global Order ID")
                .HasColumnName("order_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SubMerchantId)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasComment("Sub merchant under a Merchant")
                .HasColumnName("sub_merchant_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SubMerchantSettlementAutoApprovalDate)
                .HasComment("In case merchant fails to aprove an item for settlement via TransactionApprove API on this date item will be auto approved for settlement")
                .HasColumnType("datetime")
                .HasColumnName("sub_merchant_settlement_auto_approval_date");
            entity.Property(e => e.SubMerchantSettlementDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Sub Merchant settlement date from the settlement id in Marketplace payment request")
                .HasColumnType("datetime")
                .HasColumnName("sub_merchant_settlement_date");
            entity.Property(e => e.SubMerchantShare)
                .HasComment("Total share from a sale")
                .HasColumnType("double(12,4)")
                .HasColumnName("sub_merchant_share");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("menus")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Name, "menus_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("menu_items")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.MenuId, "menu_items_menu_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(191)
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IconClass)
                .HasMaxLength(191)
                .HasColumnName("icon_class");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Parameters)
                .HasColumnType("text")
                .HasColumnName("parameters");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Route)
                .HasMaxLength(191)
                .HasColumnName("route");
            entity.Property(e => e.Target)
                .HasMaxLength(191)
                .HasDefaultValueSql("'_self'")
                .HasColumnName("target");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasMaxLength(191)
                .HasColumnName("url");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("menu_items_menu_id_foreign");
        });

        modelBuilder.Entity<Merchant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchants")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "user_id").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActivationDate)
                .HasColumnType("datetime")
                .HasColumnName("activation_date");
            entity.Property(e => e.Address1)
                .HasColumnType("text")
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasColumnType("text")
                .HasColumnName("address2");
            entity.Property(e => e.AllowForeignCurrencyToTl)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>disable,\r\n1=> Convert foreign currency to TRY Only when limit exceed,\r\n2 => Convert foreign currency to TRY Directly")
                .HasColumnName("allow_foreign_currency_to_tl");
            entity.Property(e => e.AllowPayByToken)
                .HasDefaultValueSql("'0'")
                .HasColumnName("allow_pay_by_token");
            entity.Property(e => e.AllowTokenLessAccess)
                .HasDefaultValueSql("'0'")
                .HasComment("0= not allowed, 1= allowed")
                .HasColumnName("allow_token_less_access");
            entity.Property(e => e.ApplicationDate)
                .HasColumnType("datetime")
                .HasColumnName("application_date");
            entity.Property(e => e.AuthorizedPersonEmail)
                .HasMaxLength(50)
                .HasColumnName("authorized_person_email");
            entity.Property(e => e.AuthorizedPersonName)
                .HasMaxLength(100)
                .HasColumnName("authorized_person_name");
            entity.Property(e => e.AuthorizedPersonPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("authorized_person_phone_number");
            entity.Property(e => e.AverageTurnover)
                .HasMaxLength(150)
                .HasColumnName("average_turnover");
            entity.Property(e => e.BusinessArea)
                .HasMaxLength(155)
                .HasColumnName("business_area");
            entity.Property(e => e.CalculatePosByBank)
                .HasDefaultValueSql("'0'")
                .HasColumnName("calculate_pos_by_bank");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.ContactPersonEmail)
                .HasMaxLength(155)
                .HasColumnName("contact_person_email");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(155)
                .HasColumnName("contact_person_name");
            entity.Property(e => e.ContactPersonPhone)
                .HasMaxLength(155)
                .HasColumnName("contact_person_phone");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("currency_id");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasColumnName("description");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasComment("Iks district")
                .HasColumnName("district");
            entity.Property(e => e.DplBillingFields)
                .HasMaxLength(2000)
                .HasDefaultValueSql("'{\"name\":{\"title\":\"Name\",\"enable\":\"1\",\"mendatory\":\"0\"},\"surname\":{\"title\":\"Surname\",\"enable\":\"1\",\"mendatory\":\"0\"},\"phone\":{\"title\":\"Phone\",\"enable\":\"1\",\"mendatory\":\"0\"},\"email\":{\"title\":\"Email\",\"enable\":\"1\",\"mendatory\":\"0\"},\"address\":{\"title\":\"Address\",\"enable\":\"1\",\"mendatory\":\"0\"}}'")
                .HasColumnName("dpl_billing_fields");
            entity.Property(e => e.DplFirsttimeLimt).HasColumnName("dpl_firsttime_limt");
            entity.Property(e => e.DplOption)
                .HasDefaultValueSql("'1'")
                .HasComment("1=branded, 2=white Label")
                .HasColumnName("dpl_option");
            entity.Property(e => e.ExpectedVolume)
                .HasMaxLength(60)
                .HasColumnName("expected_volume");
            entity.Property(e => e.FailLink)
                .HasMaxLength(191)
                .HasColumnName("fail_link");
            entity.Property(e => e.FirstTransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("first_transaction_date");
            entity.Property(e => e.FullCompanyName)
                .HasMaxLength(100)
                .HasColumnName("full_company_name");
            entity.Property(e => e.Is3d)
                .HasComment("0=>not 3d user, 1=>3d user")
                .HasColumnName("is_3d");
            entity.Property(e => e.IsAllowB2cAutomation)
                .HasDefaultValueSql("'1'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_b2c_automation");
            entity.Property(e => e.IsAllowForeignCards)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed; 1=allowed")
                .HasColumnName("is_allow_foreign_cards");
            entity.Property(e => e.IsAllowPayBill)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_pay_bill");
            entity.Property(e => e.IsAllowWalletgate)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_allow_walletgate");
            entity.Property(e => e.IsBlock)
                .HasComment("0=not blocked, 1=blocked")
                .HasColumnName("is_block");
            entity.Property(e => e.IsDigitalContractAccept)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not accepted, 1= accepted")
                .HasColumnName("is_digital_contract_accept");
            entity.Property(e => e.IsIksVerified)
                .HasComment("0=Unverified, 1=Verified")
                .HasColumnName("is_iks_verified");
            entity.Property(e => e.IsManualPos3d)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = 2d, 1= 3D")
                .HasColumnName("is_manual_pos_3d");
            entity.Property(e => e.IsNewMerchant)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = old merchant, 1 = new merchant")
                .HasColumnName("is_new_merchant");
            entity.Property(e => e.IsReceivePaymentReceipt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_receive_payment_receipt");
            entity.Property(e => e.IsoCountryCode)
                .HasMaxLength(3)
                .HasColumnName("iso_country_code");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.LastSuccessfulTransactionDate)
                .HasComment("datetime of last successful transaction")
                .HasColumnType("datetime")
                .HasColumnName("last_successful_transaction_date");
            entity.Property(e => e.LastTransactionDate)
                .HasComment("merchant last transaction date")
                .HasColumnName("last_transaction_date");
            entity.Property(e => e.Latitude)
                .HasPrecision(11, 8)
                .HasColumnName("latitude");
            entity.Property(e => e.LicenseTag)
                .HasMaxLength(50)
                .HasComment("Iks license")
                .HasColumnName("license_tag");
            entity.Property(e => e.LinkedPfMerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("linked_pf_merchant_id");
            entity.Property(e => e.Logo)
                .HasMaxLength(191)
                .HasColumnName("logo");
            entity.Property(e => e.Longitude)
                .HasPrecision(11, 8)
                .HasColumnName("longitude");
            entity.Property(e => e.MainSellerFlag)
                .HasComment("0=Individual having no sub merchant,1=Main merchant having submerchants, 2=Submerchant")
                .HasColumnName("main_seller_flag");
            entity.Property(e => e.Mcc)
                .HasMaxLength(5)
                .HasColumnName("mcc");
            entity.Property(e => e.MerchantKey)
                .HasColumnType("text")
                .HasColumnName("merchant_key");
            entity.Property(e => e.MerchantSecret)
                .HasColumnType("text")
                .HasColumnName("merchant_secret");
            entity.Property(e => e.MerchantType).HasColumnName("merchant_type");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.NationalAddressCode)
                .HasMaxLength(10)
                .HasComment("national address code")
                .HasColumnName("national_address_code");
            entity.Property(e => e.Neighborhood)
                .HasMaxLength(50)
                .HasComment("area of district")
                .HasColumnName("neighborhood");
            entity.Property(e => e.ParentMerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("parent_merchant_id");
            entity.Property(e => e.PaymentIntegrationOption)
                .HasDefaultValueSql("'4'")
                .HasComment("0 => White Label 2D Only 1 => White Label 2D/3D, Allow User to Choose 2 => White Label 3D Only 4 => 2D/3D Branded Solution 8 => Redirected White Label")
                .HasColumnName("payment_integration_option");
            entity.Property(e => e.PaymentReceiptEmails)
                .HasMaxLength(255)
                .HasColumnName("payment_receipt_emails");
            entity.Property(e => e.PaymentReceiptEmailsLang)
                .HasMaxLength(2)
                .HasColumnName("payment_receipt_emails_lang");
            entity.Property(e => e.PspFlag)
                .HasComment("0=Regular Merchant, 1=Payment Facilitator Merchant")
                .HasColumnName("psp_flag");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasComment("tenant reject reason")
                .HasColumnName("reason");
            entity.Property(e => e.RemoteSubMerchantId)
                .HasMaxLength(50)
                .HasColumnName("remote_sub_merchant_id");
            entity.Property(e => e.RollingReserveAmount)
                .HasDefaultValueSql("'0.00'")
                .HasComment("It is % value")
                .HasColumnType("double(12,2)")
                .HasColumnName("rolling_reserve_amount");
            entity.Property(e => e.RollingReserveTimeLimit)
                .HasDefaultValueSql("'0'")
                .HasColumnName("rolling_reserve_time_limit");
            entity.Property(e => e.RollingStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("rolling_status");
            entity.Property(e => e.SalePlatform)
                .HasMaxLength(255)
                .HasColumnName("sale_platform");
            entity.Property(e => e.SendPfRecords)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = dont send, 1 = send")
                .HasColumnName("send_pf_records");
            entity.Property(e => e.SettlementType)
                .HasDefaultValueSql("'3'")
                .HasComment("1=> hours, 2 => days, 3 =>months, 4 => years")
                .HasColumnName("settlement_type");
            /*entity.Property(e => e.SipayAccountantEmail)
                .HasMaxLength(50)
                .HasColumnName("sipay_accountant_email");*/
            entity.Property(e => e.SiteUrl)
                .HasMaxLength(191)
                .HasColumnName("site_url");
            entity.Property(e => e.SourceId)
                .HasMaxLength(50)
                .HasColumnName("source_id");
            entity.Property(e => e.Status)
                .HasComment("0=>inactive;1=>active")
                .HasColumnName("status");
            entity.Property(e => e.SuccessLink)
                .HasMaxLength(191)
                .HasColumnName("success_link");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(100)
                .HasColumnName("tax_no");
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(150)
                .HasColumnName("tax_office");
            entity.Property(e => e.Tckn)
                .HasMaxLength(50)
                .HasColumnName("tckn");
            entity.Property(e => e.TenantApprovalStatus)
                .HasComment("0=>awaiting approval, 1=>approved, 2=>rejected")
                .HasColumnName("tenant_approval_status");
            entity.Property(e => e.TestMerchantKey)
                .HasColumnType("text")
                .HasColumnName("test_merchant_key");
            entity.Property(e => e.TestMerchantSecret)
                .HasColumnType("text")
                .HasColumnName("test_merchant_secret");
            entity.Property(e => e.TotalTransaction)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_transaction");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>GENERAL_MERCHANT, 1=>OWN_TEST_MERCHANT, 2=>CRAFTGATE_MERCHANT, 3=>DEPOSIT_BY_CREDIT_CARD_PF_MERCHANT, 4=>TEST_PAYMENT_INTEGRATION_MERCHANT, 5=>MARKETPLACE_MERCHANT, 6=>OXIVO_MERCHANT, 7=>WALLET_GATE_MERCHANT, 8=>FASTPAY_WALLET_MERCHANT, 9=>TAXI_MERCHANT, 10=>PAVO_MERCHANT, 11=>API_MERCHANT, 12=>MT_MERCHANT, 13=>BILL_PAYMENT_MERCHANT, 14=>TENANT_MERCHANT")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Vkn)
                .HasMaxLength(50)
                .HasColumnName("vkn");
            entity.Property(e => e.WetSignedDocumentApprovalDate)
                .HasComment("for wet signed document approval date")
                .HasColumnType("datetime")
                .HasColumnName("wet_signed_document_approval_date");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<MerchantAgreement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_agreement")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_user_id");
            entity.Property(e => e.EnBody)
                .HasColumnName("en_body")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.EnSubject)
                .HasMaxLength(200)
                .HasColumnName("en_subject")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive")
                .HasColumnName("status");
            entity.Property(e => e.TrBody)
                .HasColumnName("tr_body")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.TrSubject)
                .HasMaxLength(200)
                .HasColumnName("tr_subject")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedByUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_user_id");
        });

        modelBuilder.Entity<MerchantAgreementHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_agreement_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptedByUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("accepted_by_user_id");
            entity.Property(e => e.AcceptedByUserName)
                .HasMaxLength(70)
                .HasColumnName("accepted_by_user_name");
            entity.Property(e => e.AcceptedRejectedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("accepted_rejected_datetime");
            entity.Property(e => e.ApprovedSource)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = uploaded and approved by merchant, 1 = approved physically  by admin")
                .HasColumnName("approved_source");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasComment("file path of physically approved agreement")
                .HasColumnName("file_path");
            entity.Property(e => e.MerchantAgreementId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_agreement_id");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantAllocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_allocations")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantAnnouncement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_announcements")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.MerchantId, e.UserId }, "merchant_id_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnnouncementId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("announcement_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("merchant_applications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasComment("Merchant Address")
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.ApplicationDate)
                .HasMaxLength(40)
                .HasColumnName("application_date");
            entity.Property(e => e.AssignedUserId)
                .HasComment("assigned admin user id")
                .HasColumnName("assigned_user_id");
            entity.Property(e => e.AuthPersonEmail)
                .HasMaxLength(60)
                .HasComment("Merchant Auth Person Email")
                .HasColumnName("auth_person_email");
            entity.Property(e => e.AuthPersonName)
                .HasMaxLength(40)
                .HasComment("Merchant Auth person name")
                .HasColumnName("auth_person_name");
            entity.Property(e => e.AuthPersonPhone)
                .HasMaxLength(20)
                .HasComment("Merchant Auth person phone")
                .HasColumnName("auth_person_phone");
            entity.Property(e => e.AuthenticationToken)
                .HasMaxLength(200)
                .HasComment("Merchant Application Authentication Token")
                .HasColumnName("authentication_token");
            entity.Property(e => e.AverageMonthlyEarning)
                .HasDefaultValueSql("'0.00'")
                .HasComment("Double/Integer")
                .HasColumnType("double(8,2)")
                .HasColumnName("average_monthly_earning");
            entity.Property(e => e.BusinessArea)
                .HasMaxLength(50)
                .HasColumnName("business_area");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .HasComment("Name of the company")
                .HasColumnName("company_name");
            entity.Property(e => e.ContractPersonEmail)
                .HasMaxLength(60)
                .HasColumnName("contract_person_email");
            entity.Property(e => e.ContractPersonName)
                .HasMaxLength(40)
                .HasColumnName("contract_person_name");
            entity.Property(e => e.ContractPersonPhone)
                .HasMaxLength(40)
                .HasColumnName("contract_person_phone");
            entity.Property(e => e.Country)
                .HasMaxLength(40)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasComment("Like TRY, EUR, USD, RUB. GBP, AZN")
                .HasColumnName("currency_code");
            entity.Property(e => e.Document)
                .HasColumnType("text")
                .HasColumnName("document");
            entity.Property(e => e.ExpectedVolume)
                .HasMaxLength(60)
                .HasColumnName("expected_volume");
            entity.Property(e => e.IsEmailVerified)
                .HasDefaultValueSql("'0'")
                .HasComment("email_verified = 1, email_not_verified =0")
                .HasColumnName("is_email_verified");
            entity.Property(e => e.IsPasswordExists)
                .HasDefaultValueSql("'0'")
                .HasComment("password_exists => 1,password_not_exists => 0 ")
                .HasColumnName("is_password_exists");
            entity.Property(e => e.LoginFailedAttempts)
                .HasComment("merchant application user login failed attempts counter")
                .HasColumnName("login_failed_attempts");
            entity.Property(e => e.Mcc)
                .HasMaxLength(5)
                .HasColumnName("mcc")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.MerchantLogo)
                .HasMaxLength(255)
                .HasColumnName("merchant_logo");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(50)
                .HasComment("Name of the merchant")
                .HasColumnName("merchant_name");
            entity.Property(e => e.MerchantType)
                .HasComment("1 ='Corporate',2 ='Individual'")
                .HasColumnName("merchant_type");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Merchant Name")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasComment("Hash Password")
                .HasColumnName("password");
            entity.Property(e => e.PreferredPaymentMethod)
                .HasMaxLength(40)
                .HasColumnName("preferred_payment_method");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.SocialMedia)
                .HasComment("Social media links")
                .HasColumnType("text")
                .HasColumnName("social_media")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'0'")
                .HasComment("1 = Normal Application, 2 = OnBoarding Merchant Application, 3 = Sales Panel Application")
                .HasColumnName("source");
            entity.Property(e => e.Stage)
                .HasComment("0 = Waiting For Documentation, 1 = Completed, 2 = waiting at operation")
                .HasColumnName("stage");
            entity.Property(e => e.Status)
                .HasComment("0=pending, 1=approved,2=reject")
                .HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasComment("Merchant Surname")
                .HasColumnName("surname");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(40)
                .HasColumnName("tax_number");
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(40)
                .HasColumnName("tax_office");
            entity.Property(e => e.TenantAppId)
                .HasMaxLength(100)
                .HasComment("tenant app key")
                .HasColumnName("tenant_app_id");
            entity.Property(e => e.TenantAppSecret)
                .HasMaxLength(100)
                .HasComment("tenant app secret")
                .HasColumnName("tenant_app_secret");
            entity.Property(e => e.TenantAppUrl)
                .HasMaxLength(150)
                .HasComment("tenant app url")
                .HasColumnName("tenant_app_url");
            entity.Property(e => e.TenantMerchantId)
                .HasComment("merchant id of tenant")
                .HasColumnName("tenant_merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Website)
                .HasMaxLength(60)
                .HasComment("Merchant webside url")
                .HasColumnName("website");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(30)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<MerchantApplicationAssignmentSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_application_assignment_schedules")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.From)
                .HasColumnType("datetime")
                .HasColumnName("from");
            entity.Property(e => e.MerchantApplicationId)
                .HasComment("merchant application primary id")
                .HasColumnName("merchant_application_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Status)
                .HasComment("0 => pending , 1 => approved , 2 => rejected")
                .HasColumnName("status");
            entity.Property(e => e.To)
                .HasColumnType("datetime")
                .HasColumnName("to");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasComment("saler expert user id")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantApplicationComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_application_comments")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId)
                .HasComment("merchant_applications table primary id")
                .HasColumnName("application_id");
            entity.Property(e => e.Comment)
                .HasComment("merchant application users comment")
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasComment("users id of sales admin and sales expert ")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantApplicationConversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_application_conversations")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasColumnType("text")
                .HasColumnName("answer");
            entity.Property(e => e.ApplicationId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("application_id");
            entity.Property(e => e.CommentUserId).HasColumnName("comment_user_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.QuestionId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("question_id");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantApplicationQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_application_questions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.QuestionTitle)
                .HasColumnType("text")
                .HasColumnName("question_title");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'0'")
                .HasComment("ENT = 1, Blocllist = 2, Applications = 3, Error = 4, Operation = 5 ")
                .HasColumnName("type");
        });

        modelBuilder.Entity<MerchantAutomaticReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_automatic_reports")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DatePeriod)
                .HasMaxLength(4)
                .HasColumnName("date_period");
            entity.Property(e => e.DayName)
                .HasMaxLength(50)
                .HasColumnName("day_name");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PaymentRecOptionId).HasColumnName("payment_rec_option_id");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
        });

        modelBuilder.Entity<MerchantAutomaticWithdrawalSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_automatic_withdrawal_settings")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.AutomaticWithdrawMerchantBankId).HasColumnName("automatic_withdraw_merchant_bank_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.ProcessDate)
                .HasColumnType("datetime")
                .HasColumnName("process_date");
            entity.Property(e => e.SettlementType)
                .HasMaxLength(10)
                .HasDefaultValueSql("'Daily'")
                .HasColumnName("settlement_type");
            entity.Property(e => e.SettlementValue)
                .HasMaxLength(20)
                .HasColumnName("settlement_value");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=automatic, 0=no")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantB2bSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_b2b_settings")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_amount");
            entity.Property(e => e.CommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Max)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Min)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("min");
            entity.Property(e => e.ReceiverCommissionAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("receiver_commission_amount");
            entity.Property(e => e.ReceiverCommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("receiver_commission_percentage");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantB2cSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_b2c_settings")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Max)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Min)
                .HasColumnType("double(12,4)")
                .HasColumnName("min");
            entity.Property(e => e.ReceiverCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("receiver_commission_fixed");
            entity.Property(e => e.ReceiverCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("receiver_commission_percentage");
            entity.Property(e => e.SenderCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sender_commission_fixed");
            entity.Property(e => e.SenderCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sender_commission_percentage");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1->cashout to bank;2->cashout to wallet")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantBankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_bank_accounts")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(150)
                .HasColumnName("account_holder_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(50)
                .HasColumnName("account_no")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BankName)
                .HasMaxLength(150)
                .HasColumnName("bank_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BranchCode)
                .HasMaxLength(50)
                .HasColumnName("branch_code")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BranchName)
                .HasMaxLength(150)
                .HasColumnName("branch_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.StaticBankId)
                .HasComment("primary key of banks table")
                .HasColumnName("static_bank_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SwiftCode)
                .HasMaxLength(50)
                .HasColumnName("swift_code")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantBankCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_bank_commissions")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_fixed");
            entity.Property(e => e.CommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Max)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max");
            entity.Property(e => e.MerchantBankAccountsId).HasColumnName("merchant_bank_accounts_id");
            entity.Property(e => e.Min)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("min");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantCardBlacklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_card_blacklist")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardType)
                .HasDefaultValueSql("'1'")
                .HasColumnName("card_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FromStartWith).HasColumnName("from_start_with");
            entity.Property(e => e.MerchantId)
                .HasComment("'1=visa, 2=mastercard, 3=amex, 4=diners, 5=discover, 6=jcb, 7=any'")
                .HasColumnName("merchant_id");
            entity.Property(e => e.ToStartWith)
                .HasDefaultValueSql("'0'")
                .HasColumnName("to_start_with");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_configurations")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .HasComment("Events:\r\nduplicate_invoice,\r\nimmediate_refund, ignore_sale_alert")
                .HasColumnName("event_name")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.MerchantIds)
                .HasComment("merchant_ids allowed for particular event")
                .HasColumnType("text")
                .HasColumnName("merchant_ids");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantCustomizedCost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_customized_costs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("cost to be deducted")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasComment("currency Id")
                .HasColumnName("currency_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasComment("description of the cost")
                .HasColumnName("description");
            entity.Property(e => e.MerchantId)
                .HasComment(" Merchant Id")
                .HasColumnName("merchant_id");
            entity.Property(e => e.NextActionDate)
                .HasComment("Next run date")
                .HasColumnType("datetime")
                .HasColumnName("next_action_date");
            entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=inactive, 1= active; default 1")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasComment("merchant auth user id")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantCustomizedCostSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_customized_cost_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasComment("currency Id")
                .HasColumnName("currency_id");
            entity.Property(e => e.FromBankId)
                .HasComment("bank id for approve")
                .HasColumnName("from_bank_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment(" Receiver name")
                .HasColumnName("name");
            entity.Property(e => e.ReceiverGsm)
                .HasMaxLength(50)
                .HasComment("gsm for Receiver ")
                .HasColumnName("receiver_gsm");
            entity.Property(e => e.ReceiverIban)
                .HasMaxLength(50)
                .HasComment("iban  for Receiver ")
                .HasColumnName("receiver_iban");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = b2c cashout process , 2 = process imported withdrawal ")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_documents")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.File1Comments)
                .HasMaxLength(255)
                .HasColumnName("file_1_comments");
            entity.Property(e => e.File1Path)
                .HasMaxLength(255)
                .HasColumnName("file_1_path");
            entity.Property(e => e.File1Status)
                .HasComment("0=>missing;1=>approved;2=>rejected")
                .HasColumnName("file_1_status");
            entity.Property(e => e.File2Comments)
                .HasMaxLength(255)
                .HasColumnName("file_2_comments");
            entity.Property(e => e.File2Path)
                .HasMaxLength(255)
                .HasColumnName("file_2_path");
            entity.Property(e => e.File2Status)
                .HasComment("0=>missing;1=>approved;2=>rejected")
                .HasColumnName("file_2_status");
            entity.Property(e => e.File3Comments)
                .HasMaxLength(255)
                .HasColumnName("file_3_comments");
            entity.Property(e => e.File3Path)
                .HasMaxLength(255)
                .HasColumnName("file_3_path");
            entity.Property(e => e.File3Status)
                .HasComment("0=>missing;1=>approved;2=>rejected")
                .HasColumnName("file_3_status");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.OtherFile1Comments)
                .HasMaxLength(255)
                .HasColumnName("other_file_1_comments");
            entity.Property(e => e.OtherFile1Path)
                .HasMaxLength(255)
                .HasColumnName("other_file_1_path");
            entity.Property(e => e.OtherFile1Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0=missing, 1=approved, 2=rejected")
                .HasColumnName("other_file_1_status");
            entity.Property(e => e.OtherFile2Comments)
                .HasMaxLength(255)
                .HasColumnName("other_file_2_comments");
            entity.Property(e => e.OtherFile2Path)
                .HasMaxLength(255)
                .HasColumnName("other_file_2_path");
            entity.Property(e => e.OtherFile2Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0=missing, 1=approved, 2=rejected")
                .HasColumnName("other_file_2_status");
            entity.Property(e => e.OtherFile3Comments)
                .HasMaxLength(255)
                .HasColumnName("other_file_3_comments");
            entity.Property(e => e.OtherFile3Path)
                .HasMaxLength(255)
                .HasColumnName("other_file_3_path");
            entity.Property(e => e.OtherFile3Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0=missing, 1=approved, 2=rejected")
                .HasColumnName("other_file_3_status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantEmailReceiver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_email_receivers")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountStatementReceipt)
                .HasColumnType("text")
                .HasColumnName("account_statement_receipt");
            entity.Property(e => e.Announcement)
                .HasColumnType("text")
                .HasColumnName("announcement");
            entity.Property(e => e.AvailableBalanceUpdate)
                .HasColumnType("text")
                .HasColumnName("available_balance_update");
            entity.Property(e => e.CashoutToBankEmail)
                .HasColumnType("text")
                .HasColumnName("cashout_to_bank_email");
            entity.Property(e => e.CashoutToWalletGateEmail)
                .HasColumnType("text")
                .HasColumnName("cashout_to_wallet_gate_email");
            entity.Property(e => e.ChargebackRequestInfo)
                .HasColumnType("text")
                .HasColumnName("chargeback_request_info");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DepositNotification)
                .HasColumnType("text")
                .HasColumnName("deposit_notification");
            entity.Property(e => e.FailedTransactionsInfo)
                .HasColumnType("text")
                .HasColumnName("failed_transactions_info");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MpFailedUser)
                .HasDefaultValueSql("'1'")
                .HasColumnName("mp_failed_user");
            entity.Property(e => e.MpSuccessAuthUser)
                .HasColumnType("text")
                .HasColumnName("mp_success_auth_user");
            entity.Property(e => e.MpSuccessUser)
                .HasDefaultValueSql("'1'")
                .HasColumnName("mp_success_user");
            entity.Property(e => e.PaymentLinkFailedUser)
                .HasDefaultValueSql("'1'")
                .HasColumnName("payment_link_failed_user");
            entity.Property(e => e.PaymentLinkSuccessAuthUser)
                .HasColumnType("text")
                .HasColumnName("payment_link_success_auth_user");
            entity.Property(e => e.PaymentLinkSuccessUser)
                .HasDefaultValueSql("'1'")
                .HasColumnName("payment_link_success_user");
            entity.Property(e => e.RefundNotification)
                .HasColumnType("text")
                .HasColumnName("refund_notification");
            entity.Property(e => e.SupportTicketNotificationEmail)
                .HasColumnType("text")
                .HasColumnName("support_ticket_notification_email");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteIntegrationFailedUser)
                .HasDefaultValueSql("'1'")
                .HasColumnName("website_integration_failed_user");
            entity.Property(e => e.WebsiteIntegrationSuccessAuthUser)
                .HasColumnType("text")
                .HasColumnName("website_integration_success_auth_user");
            entity.Property(e => e.WebsiteIntegrationSuccessUser)
                .HasDefaultValueSql("'1'")
                .HasColumnName("website_integration_success_user");
            entity.Property(e => e.WithdrawalNotification)
                .HasColumnType("text")
                .HasColumnName("withdrawal_notification");
            entity.Property(e => e.WithdrawalSuccessfulEmail)
                .HasColumnType("text")
                .HasColumnName("withdrawal_successful_email")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<MerchantFraud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_frauds")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.FilterType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("filter_type");
            entity.Property(e => e.MaxAmount)
                .HasColumnType("double(12,2)")
                .HasColumnName("max_amount");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MinAmount)
                .HasColumnType("double(12,2)")
                .HasColumnName("min_amount");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=passive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.XValue)
                .HasColumnType("double(12,2)")
                .HasColumnName("x_value");
            entity.Property(e => e.YValue)
                .HasColumnType("double(12,2)")
                .HasColumnName("y_value");
            entity.Property(e => e.ZValue)
                .HasColumnType("double(12,2)")
                .HasColumnName("z_value");
        });

        modelBuilder.Entity<MerchantFtpInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_ftp_infos")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Host)
                .HasMaxLength(50)
                .HasComment("merchant ftp host info")
                .HasColumnName("host");
            entity.Property(e => e.MerchantId)
                .HasComment("merchant primary id")
                .HasColumnName("merchant_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasComment("merchant ftp password info")
                .HasColumnName("password");
            entity.Property(e => e.Port)
                .HasMaxLength(50)
                .HasComment("merchant ftp port info")
                .HasColumnName("port");
            entity.Property(e => e.RootPath)
                .HasMaxLength(50)
                .HasComment("merchant ftp root path info")
                .HasColumnName("root_path");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Daily account Statement")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasComment("merchant ftp username info")
                .HasColumnName("username");
        });

        modelBuilder.Entity<MerchantIk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_iks")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityType)
                .HasDefaultValueSql("'2'")
                .HasComment("0=> terminated, 1 active but not with us, 2=> both active")
                .HasColumnName("activity_type");
            entity.Property(e => e.AdditionalInfo)
                .HasComment("additional response in json")
                .HasColumnType("text")
                .HasColumnName("additional_info");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.AgreementDate)
                .HasComment("merchant activation date")
                .HasColumnName("agreement_date");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("short coed of termination")
                .HasColumnName("code");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .HasComment("Iso Country Code")
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.District)
                .HasMaxLength(20)
                .HasColumnName("district");
            entity.Property(e => e.Explanation)
                .HasMaxLength(50)
                .HasComment("Explanation  for terminated")
                .HasColumnName("explanation");
            entity.Property(e => e.Geocodeinfo)
                .HasComment("geographical location in json")
                .HasColumnType("text")
                .HasColumnName("geocodeinfo");
            entity.Property(e => e.GlobalMerchantId)
                .HasComment("Global Merchant Id from api")
                .HasColumnName("global_merchant_id");
            entity.Property(e => e.InformType)
                .HasDefaultValueSql("'8'")
                .HasComment("(9=> merchant terminated, 8=>merchant termination reversed")
                .HasColumnName("inform_type");
            entity.Property(e => e.Latitude)
                .HasMaxLength(9)
                .HasColumnName("latitude");
            entity.Property(e => e.LicenseTag)
                .HasComment("license plate code")
                .HasColumnName("license_tag");
            entity.Property(e => e.Longitude)
                .HasMaxLength(9)
                .HasColumnName("longitude");
            entity.Property(e => e.MainSellerFlag)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>individual, 1=>have sub merchants, 2=> submerchant")
                .HasColumnName("main_seller_flag");
            entity.Property(e => e.MainSellerTaxNo)
                .HasMaxLength(11)
                .HasComment("Main dealer TC Identity")
                .HasColumnName("main_seller_tax_no");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(25)
                .HasComment("Authorized Person Name")
                .HasColumnName("manager_name");
            entity.Property(e => e.Mcc)
                .HasComment("Workplace Category Code")
                .HasColumnName("mcc");
            entity.Property(e => e.MerchantId)
                .HasComment("merchant table primary key")
                .HasColumnName("merchant_id");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(30)
                .HasComment("merchant name on IKS")
                .HasColumnName("merchant_name");
            entity.Property(e => e.NationalAddressCode)
                .HasMaxLength(10)
                .HasComment(" national address database (UAVT) code")
                .HasColumnName("national_address_code");
            entity.Property(e => e.Neighberhood)
                .HasMaxLength(20)
                .HasComment("area of district")
                .HasColumnName("neighberhood");
            entity.Property(e => e.OwnerIdentityNo)
                .HasMaxLength(50)
                .HasComment("Merchant TCKN")
                .HasColumnName("owner_identity_no");
            entity.Property(e => e.Partner2IdentityNo)
                .HasMaxLength(50)
                .HasComment("multiple partners of company")
                .HasColumnName("partner_2_identity_no");
            entity.Property(e => e.Partner3IdentityNo)
                .HasMaxLength(50)
                .HasComment("multiple partners of company")
                .HasColumnName("partner_3_identity_no");
            entity.Property(e => e.Partner4IdentityNo)
                .HasMaxLength(50)
                .HasComment("multiple partners of company")
                .HasColumnName("partner_4_identity_no");
            entity.Property(e => e.Partner5IdentityNo)
                .HasMaxLength(50)
                .HasComment("multiple partners of company")
                .HasColumnName("partner_5_identity_no");
            entity.Property(e => e.PersonnelName)
                .HasMaxLength(50)
                .HasComment("Personnel name  for terminated")
                .HasColumnName("personnel_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasComment("merchant phone")
                .HasColumnName("phone");
            entity.Property(e => e.PspFlag)
                .HasDefaultValueSql("'0'")
                .HasComment("1=>pf provider, 0=>not pf provider")
                .HasColumnName("psp_flag");
            entity.Property(e => e.PspMerchantId)
                .HasComment("Merchant ID")
                .HasColumnName("psp_merchant_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>active, 2=>invalid, 3=>terminated")
                .HasColumnName("status");
            entity.Property(e => e.StatusCode)
                .HasComment("status on iks: 0=>Iks open, 1=>Iks closed")
                .HasColumnName("status_code");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(11)
                .HasComment("Merchant VKN info")
                .HasColumnName("tax_no");
            entity.Property(e => e.TerminationDate)
                .HasComment("Termination Date")
                .HasColumnName("termination_date");
            entity.Property(e => e.TradeName)
                .HasMaxLength(30)
                .HasComment("Full Company Name")
                .HasColumnName("trade_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantIksTerminal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_iks_terminals")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(50)
                .HasColumnName("brand_code");
            entity.Property(e => e.BrandSharing)
                .HasMaxLength(50)
                .HasColumnName("brand_sharing");
            entity.Property(e => e.ConnectionType)
                .HasMaxLength(50)
                .HasColumnName("connection_type");
            entity.Property(e => e.ContactLess)
                .HasMaxLength(50)
                .HasColumnName("contact_less");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.GlobalMerchantId).HasColumnName("global_merchant_id");
            entity.Property(e => e.HostingTaxNo)
                .HasMaxLength(11)
                .HasColumnName("hosting_tax_no");
            entity.Property(e => e.HostingTradeName)
                .HasMaxLength(30)
                .HasColumnName("hosting_trade_name");
            entity.Property(e => e.HostingUrl)
                .HasMaxLength(150)
                .HasColumnName("hosting_url");
            entity.Property(e => e.MerchantIksId).HasColumnName("merchant_iks_id");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.OwnerPspNo).HasColumnName("owner_psp_no");
            entity.Property(e => e.OwnerTerminalId)
                .HasMaxLength(50)
                .HasColumnName("owner_terminal_id");
            entity.Property(e => e.PaymentGwTaxNo)
                .HasMaxLength(11)
                .HasColumnName("payment_gw_tax_no");
            entity.Property(e => e.PaymentGwTradeName)
                .HasMaxLength(30)
                .HasColumnName("payment_gw_trade_name");
            entity.Property(e => e.PaymentGwUrl)
                .HasMaxLength(150)
                .HasColumnName("payment_gw_url");
            entity.Property(e => e.PinPad)
                .HasMaxLength(50)
                .HasColumnName("pin_pad");
            entity.Property(e => e.PspMerchantId).HasColumnName("psp_merchant_id");
            entity.Property(e => e.SerialNo)
                .HasMaxLength(50)
                .HasColumnName("serial_no");
            entity.Property(e => e.ServiceProviderPspNo).HasColumnName("service_provider_psp_no");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(50)
                .HasColumnName("status_code");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(50)
                .HasColumnName("terminal_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VirtualPosUrl)
                .HasMaxLength(150)
                .HasColumnName("virtual_pos_url");
        });

        modelBuilder.Entity<MerchantIntegrator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_integrators")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_fixed");
            entity.Property(e => e.CommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IntegratorId).HasColumnName("integrator_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantIntegratorInstallmentCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_integrator_installment_commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.InstallmentNumber).HasColumnName("installment_number");
            entity.Property(e => e.IntegratorCommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("integrator_commission_fixed");
            entity.Property(e => e.IntegratorCommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("integrator_commission_percentage");
            entity.Property(e => e.IntegratorId).HasColumnName("integrator_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = Inactive, 1 = Active ")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<MerchantIpAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_ip_assaignments")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedIp)
                .HasMaxLength(255)
                .HasColumnName("assigned_ip");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Limit).HasColumnName("limit");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.TransactionCount).HasColumnName("transaction_count");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("Sale => 1 , Cashout => 2, 3 = Wallet UnitOfWork")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.ValidateDate).HasColumnName("validate_date")
                 .HasColumnType("date")
                 .HasDefaultValueSql(null);
            entity.Property(e => e.IpBlockType)
                .HasColumnType("tinyint")
                .HasDefaultValueSql("'1'")
                .HasComment("1 = whitelist, 2 = blocklist")
                .HasColumnName("ip_block_type");
            entity.Property(e => e.IpSourceType)
                .HasColumnType("tinyint")
                .HasDefaultValueSql("'1'")
                .HasComment("1 = merchant, 2 = user")
                .HasColumnName("ip_source_type");

        });

        modelBuilder.Entity<MerchantNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_notes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => new { e.ParentId, e.MerchantId }, "parent_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(191)
                .HasColumnName("created_by_name")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => close , 1 => open")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(120)
                .HasColumnName("title")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedByName)
                .HasMaxLength(191)
                .HasColumnName("updated_by_name");
        });

        modelBuilder.Entity<MerchantOnboardingApiSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_onboarding_api_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => new { e.IntegratorId, e.HashkeyPassword }, "integrator_id").IsUnique();

            entity.HasIndex(e => e.SourceName, "source_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllMandatoryDocs)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => not skipped , 1 => skipped")
                .HasColumnName("all_mandatory_docs");
            entity.Property(e => e.CalculatePosByBank)
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("calculate_pos_by_bank");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasComment("by default it will be system default currency id")
                .HasColumnName("currency_id");
            entity.Property(e => e.DplOption)
                .HasDefaultValueSql("'2'")
                .HasComment("1=branded, 2 = white label")
                .HasColumnName("dpl_option");
            entity.Property(e => e.DplPosOption)
                .HasDefaultValueSql("'1'")
                .HasComment("0=2d, 1=3D, 2=Allow 2D And 3D")
                .HasColumnName("dpl_pos_option");
            entity.Property(e => e.HashkeyPassword)
                .HasMaxLength(64)
                .HasComment("random 64 char+digit")
                .HasColumnName("hashkey_password")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IntegratorId)
                .HasComment("merchant integrator id from existing list")
                .HasColumnName("integrator_id");
            entity.Property(e => e.Is3d)
                .HasDefaultValueSql("'1'")
                .HasComment("0 =? now 3d user, 1 => 3d user")
                .HasColumnName("is_3d");
            entity.Property(e => e.IsAllowB2cAutomation)
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_b2c_automation");
            entity.Property(e => e.IsAllowB2cToWalletgate)
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_b2c_to_walletgate");
            entity.Property(e => e.IsAllowDpl)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_dpl");
            entity.Property(e => e.IsAllowForeignCards)
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_foreign_cards");
            entity.Property(e => e.IsAllowManualPos)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_manual_pos");
            entity.Property(e => e.IsAllowOnePagePayment)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_one_page_payment");
            entity.Property(e => e.IsAllowPayByToken)
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_pay_by_token");
            entity.Property(e => e.IsAllowPreauthTransaction)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_preauth_transaction");
            entity.Property(e => e.IsAllowRecurringPayment)
                .HasComment("0 => not allowed, 1 => allowed")
                .HasColumnName("is_allow_recurring_payment");
            entity.Property(e => e.ManualPosOption)
                .HasDefaultValueSql("'1'")
                .HasComment("0=2d, 1=3D, 2=Allow 2D And 3D")
                .HasColumnName("manual_pos_option");
            entity.Property(e => e.MaxDailyCreation)
                .HasDefaultValueSql("'4'")
                .HasComment("max number of merchants  can be  created daily  from a single source")
                .HasColumnName("max_daily_creation");
            entity.Property(e => e.MerchantBlockAmount)
                .HasComment("same amount as pos_transaction_limit amount")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_block_amount");
            entity.Property(e => e.MerchantStatus)
                .HasComment("0 => inactive 1 => active")
                .HasColumnName("merchant_status");
            entity.Property(e => e.OtpRequiredToLogin)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => no , 1 => yes")
                .HasColumnName("otp_required_to_login");
            entity.Property(e => e.PaymentIntegrationOption)
                .HasDefaultValueSql("'2'")
                .HasComment("0 => White Label 2D Only 1 => White Label 2D/3D, Allow User to Choose 2 => White Label 3D Only 4 => 2D/3D Branded Solution 8 => Redirected White Label")
                .HasColumnName("payment_integration_option");
            entity.Property(e => e.PaymentMethods)
                .HasComment("1 => credit card , 2 => mobile payment , 3=> wallet")
                .HasColumnName("payment_methods");
            entity.Property(e => e.PosTransactionLimit)
                .HasComment("for stopping merchant use any balance before thay confirmed")
                .HasColumnType("double(12,4)")
                .HasColumnName("pos_transaction_limit");
            entity.Property(e => e.SettlementType)
                .HasDefaultValueSql("'1'")
                .HasComment(" 1=> daily, 2 => weekly friday, 3 =>monthly, 11 => Weekly Wednesday , 18 => End of the Month")
                .HasColumnName("settlement_type");
            entity.Property(e => e.SourceId)
                .HasMaxLength(50)
                .HasComment("random string for source")
                .HasColumnName("source_id");
            entity.Property(e => e.SourceName)
                .HasMaxLength(100)
                .HasComment("Understand that source ID is created for Merchant Name(like TestMerchantSipay)")
                .HasColumnName("source_name")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantOnboardingPosSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_onboarding_pos_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_fixed");
            entity.Property(e => e.CommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EndUserCommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_fixed");
            entity.Property(e => e.EndUserCommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_percentage");
            entity.Property(e => e.IsAllowForeignCard)
                .HasComment("0 => inactive , 1 => active")
                .HasColumnName("is_allow_foreign_card");
            entity.Property(e => e.MerchantOnboardingApiSettingsId).HasColumnName("merchant_onboarding_api_settings_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantOperationCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_operation_commissions")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_fixed");
            entity.Property(e => e.CommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Max)
                .HasColumnType("double(12,4)")
                .HasColumnName("max");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Min)
                .HasColumnType("double(12,4)")
                .HasColumnName("min");
            entity.Property(e => e.Type)
                .HasComment("1:withdrawal, 2:deposit-eft")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantOutgoingReportSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_outgoing_report_schedules")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasComment("Auth id who created it ")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Credentials)
                .HasComment("Information about destination type like email,ftp, dropbox")
                .HasColumnType("text")
                .HasColumnName("credentials");
            entity.Property(e => e.DestinationType)
                .HasComment("1=ftp,2=dropbox,3=email")
                .HasColumnName("destination_type");
            entity.Property(e => e.MerchantId)
                .HasComment("id from merchant table")
                .HasColumnName("merchant_id");
            entity.Property(e => e.NextEffectiveDate)
                .HasComment("when the report should be exported")
                .HasColumnType("datetime")
                .HasColumnName("next_effective_date");
            entity.Property(e => e.ReportType)
                .HasComment("1=Migros")
                .HasColumnName("report_type");
            entity.Property(e => e.SettlementId)
                .HasComment("id from settlement table, it can be daily , monthly etc")
                .HasColumnName("settlement_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasComment("Auth id who updated the existing data")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<MerchantPaybillOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_paybill_options")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MerchantId, "merchant_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PaybillOptionId).HasColumnName("paybill_option_id");
        });

        modelBuilder.Entity<MerchantPaymentRecOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_payment_rec_options")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MerchantId, "merchant_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PaymentRecOptionId).HasColumnName("payment_rec_option_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantPosCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_pos_commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.MerchantId, e.PosId, e.InstallmentNumber }, "merchant_id_pos_id_installment_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComFixed)
                .HasPrecision(8, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("com_fixed");
            entity.Property(e => e.ComPercentage)
                .HasPrecision(8, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("com_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.EndUserComFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(8,4)")
                .HasColumnName("end_user_com_fixed");
            entity.Property(e => e.EndUserComPercentage)
                .HasColumnType("double(8,4)")
                .HasColumnName("end_user_com_percentage");
            entity.Property(e => e.InstallmentNumber).HasColumnName("installment_number");
            entity.Property(e => e.IsAllowForeignCard)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_allow_foreign_card");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<MerchantPosInstallmentSettlementSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_pos_installment_settlement_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.MerchantId, e.PosId, e.InstallmentsNumber }, "merchant_id_pos_id_installment_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.InstallmentsNumber)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = single installment, 1 = 1st payment of installment, others are regular installment number")
                .HasColumnName("installments_number");
            entity.Property(e => e.MerchantId)
                .HasMaxLength(50)
                .HasColumnName("merchant_id");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id");
            entity.Property(e => e.SettlementDay)
                .HasComment("The day installment amount will be settle to merchant wallet.For example 30. installment amount will be settle after 30 days from sale date")
                .HasColumnName("settlement_day");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive;1=>active;")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantPosPfSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("merchant_pos_pf_settings");

            entity.HasIndex(e => new { e.MerchantId, e.PosId }, "merchant_id_pos_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(100)
                .HasColumnName("created_by_name");
            entity.Property(e => e.IsSendTcknVkn)
                .HasDefaultValueSql("'1'")
                .HasComment("'1 = Send\\r\\n0 = Do not send\\r\\nFor some pos it determines whether we should send tckn vkn for some specific merchant';")
                .HasColumnName("is_send_tckn_vkn");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MigrationStatus)
                .HasComment("0 = Not From Migration;\r\n1 = From Migration")
                .HasColumnName("migration_status");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("( 1 = active, 0 = inactive) default 1")
                .HasColumnName("status");
            entity.Property(e => e.SubMerchantId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("sub_merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UpdatedByName)
                .HasMaxLength(100)
                .HasColumnName("updated_by_name");
        });

        modelBuilder.Entity<MerchantReportHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("merchant_report_histories");

            entity.HasIndex(e => new { e.ReportType, e.Status }, "report_type_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DownloadCount).HasColumnName("download_count");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(255)
                .HasColumnName("file_url");
            entity.Property(e => e.Format)
                .HasDefaultValueSql("'0'")
                .HasComment("(1=CSV, 2=XLS, 3=PDF) default 0")
                .HasColumnName("format");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Params)
                .HasColumnType("text")
                .HasColumnName("params");
            entity.Property(e => e.ReportType)
                .HasDefaultValueSql("'0'")
                .HasComment("(1=merchant: report transaction, 2=admin: account statement, 3=admin: all transaction, 4=merchant: all transaction, 5=merchant:  account statement, 6=admin: chargeBack, 7=Merchant: ChargeBack, 8=admin: Refunded, 9=merchant: Refunded, 10=Bank settlement Report) default 0")
                .HasColumnName("report_type");
            entity.Property(e => e.RequestAt)
                .HasColumnType("datetime")
                .HasColumnName("request_at");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'0'")
                .HasComment("0=request by human, 1= request by automation system")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("(0=Pending, 1=Processed, 2=Expired, 3=Awaiting, 9= Awaiting Big Data) default 0")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_sales")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.EffectiveDate, "effective_date");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CardType)
                .HasComment("1=> Credit Card, 2= Debit Card")
                .HasColumnName("card_type");
            entity.Property(e => e.ChargebackCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("chargeback_commission");
            entity.Property(e => e.ChargebackCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("chargeback_commission_fixed");
            entity.Property(e => e.CotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_fixed");
            entity.Property(e => e.CotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("timestamp")
                .HasColumnName("effective_date");
            entity.Property(e => e.EndUserCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_fixed");
            entity.Property(e => e.EndUserCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_percentage");
            entity.Property(e => e.IsPayByTokenRefundChecked)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>No Refund, 1=>Refund")
                .HasColumnName("is_pay_by_token_refund_checked");
            entity.Property(e => e.MerchantCommissionFixed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_commission_fixed");
            entity.Property(e => e.MerchantCommissionPercentage)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_commission_percentage");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantRollingPercentage).HasColumnName("merchant_rolling_percentage");
            entity.Property(e => e.NextEffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("next_effective_date");
            entity.Property(e => e.PayByTokenCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("pay_by_token_commission");
            entity.Property(e => e.PayByTokenFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("pay_by_token_fixed");
            entity.Property(e => e.RefundCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_commission");
            entity.Property(e => e.RefundCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_commission_fixed");
            entity.Property(e => e.RefundRequestAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_request_amount");
            entity.Property(e => e.ReportingSettlementDate)
                .HasColumnType("timestamp")
                .HasColumnName("reporting_settlement_date");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
            entity.Property(e => e.Status)
                .HasComment("0=>Awaiting, 1=>Processed")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantScheduleReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_schedule_reports")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("currency_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.LastExecutionDate)
                .HasColumnType("datetime")
                .HasColumnName("last_execution_date");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_id");
            entity.Property(e => e.NextSettlementDate)
                .HasColumnType("datetime")
                .HasColumnName("next_settlement_date");
            entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("(0=Pending, 1=Processed)")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("(1= Commision, 2= account Statement, 3= Admin Commission Zip)")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<MerchantSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.AppId, "app_id").IsUnique();

            entity.HasIndex(e => e.MerchantId, "merchant_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppId)
                .HasMaxLength(100)
                .HasColumnName("app_id");
            entity.Property(e => e.AppSecret)
                .HasMaxLength(100)
                .HasColumnName("app_secret");
            entity.Property(e => e.CommissionReceiptType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=> Monthly Commision Receipt, 2=>e-Invoice Merchant")
                .HasColumnName("commission_receipt_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreditCardStatus).HasColumnName("credit_card_status");
            entity.Property(e => e.DefaultDplLinkType)
                .HasDefaultValueSql("'1'")
                .HasComment("One Time DPL Link=1, Multi Time DPL Link=2, One Page DPL Link=3")
                .HasColumnName("default_dpl_link_type");
            entity.Property(e => e.DplPosOption)
                .HasDefaultValueSql("'1'")
                .HasComment("0=2d, 1=3D, 2=Allow 2D And 3D")
                .HasColumnName("dpl_pos_option");
            entity.Property(e => e.IsAllow2dCvvless)
                .HasComment("0 => not allow , 1 => allow")
                .HasColumnName("is_allow_2d_cvvless");
            entity.Property(e => e.IsAllow3dCvvless)
                .HasComment("0 => not allow , 1 => allow ")
                .HasColumnName("is_allow_3d_cvvless");
            entity.Property(e => e.IsAllowAutomaticFtpReport).HasColumnName("is_allow_automatic_ftp_report");
            entity.Property(e => e.IsAllowAvoidPendingPayment)
                .HasDefaultValueSql("'0'")
                .HasComment("Control to refund/cancel success payment from checOrderStatus/checkSpecialOrderStatus cronjob/queue unitOfWork\r\nValues: 0 : Not Allowed, 1 : Allowed ")
                .HasColumnName("is_allow_avoid_pending_payment");
            entity.Property(e => e.IsAllowBillPayment)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1=allow")
                .HasColumnName("is_allow_bill_payment");
            entity.Property(e => e.IsAllowCashoutRequest)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_cashout_request");
            entity.Property(e => e.IsAllowDcc)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not  allow,  1=allow")
                .HasColumnName("is_allow_dcc");
            entity.Property(e => e.IsAllowDpl)
                .HasDefaultValueSql("'1'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_dpl");
            entity.Property(e => e.IsAllowInsurancePayment)
                .HasDefaultValueSql("'0'")
                .HasComment("To check if merchant is allowed to do insurance payment\r\n0 = Not Allowed\r\n1 = Allowed")
                .HasColumnName("is_allow_insurance_payment");
            entity.Property(e => e.IsAllowManualPos)
                .HasDefaultValueSql("'1'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_manual_pos");
            entity.Property(e => e.IsAllowMt)
                .HasComment("0 = not allowed, 1 = allowed")
                .HasColumnName("is_allow_mt");
            entity.Property(e => e.IsAllowOnePagePayment)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_one_page_payment");
            entity.Property(e => e.IsAllowOxivo)
                .HasComment("0 = not allowed, 1 = allowed")
                .HasColumnName("is_allow_oxivo");
            entity.Property(e => e.IsAllowPavo)
                .HasComment("0 = not allowed, 1 = allowed")
                .HasColumnName("is_allow_pavo");
            entity.Property(e => e.IsAllowPreAuth)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1=allow")
                .HasColumnName("is_allow_pre_auth");
            entity.Property(e => e.IsAllowRecurringPayment)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_recurring_payment");
            entity.Property(e => e.IsAllowRussianBinToRuble)
                .HasDefaultValueSql("'0'")
                .HasComment("To check if merchant is allowed for currency conversion flow \r\n0 = Not Allowed\r\n1 = Allowed")
                .HasColumnName("is_allow_russian_bin_to_ruble");
            entity.Property(e => e.IsAllowSariTaxi)
                .HasComment("0=>not allowed, 1=>allowed")
                .HasColumnName("is_allow_sari_taxi");
            entity.Property(e => e.IsAllowTarim)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1= allowed")
                .HasColumnName("is_allow_tarim");
            entity.Property(e => e.IsAllowVirtualCard)
                .HasComment("0=not allowed, 1=allowed")
                .HasColumnName("is_allow_virtual_card");
            entity.Property(e => e.IsAllowWithdrawal)
                .HasComment("0=not allowed, 1=allowed")
                .HasColumnName("is_allow_withdrawal");
            entity.Property(e => e.IsAllowedHugin)
                .HasComment("0=>not allowed, 1=>allowed")
                .HasColumnName("is_allowed_hugin");
            entity.Property(e => e.IsCheckedDplAmountDecideByUser)
                .HasComment("0 => By Default ... Not Checked DPL Amount Decide By User, 1=> Auto Checked DPL Amount Decide By User, ")
                .HasColumnName("is_checked_dpl_amount_decide_by_user");
            entity.Property(e => e.IsCheckedDplTakeCommissionFromUser)
                .HasComment("0 => By Default ... Not Checked DPL Take Commission From User, 1 => Checked DPL Take Commission From User, ")
                .HasColumnName("is_checked_dpl_take_commission_from_user");
            entity.Property(e => e.IsEnableIpRestriction)
                .HasDefaultValueSql("'0'")
                .HasComment("1 = Enable IP Restriction,  0 = Disable IP Restriction")
                .HasColumnName("is_enable_ip_restriction");
            entity.Property(e => e.IsEnableWalletService)
                .HasComment("1 = enable, 0= disable")
                .HasColumnName("is_enable_wallet_service");
            entity.Property(e => e.IsExemptCardBlock)
                .HasComment("0 = not exempted (will check for block card cc); 1 = exempted (special merchant will not check the block card cc)")
                .HasColumnName("is_exempt_card_block");
            entity.Property(e => e.IsInstallmentWiseSettlement)
                .HasDefaultValueSql("'0'")
                .HasComment("To check if merchant is allowed for installment wise settlement\r\n0 : Not Allowed\r\n1 : Allowed")
                .HasColumnName("is_installment_wise_settlement");
            entity.Property(e => e.IsMasterCardAllow)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => not master card allow , 1 => master card allow ")
                .HasColumnName("is_master_card_allow");
            entity.Property(e => e.IsPhysicalPosAllow)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not allowed, 1=all")
                .HasColumnName("is_physical_pos_allow");
            entity.Property(e => e.IsReceiveBalanceUpdateEmail)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = do not send  1 = send email")
                .HasColumnName("is_receive_balance_update_email");
            entity.Property(e => e.IsShowInstallmentTable)
                .HasComment("0=>do not show, 1=> show")
                .HasColumnName("is_show_installment_table");
            entity.Property(e => e.IsTestMerchant)
                .HasComment("merchant for test purpose")
                .HasColumnName("is_test_merchant");
            entity.Property(e => e.IsVisaAllow)
                .HasDefaultValueSql("'1'")
                .HasComment("0 => not allow , 1 => allow ")
                .HasColumnName("is_visa_allow");
            entity.Property(e => e.ManualPosOptions)
                .HasDefaultValueSql("'1'")
                .HasComment("0=2d, 1=3D, 2=Allow 2D And 3D")
                .HasColumnName("manual_pos_options");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MinInstallmentNoOfBusinessCards).HasColumnName("min_installment_no_of_business_cards");
            entity.Property(e => e.MobilePaymentStatus).HasColumnName("mobile_payment_status");
            entity.Property(e => e.RecurringWebHook)
                .HasMaxLength(200)
                .HasColumnName("recurring_web_hook")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ReturnUrl)
                .HasMaxLength(200)
                .HasColumnName("return_url");
            entity.Property(e => e.SaleWebHook)
                .HasMaxLength(200)
                .HasColumnName("sale_web_hook")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SaveCardBankId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("save_card_bank_id");
            entity.Property(e => e.Timezone)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Europe/Istanbul'")
                .HasColumnName("timezone")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.WalletStatus).HasColumnName("wallet_status");
            entity.Property(e => e.WixMerchantId)
                .HasMaxLength(100)
                .HasColumnName("wix_merchant_id");
        });

        modelBuilder.Entity<MerchantSettingImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("merchant_setting_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ImageName)
                .HasMaxLength(192)
                .HasColumnName("image_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.MerchantSettingId).HasColumnName("merchant_setting_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantSocialLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_social_links")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.MerchantId, e.Media }, "merchant_id_media").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Media)
                .HasComment("FACEBOOK = 1,TWITTER = 2,INSTAGRAM = 3,LINKEDIN = 4,YOUTUBE = 5")
                .HasColumnName("media");
            entity.Property(e => e.MediaLink)
                .HasMaxLength(200)
                .HasComment("Social media link")
                .HasColumnName("media_link");
            entity.Property(e => e.MerchantId)
                .HasComment("merchant primary key(id)\r\n\r\n")
                .HasColumnName("merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantTerminal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_terminals")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => new { e.MerchantId, e.TerminalId }, "unique_index").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(2)
                .HasComment("IKS terminal Brand Code")
                .HasColumnName("brand_code")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.BrandSharing)
                .HasMaxLength(2)
                .HasComment("IKS  terminal Brand Sharing")
                .HasColumnName("brand_sharing")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.ConnectionType)
                .HasMaxLength(2)
                .HasComment("A: ADSL, D: Dial-Up, E: Ethernet, G: GPRS, I: ISDN, S: GSM, W: Wi-Fi;")
                .HasColumnName("connection_type")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.ContactLess)
                .HasDefaultValueSql("'0'")
                .HasComment("0: Only non with chip+magnetic, 1: Only contactless, 2: Chip+magnetic + contactless")
                .HasColumnName("contact_less");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.HostingTaxNo)
                .HasMaxLength(11)
                .HasColumnName("hosting_tax_no");
            entity.Property(e => e.HostingTradeName)
                .HasMaxLength(30)
                .HasColumnName("hosting_trade_name");
            entity.Property(e => e.HostingUrl)
                .HasMaxLength(150)
                .HasColumnName("hosting_url");
            entity.Property(e => e.IsIksVerified)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>not verified , 1=>verfied")
                .HasColumnName("is_iks_verified");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Model)
                .HasMaxLength(10)
                .HasComment("IKS  terminal  model name")
                .HasColumnName("model")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.PaymentGwTaxNo)
                .HasMaxLength(11)
                .HasColumnName("payment_gw_tax_no");
            entity.Property(e => e.PaymentGwTradeName)
                .HasMaxLength(30)
                .HasColumnName("payment_gw_trade_name");
            entity.Property(e => e.PaymentGwUrl)
                .HasMaxLength(150)
                .HasColumnName("payment_gw_url");
            entity.Property(e => e.PinPad)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>yes, 1=> No")
                .HasColumnName("pin_pad");
            entity.Property(e => e.SerialNo)
                .HasMaxLength(22)
                .HasComment("IKS  terminal  Serial No")
                .HasColumnName("serial_no")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.Status)
                .HasComment("0 -> In Active, 1 -> Active 2 -> Deleted")
                .HasColumnName("status");
            entity.Property(e => e.StatusCode)
                .HasDefaultValueSql("'0'")
                .HasComment("IKS  terminal  status code")
                .HasColumnName("status_code");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(50)
                .HasColumnName("terminal_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Oxivo, 2 => Pavo")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VirtualPosUrl)
                .HasMaxLength(150)
                .HasColumnName("virtual_pos_url");
        });

        modelBuilder.Entity<MerchantTransactionLimit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_transaction_limits")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => new { e.MerchantId, e.CurrencyId, e.PaymentTypeId }, "merchant_id_currency_id_payment_type_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DailyExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("daily_expire_date");
            entity.Property(e => e.DailyMaxAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("daily_max_amount");
            entity.Property(e => e.DailyMaxNo).HasColumnName("daily_max_no");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MonthlyExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("monthly_expire_date");
            entity.Property(e => e.MonthlyMaxAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("monthly_max_amount");
            entity.Property(e => e.MonthlyMaxNo).HasColumnName("monthly_max_no");
            entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");
            entity.Property(e => e.TransactionType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=3D, 2 = 2D")
                .HasColumnName("transaction_type");
            entity.Property(e => e.TransactionWiseExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_wise_expire_date");
            entity.Property(e => e.TransactionWiseMaxAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("transaction_wise_max_amount");
            entity.Property(e => e.TransactionWiseMinAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("transaction_wise_min_amount");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantVirtualAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_virtual_accounts")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(100)
                .HasComment("merchant account number from wallet gate side")
                .HasColumnName("account_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Dob)
                .HasComment("date of birth of merchant while kyc verification")
                .HasColumnName("dob");
            entity.Property(e => e.KycLevelCode)
                .HasComment("verification code form wallet gate side")
                .HasColumnName("kyc_level_code");
            entity.Property(e => e.MerchantId)
                .HasComment("merchant table primary id")
                .HasColumnName("merchant_id");
            entity.Property(e => e.Tckn)
                .HasMaxLength(50)
                .HasComment("encrypted national id of merchant while kyc verification")
                .HasColumnName("tckn");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantVirtualAccountWallet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_virtual_account_wallets")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'1'")
                .HasComment("currency table id")
                .HasColumnName("currency_id");
            entity.Property(e => e.MerchantVirtualAccountId)
                .HasComment("merchant_virtual_accounts table primary id")
                .HasColumnName("merchant_virtual_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WalletNumber)
                .HasMaxLength(50)
                .HasComment("merchant wallet number from wallet gate side")
                .HasColumnName("wallet_number");
        });

        modelBuilder.Entity<MerchantVirtualAccountWalletCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_virtual_account_wallet_cards")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardReference)
                .HasMaxLength(50)
                .HasComment("masked card number from wallet gate")
                .HasColumnName("card_reference");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantVirtualAccountWalletId)
                .HasComment("merchant_virtual_account_wallets table primary id")
                .HasColumnName("merchant_virtual_account_wallet_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantVknTcknBlacklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("merchant_vkn_tckn_blacklist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlackListReason)
                .HasMaxLength(255)
                .HasColumnName("black_list_reason");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasComment("user id of who created")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(200)
                .HasColumnName("created_by_name");
            entity.Property(e => e.Status)
                .HasComment("1 = active, 0 = inactive")
                .HasColumnName("status");
            entity.Property(e => e.Tckn)
                .HasMaxLength(50)
                .HasColumnName("tckn");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasComment("user id of who modified")
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedByName)
                .HasMaxLength(200)
                .HasComment("modified by name")
                .HasColumnName("updated_by_name");
            entity.Property(e => e.Vkn)
                .HasMaxLength(50)
                .HasColumnName("vkn");
        });

        modelBuilder.Entity<MerchantWebHookKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchant_web_hook_keys")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .HasColumnName("key_name");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("'1=sale webhook, 2=recurring webhook'")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .HasColumnName("value");
        });

        modelBuilder.Entity<MerchantYapiCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("merchant_yapi_credentials");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId)
                .HasMaxLength(30)
                .HasColumnName("application_id");
            entity.Property(e => e.BasicToken)
                .HasMaxLength(100)
                .HasColumnName("basic_token");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MerchantsCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("merchants_commissions")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActiveStatus)
                .HasDefaultValueSql("'0'")
                .HasComment("0=inactive; 1=active")
                .HasColumnName("active_status");
            entity.Property(e => e.AllowPayByTokenRefundFee)
                .HasDefaultValueSql("'0'")
                .HasComment("0 =fee back disable ; 1 = fee back enable")
                .HasColumnName("allow_pay_by_token_refund_fee");
            entity.Property(e => e.B2bCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("b2b_commission");
            entity.Property(e => e.B2cCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("b2c_commission");
            entity.Property(e => e.ChargebackCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("chargeback_commission");
            entity.Property(e => e.ChargebackCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("chargeback_commission_fixed");
            entity.Property(e => e.CotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_fixed");
            entity.Property(e => e.CotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.ImportedTransactionCommissionFixed)
                .HasComment("Commission Fixed Of Imported Transactions")
                .HasColumnType("double(12,4)")
                .HasColumnName("imported_transaction_commission_fixed");
            entity.Property(e => e.ImportedTransactionCommissionPercentage)
                .HasComment("Commission Percentage Of Imported Transactions")
                .HasColumnType("double(12,4)")
                .HasColumnName("imported_transaction_commission_percentage");
            entity.Property(e => e.ImportedTransactionCotFixed)
                .HasComment("cost of transaction fixed of imported transaction")
                .HasColumnType("double(12,4)")
                .HasColumnName("imported_transaction_cot_fixed");
            entity.Property(e => e.ImportedTransactionCotPercentage)
                .HasComment("cost of transaction percentage of imported transaction")
                .HasColumnType("double(12,4)")
                .HasColumnName("imported_transaction_cot_percentage");
            entity.Property(e => e.IsDebitCardCommissionEnable)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_debit_card_commission_enable");
            entity.Property(e => e.IsEnableImportedTransactionCommission)
                .HasDefaultValueSql("'0'")
                .HasComment("Determine Imported Transaction(like Oxivo, Pavo etc) Commission is enabled or not.")
                .HasColumnName("is_enable_imported_transaction_commission");
            entity.Property(e => e.IsEnablePayByToken)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_enable_pay_by_token");
            entity.Property(e => e.IsEnableTaxiCommission)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_enable_taxi_commission");
            entity.Property(e => e.IsEnableYkbCommission)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_enable_ykb_commission");
            entity.Property(e => e.IsForeignCardCommissionEnable)
                .HasDefaultValueSql("'0'")
                .HasComment("0 =is_foreign_card_commission_enable inactive ; 1 = is_foreign_card_commission_enable active")
                .HasColumnName("is_foreign_card_commission_enable");
            entity.Property(e => e.MerchantCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_commission");
            entity.Property(e => e.MerchantCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_commission_fixed");
            entity.Property(e => e.MerchantDebitCardCommsissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_debit_card_commsission_fixed");
            entity.Property(e => e.MerchantDebitCardCommsissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_debit_card_commsission_percentage");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Operator)
                .HasComment("1=>Turkcell;2=>Vodafone;3=>Turk Telekom;")
                .HasColumnName("operator");
            entity.Property(e => e.PayByTokenCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("pay_by_token_commission");
            entity.Property(e => e.PayByTokenFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("pay_by_token_fixed");
            entity.Property(e => e.PaymentTypeId)
                .HasComment("1=Credit Card;2=>Mobile Payment;3=>Sipay Wallet")
                .HasColumnName("payment_type_id");
            entity.Property(e => e.Provider)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>N/A;1=>wirecard;")
                .HasColumnName("provider");
            entity.Property(e => e.RefundCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_commission");
            entity.Property(e => e.RefundCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_commission_fixed");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
            entity.Property(e => e.SinglePaymentSettlementId).HasColumnName("single_payment_settlement_id");
            entity.Property(e => e.TaxiCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("taxi_commission_fixed");
            entity.Property(e => e.TaxiCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("taxi_commission_percentage");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("user_commission");
            entity.Property(e => e.UserCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("user_commission_fixed");
            entity.Property(e => e.UserDebitCardCommsissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("user_debit_card_commsission_fixed");
            entity.Property(e => e.UserDebitCardCommsissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("user_debit_card_commsission_percentage");
            entity.Property(e => e.YkbCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("ykb_commission_fixed");
            entity.Property(e => e.YkbCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("ykb_commission_percentage");
        });

        modelBuilder.Entity<MerchantsStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("merchants_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlackListReason)
                .HasMaxLength(100)
                .HasColumnName("black_list_reason");
            entity.Property(e => e.BlackReason)
                .HasMaxLength(100)
                .HasColumnName("black_reason");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ResponseStatus)
                .HasComment("1 = blacklisted, 0 = not blacklisted")
                .HasColumnName("response_status");
            entity.Property(e => e.Tckn)
                .HasMaxLength(50)
                .HasColumnName("tckn");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Vkn)
                .HasMaxLength(50)
                .HasColumnName("vkn");
        });

        modelBuilder.Entity<MetropolUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("metropol_users")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountToken)
                .HasMaxLength(100)
                .HasColumnName("account_token")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(20)
                .HasColumnName("customer_number")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.Pan)
                .HasMaxLength(20)
                .HasColumnName("pan")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("migrations")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(191)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("modules")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.Icon)
                .HasMaxLength(255)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notifications")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CreatedAt, "created_at");

            entity.HasIndex(e => e.NotifiableId, "notifiable_id");

            entity.HasIndex(e => e.UserType, "user_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DataEn)
                .HasColumnType("text")
                .HasColumnName("data_en");
            entity.Property(e => e.DataTr)
                .HasColumnType("text")
                .HasColumnName("data_tr");
            entity.Property(e => e.NotifiableId).HasColumnName("notifiable_id");
            entity.Property(e => e.NotifiableType)
                .HasMaxLength(255)
                .HasColumnName("notifiable_type");
            entity.Property(e => e.NotificationSubcategoryId)
                .HasComment("Notification Sub Category Table Id to manage notification type")
                .HasColumnName("notification_subcategory_id");
            entity.Property(e => e.ReadAt)
                .HasColumnType("timestamp")
                .HasColumnName("read_at");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'5'")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<NotificationAutomation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notification_automations")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attachment)
                .HasMaxLength(191)
                .HasColumnName("attachment");
            entity.Property(e => e.Attempts)
                .HasDefaultValueSql("'0'")
                .HasColumnName("attempts");
            entity.Property(e => e.Bcc)
                .HasMaxLength(50)
                .HasColumnName("bcc");
            entity.Property(e => e.Cc)
                .HasMaxLength(50)
                .HasColumnName("cc");
            entity.Property(e => e.Contents)
                .HasColumnType("text")
                .HasColumnName("contents");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("datetime")
                .HasColumnName("delete_at");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.ReceiverEmail)
                .HasColumnType("text")
                .HasColumnName("receiver_email")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.SenderEmail)
                .HasMaxLength(50)
                .HasColumnName("sender_email");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0 => not sent yet, 1 => sent")
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .HasColumnName("subject");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'0'")
                .HasComment("1=> email, 2=>sms")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<NotificationCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notification_categories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<NotificationEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notification_events")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.EventId)
                .HasComment("1=Payment link success, 2=Payment link failed, 3=Manual pos success, 4=Manual pos failed, 5=API transaction success , 6=API transaction failed")
                .HasColumnName("event_id");
            entity.Property(e => e.MerchantId)
                .HasComment("id from merchant table")
                .HasColumnName("merchant_id");
            entity.Property(e => e.NotificationType)
                .HasComment("1 = email, 2 = SMS, 3 = Push notification")
                .HasColumnName("notification_type");
            entity.Property(e => e.Receivers)
                .HasComment("Receivers email or phone number list")
                .HasColumnType("text")
                .HasColumnName("receivers");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1 = Active 0 = Inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UserId)
                .HasComment("id from user table")
                .HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasComment("0=>customer; 1=>admin; 2=>merchant; 3=>submerchant")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<NotificationSubcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notification_subcategories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.NotificationCategoryId).HasColumnName("notification_category_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OauthAccessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("oauth_access_tokens")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "oauth_access_tokens_user_id_index");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime")
                .HasColumnName("expires_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Revoked).HasColumnName("revoked");
            entity.Property(e => e.Scopes)
                .HasColumnType("text")
                .HasColumnName("scopes");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<OauthAuthCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("oauth_auth_codes")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime")
                .HasColumnName("expires_at");
            entity.Property(e => e.Revoked).HasColumnName("revoked");
            entity.Property(e => e.Scopes)
                .HasColumnType("text")
                .HasColumnName("scopes");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<OauthClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("oauth_clients")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UserId, "oauth_clients_user_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.PasswordClient).HasColumnName("password_client");
            entity.Property(e => e.PersonalAccessClient).HasColumnName("personal_access_client");
            entity.Property(e => e.Provider)
                .HasMaxLength(100)
                .HasColumnName("provider");
            entity.Property(e => e.Redirect)
                .HasColumnType("text")
                .HasColumnName("redirect");
            entity.Property(e => e.Revoked).HasColumnName("revoked");
            entity.Property(e => e.Secret)
                .HasMaxLength(100)
                .HasColumnName("secret");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<OauthPersonalAccessClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("oauth_personal_access_clients")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.ClientId, "oauth_personal_access_clients_client_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OauthRefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("oauth_refresh_tokens")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AccessTokenId, "oauth_refresh_tokens_access_token_id_index");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .HasColumnName("id");
            entity.Property(e => e.AccessTokenId)
                .HasMaxLength(100)
                .HasColumnName("access_token_id");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime")
                .HasColumnName("expires_at");
            entity.Property(e => e.Revoked).HasColumnName("revoked");
        });

        modelBuilder.Entity<Otpl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("otpls")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.MaxAmount)
                .HasColumnType("double(12,2)")
                .HasColumnName("max_amount");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MinAmount)
                .HasColumnType("double(12,2)")
                .HasColumnName("min_amount");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=passive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OutGoingEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("out_going_email")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attachment)
                .HasMaxLength(255)
                .HasComment("email attachment path")
                .HasColumnName("attachment");
            entity.Property(e => e.Bcc)
                .HasMaxLength(255)
                .HasComment("bcc email address")
                .HasColumnName("bcc");
            entity.Property(e => e.Body)
                .HasComment("email body")
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.Cc)
                .HasMaxLength(255)
                .HasComment("cc email address")
                .HasColumnName("cc");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.From)
                .HasMaxLength(100)
                .HasComment("from email address")
                .HasColumnName("from");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasComment("email sending exception")
                .HasColumnName("note");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'1'")
                .HasComment("1=low, 2=medium, 3=high, 4=express")
                .HasColumnName("priority");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=pending, 2=in progress, 3=successfully sent, 4=failed")
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasComment("email subject")
                .HasColumnName("subject");
            entity.Property(e => e.To)
                .HasComment("to email addresses separated by comma")
                .HasColumnType("text")
                .HasColumnName("to");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1=smtp, 2=soap")
                .HasColumnName("type");
            entity.Property(e => e.Unlink)
                .HasDefaultValueSql("'1'")
                .HasComment("1=yes, 2=no")
                .HasColumnName("unlink");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OutGoingPushNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("out_going_push_notifications", tb => tb.HasComment("mobile app push notifications"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.NotificationBody)
                .HasMaxLength(500)
                .HasComment("notification body")
                .HasColumnName("notification_body");
            entity.Property(e => e.NotificationTitle)
                .HasMaxLength(150)
                .HasComment("notification heading")
                .HasColumnName("notification_title");
            entity.Property(e => e.Payload)
                .HasComment("json encoded payload")
                .HasColumnType("text")
                .HasColumnName("payload");
            entity.Property(e => e.Priority)
                .IsRequired()
                .HasDefaultValueSql("'4'")
                .HasComment("1=>low, 2=>medium, 3=>high, 4=>express")
                .HasColumnName("priority");
            entity.Property(e => e.ReceiverType)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=>single,2=>multiple,3=>group")
                .HasColumnName("receiver_type");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>pending, 2=>in progress, 3=> successfully sent, 4=>failed")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OutGoingSm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("out_going_sms")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Header)
                .HasMaxLength(255)
                .HasComment("header data")
                .HasColumnName("header");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasComment("message body")
                .HasColumnName("message");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasComment("sms sending exception")
                .HasColumnName("note");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasComment("to phone number")
                .HasColumnName("phone");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'0'")
                .HasComment("1=low, 2=medium, 3=high, 4=express")
                .HasColumnName("priority");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=pending, 2=in progress, 3=successfully sent, 4=failed")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OutgoingCurlRequestRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("outgoing_curl_request_records")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExceptionMsg)
                .HasMaxLength(255)
                .HasColumnName("exception_msg");
            entity.Property(e => e.Method)
                .HasDefaultValueSql("'1'")
                .HasComment("1=post, 2=get")
                .HasColumnName("method");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.RequestParams)
                .HasComment("request parameters")
                .HasColumnType("text")
                .HasColumnName("request_params");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=pending, 2=processed, 3=exception")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("1=withdraw, 2=b2cbank, 3=cashout_file_alert, 4=cashout_each_request")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pages")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AvailableToCompany).HasColumnName("available_to_company");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.MethodName)
                .HasMaxLength(255)
                .HasColumnName("method_name");
            entity.Property(e => e.MethodType)
                .HasComment("1=Post, 2=Get, 3=Put, 4=Delete")
                .HasColumnName("method_type");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SubModuleId).HasColumnName("sub_module_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PaidBill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paid_bills");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssociationCode)
                .HasMaxLength(150)
                .HasColumnName("association_code");
            entity.Property(e => e.AssociationName)
                .HasMaxLength(150)
                .HasColumnName("association_name");
            entity.Property(e => e.BillInvoiceNumber)
                .HasMaxLength(50)
                .HasColumnName("bill_invoice_number");
            entity.Property(e => e.BillPaymentProvider)
                .HasMaxLength(20)
                .HasComment("Bill Payment provider = Paycell,Intertech")
                .HasColumnName("bill_payment_provider");
            entity.Property(e => e.CardHolder)
                .HasMaxLength(150)
                .HasColumnName("card_holder");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(70)
                .HasColumnName("card_number");
            entity.Property(e => e.CommissionAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CustomPaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("custom_payment_method");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.EndUserCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("end user commission fixed for bill payment ")
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_fixed");
            entity.Property(e => e.EndUserCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("end user commission percentage for bill payment ")
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_percentage");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupName)
                .HasMaxLength(150)
                .HasColumnName("group_name");
            entity.Property(e => e.InvoiceAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("invoice_amount");
            entity.Property(e => e.InvoiceDueDate)
                .HasMaxLength(50)
                .HasColumnName("invoice_due_date");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.InvoiceIndex).HasColumnName("invoice_index");
            entity.Property(e => e.InvoiceRefNo)
                .HasMaxLength(50)
                .HasColumnName("invoice_ref_no");
            entity.Property(e => e.InvoiceSeqNo)
                .HasMaxLength(50)
                .HasColumnName("invoice_seq_no");
            entity.Property(e => e.InvoiceStatus)
                .HasMaxLength(50)
                .HasColumnName("invoice_status");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(150)
                .HasColumnName("merchant_name");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Net)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.PaymentAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("payment_amount");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PaymentOperation)
                .HasMaxLength(50)
                .HasColumnName("payment_operation");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
            entity.Property(e => e.RemoteCreatedAt)
                .HasComment("Transaction date from bill payment api response")
                .HasColumnType("datetime")
                .HasColumnName("remote_created_at");
            entity.Property(e => e.RemoteTransactionId)
                .HasMaxLength(40)
                .HasComment("Transaction id from bill payment api response")
                .HasColumnName("remote_transaction_id");
            entity.Property(e => e.Status)
                .HasComment("0=>pending, 1=>approved, 2=>rejected")
                .HasColumnName("status");
            entity.Property(e => e.SubscriberNo)
                .HasMaxLength(150)
                .HasColumnName("subscriber_no");
            entity.Property(e => e.Tckn)
                .HasMaxLength(100)
                .HasColumnName("tckn");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(150)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("password_resets")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Email, "password_resets_email_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.Token)
                .HasMaxLength(191)
                .HasColumnName("token");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'0'")
                .HasComment("0=customer, 1=admin, 2=merchant, 3=submerchant, 4=integrator")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<PaybillOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("paybill_options")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillPaymentProvider)
                .HasMaxLength(20)
                .HasColumnName("bill_payment_provider")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CancelUrl)
                .HasMaxLength(100)
                .HasComment("Url for cancel bill payment")
                .HasColumnName("cancel_url")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CategoryUrl)
                .HasMaxLength(100)
                .HasComment("Url for get category")
                .HasColumnName("category_url")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Credentials)
                .HasColumnType("text")
                .HasColumnName("credentials");
            entity.Property(e => e.InvoiceUrl)
                .HasMaxLength(100)
                .HasComment("Url for get invoices")
                .HasColumnName("invoice_url")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PaymentUrl)
                .HasMaxLength(100)
                .HasComment("Url for pay invoce or bill payment")
                .HasColumnName("payment_url")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=> active, 0=>inactive")
                .HasColumnName("status");
            entity.Property(e => e.SubCategoryUrl)
                .HasMaxLength(100)
                .HasComment("Url for get sub category")
                .HasColumnName("sub_category_url")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PaymentRecOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("payment_rec_options")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("permissions")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Key, "permissions_key_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Key)
                .HasMaxLength(191)
                .HasColumnName("key");
            entity.Property(e => e.TableName)
                .HasMaxLength(191)
                .HasColumnName("table_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PermissionRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("permission_role")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.PermissionId, e.RoleId }, "permission_id_role_id").IsUnique();

            entity.HasIndex(e => e.PermissionId, "permission_role_permission_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.PermissionRoles)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("permission_role_permission_id_foreign");
        });

        modelBuilder.Entity<PfHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pf_histories")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankCode)
                .HasMaxLength(20)
                .HasColumnName("bank_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Ip)
                .HasMaxLength(45)
                .HasColumnName("ip");
            entity.Property(e => e.MerchantId)
                .HasMaxLength(50)
                .HasColumnName("merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PhysicalPosSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("physical_pos_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LastTransactionId)
                .HasMaxLength(50)
                .HasColumnName("last_transaction_id");
            entity.Property(e => e.Type)
                .HasComment("Type of Physical POS. Example: Oxivo => 1, Pavo => 2, Taxi => 3, MT => 4, WD => 5, Hugin => 6, Sari Texi => 7, Virtual POS => 8.")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Pos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.PosId, "pos_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowForeignCard)
                .HasDefaultValueSql("'0'")
                .HasComment("0 =allow_foreign_card inactive; 1= allow_foreign_card active")
                .HasColumnName("allow_foreign_card");
            entity.Property(e => e.AllowPayByCardToken)
                .HasDefaultValueSql("'0'")
                .HasColumnName("allow_pay_by_card_token");
            entity.Property(e => e.BankClosingTime)
                .HasDefaultValueSql("'23:59:59'")
                .HasColumnType("time")
                .HasColumnName("bank_closing_time");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name");
            entity.Property(e => e.Bolum).HasColumnName("bolum");
            entity.Property(e => e.BrandBankAccountId)
                .HasDefaultValueSql("'0'")
                .HasComment("id from brand_bank_accounts table where pos account is true")
                .HasColumnName("brand_bank_account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("currency_id");
            entity.Property(e => e.DebitCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("debit_cot_fixed");
            entity.Property(e => e.DebitCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("debit_cot_percentage");
            entity.Property(e => e.ForeignAmexCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_amex_cot_fixed");
            entity.Property(e => e.ForeignAmexCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_amex_cot_percentage");
            entity.Property(e => e.ForeignCardSettlementId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("foreign_card_settlement_id");
            entity.Property(e => e.ForeignCcCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_cc_cot_fixed");
            entity.Property(e => e.ForeignCcCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_cc_cot_percentage");
            entity.Property(e => e.IsAllowDcc)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not  allow,  1=allow")
                .HasColumnName("is_allow_dcc");
            entity.Property(e => e.IsAllowForeignAmexCard)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not  allow,  1=allow")
                .HasColumnName("is_allow_foreign_amex_card");
            entity.Property(e => e.IsAllowInsurancePayment)
                .HasDefaultValueSql("'0'")
                .HasComment("To check if POS is allowed for insurance payment\r\n0 : Not Allowed\r\n1 : Allowed")
                .HasColumnName("is_allow_insurance_payment");
            entity.Property(e => e.IsAllowLocalAmexCard)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not  allow,  1=allow")
                .HasColumnName("is_allow_local_amex_card");
            entity.Property(e => e.IsAllowPreAuth)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = auth ; 1 = pre_auth")
                .HasColumnName("is_allow_pre_auth");
            entity.Property(e => e.IsAllowSale)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_allow_sale");
            entity.Property(e => e.IsEnable2d)
                .HasDefaultValueSql("'0'")
                .HasComment("1=enable; 0=disable")
                .HasColumnName("is_enable_2d");
            entity.Property(e => e.IsEnable3d)
                .HasDefaultValueSql("'1'")
                .HasComment("1=enable; 0=disable")
                .HasColumnName("is_enable_3d");
            entity.Property(e => e.IsInstallmentWiseSettlement)
                .HasDefaultValueSql("'0'")
                .HasComment("To check if POS is allowed for installment wise settlement\r\n0 : Not Allowed\r\n1 : Allowed")
                .HasColumnName("is_installment_wise_settlement");
            entity.Property(e => e.IsRecurring)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_recurring");
            entity.Property(e => e.IsShowOnDeposit)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_show_on_deposit");
            entity.Property(e => e.LocalAmexCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("local_amex_cot_fixed");
            entity.Property(e => e.LocalAmexCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("local_amex_cot_percentage");
            entity.Property(e => e.MaxInstallment)
                .HasDefaultValueSql("'1'")
                .HasColumnName("max_installment");
            entity.Property(e => e.MaxNoOfFailedAttempt).HasColumnName("max_no_of_failed_attempt");
            entity.Property(e => e.MinInstallment)
                .HasDefaultValueSql("'1'")
                .HasColumnName("min_installment");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NotUsCcCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_cc_cot_fixed");
            entity.Property(e => e.NotUsCcCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_cc_cot_percentage");
            entity.Property(e => e.NotUsDebitCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_debit_cot_fixed");
            entity.Property(e => e.NotUsDebitCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_debit_cot_percentage");
            entity.Property(e => e.OnUsCcCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("on_us_cc_cot_fixed");
            entity.Property(e => e.OnUsCcCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("on_us_cc_cot_percentage");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Program)
                .HasMaxLength(100)
                .HasColumnName("program");
            entity.Property(e => e.RefundSettlementId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("refund_settlement_id");
            entity.Property(e => e.RemoteSubMerchantId)
                .HasMaxLength(50)
                .HasColumnName("remote_sub_merchant_id");
            entity.Property(e => e.SameProgramDiffrentBankCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_diffrent_bank_cot_fixed");
            entity.Property(e => e.SameProgramDiffrentBankCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_diffrent_bank_cot_percentage");
            entity.Property(e => e.SameProgramSameBankCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_same_bank_cot_fixed");
            entity.Property(e => e.SameProgramSameBankCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_same_bank_cot_percentage");
            entity.Property(e => e.SendPfRecords)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = dont send, 1 = send")
                .HasColumnName("send_pf_records");
            entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_id");
            entity.Property(e => e.VirtualPosId)
                .HasMaxLength(50)
                .HasColumnName("virtual_pos_id")
                .UseCollation("utf8mb3_unicode_ci");
        });

        modelBuilder.Entity<PosBankCardBlackList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_bank_card_black_list")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IssuerName)
                .HasMaxLength(255)
                .HasColumnName("issuer_name");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PosCampaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_campaigns")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.PosId, e.Status }, "pos_id_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(10)
                .HasDefaultValueSql("'0'")
                .HasComment("0=All; 1=Only For Commercial; 2=Only For Non-Commercial, 3 = On Us commercial, 4 = Not on Us commercial")
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Days)
                .HasMaxLength(255)
                .HasColumnName("days");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("from_date");
            entity.Property(e => e.IsAllMerchant)
                .HasDefaultValueSql("'1'")
                .HasComment("0=not for all, 1= for all")
                .HasColumnName("is_all_merchant");
            entity.Property(e => e.MaxInstallment)
                .HasDefaultValueSql("'0'")
                .HasColumnName("max_installment");
            entity.Property(e => e.MaxTransactionAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("max_transaction_amount");
            entity.Property(e => e.MerchantIds)
                .HasColumnType("text")
                .HasColumnName("merchant_ids");
            entity.Property(e => e.MinInstallment)
                .HasDefaultValueSql("'0'")
                .HasColumnName("min_installment");
            entity.Property(e => e.MinTransactionAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("min_transaction_amount");
            entity.Property(e => e.PlusInstallment)
                .HasDefaultValueSql("'0'")
                .HasColumnName("plus_installment");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0= inactive, 1= active")
                .HasColumnName("status");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("to_date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PosCampaignsInstallment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_campaigns_installments")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_fixed");
            entity.Property(e => e.CotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.InstallmentsNumber).HasColumnName("installments_number");
            entity.Property(e => e.PosCampaignId).HasColumnName("pos_campaign_id");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive;1=>active;")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PosInstallment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_installments")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => new { e.PosId, e.InstallmentsNumber }, "pos_id_installments_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_fixed");
            entity.Property(e => e.CotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.InstallmentsNumber).HasColumnName("installments_number");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive;1=>active;")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PosInstallmentSettlementSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_installment_settlement_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.PosId, e.InstallmentsNumber }, "pos_id_installments_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.InstallmentsNumber)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = single installment, 1 = 1st payment of installment, others are regular installment number")
                .HasColumnName("installments_number");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id");
            entity.Property(e => e.SettlementDay)
                .HasComment("The day installment amount will be settle to merchant wallet.For example 30. installment amount will be settle after 30 days from sale date")
                .HasColumnName("settlement_day");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive;1=>active;")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PosIssuerTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_issuer_tags")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
        });

        modelBuilder.Entity<PosRedirection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_redirections")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("from_date");
            entity.Property(e => e.FromPosId).HasColumnName("from_pos_id");
            entity.Property(e => e.IsAllMerchant)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not for all, 1= for all")
                .HasColumnName("is_all_merchant");
            entity.Property(e => e.MerchantIds)
                .HasColumnType("text")
                .HasColumnName("merchant_ids");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0= inactive, 1= active")
                .HasColumnName("status");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("to_date");
            entity.Property(e => e.ToPosId).HasColumnName("to_pos_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<PosRiskyCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pos_risky_countries")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.PosId, "pos_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(30)
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ForeignRiskyCountryCcCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_risky_country_cc_cot_fixed");
            entity.Property(e => e.ForeignRiskyCountryCcCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_risky_country_cc_cot_percentage");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = Inactive, 1 = Active")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("posts")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Slug, "posts_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Excerpt)
                .HasColumnType("text")
                .HasColumnName("excerpt");
            entity.Property(e => e.Featured).HasColumnName("featured");
            entity.Property(e => e.Image)
                .HasMaxLength(191)
                .HasColumnName("image");
            entity.Property(e => e.MetaDescription)
                .HasColumnType("text")
                .HasColumnName("meta_description");
            entity.Property(e => e.MetaKeywords)
                .HasColumnType("text")
                .HasColumnName("meta_keywords");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(191)
                .HasColumnName("seo_title");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasColumnName("slug");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'DRAFT'")
                .HasColumnType("enum('PUBLISHED','DRAFT','PENDING')")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProfileInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("profiles")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Document)
                .HasMaxLength(255)
                .HasColumnName("document");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(255)
                .HasColumnName("document_type");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<ProviderErrorCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("provider_error_codes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(25)
                .HasColumnName("error_code");
            entity.Property(e => e.ErrorDescription)
                .HasMaxLength(255)
                .HasColumnName("error_description");
            entity.Property(e => e.Provider)
                .HasMaxLength(25)
                .HasComment("Provider constants")
                .HasColumnName("provider");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("purchases")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Net)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.PaymentTypeId)
                .HasDefaultValueSql("'0'")
                .HasComment("1=>credit_card, 2=>Mobile, 3=>Wallet")
                .HasColumnName("payment_type_id");
            entity.Property(e => e.RefundReason)
                .HasMaxLength(255)
                .HasColumnName("refund_reason");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<RandomCustomerId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("random_customer_ids")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Reason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reasons")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(100)
                .HasColumnName("category_code")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Status)
                .HasComment("1=>Active, 0=>Inactive")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.TitleTr)
                .HasMaxLength(255)
                .HasColumnName("title_tr")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ReasonCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reason_categories")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Receife>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("receives")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.FromGsmNumber)
                .HasMaxLength(50)
                .HasColumnName("from_gsm_number");
            entity.Property(e => e.FromId).HasColumnName("from_id");
            entity.Property(e => e.FromName)
                .HasMaxLength(100)
                .HasColumnName("from_name");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Net)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.SendId).HasColumnName("send_id");
            entity.Property(e => e.SenderMerchantId).HasColumnName("sender_merchant_id");
            entity.Property(e => e.SenderMerchantName)
                .HasMaxLength(100)
                .HasColumnName("sender_merchant_name");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserGsmNumber)
                .HasMaxLength(50)
                .HasColumnName("user_gsm_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<RefundHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("refund_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.HasIndex(e => e.UniqueString, "unique_string").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminActionBy).HasColumnName("admin_action_by");
            entity.Property(e => e.AdminActionDate)
                .HasColumnType("timestamp")
                .HasColumnName("admin_action_date");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EndUserId).HasColumnName("end_user_id");
            entity.Property(e => e.IsApproveTriggered)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not approved yet, 1=refund is approved")
                .HasColumnName("is_approve_triggered");
            entity.Property(e => e.IsFullyRefunded)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_fully_refunded");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.NetRefundAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("net_refund_amount");
            entity.Property(e => e.OriginalBankErrorCode)
                .HasMaxLength(50)
                .HasColumnName("original_bank_error_code");
            entity.Property(e => e.OriginalBankErrorDescription)
                .HasMaxLength(255)
                .HasColumnName("original_bank_error_description");
            entity.Property(e => e.RefundAuthCode)
                .HasMaxLength(50)
                .HasComment("store auth code which is provided by bank while refund")
                .HasColumnName("refund_auth_code");
            entity.Property(e => e.RefundBankSettlementDate)
                .HasColumnType("datetime")
                .HasColumnName("refund_bank_settlement_date");
            entity.Property(e => e.RefundCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("This is not a percentage value but percentage amount without fixed amount")
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_commission");
            entity.Property(e => e.RefundCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_commission_fixed");
            entity.Property(e => e.RefundFeeWallet)
                .HasMaxLength(25)
                .HasColumnName("refund_fee_wallet");
            entity.Property(e => e.RefundReferenceNumber)
                .HasMaxLength(100)
                .HasColumnName("refund_reference_number");
            entity.Property(e => e.RefundTo)
                .HasDefaultValueSql("'2'")
                .HasComment("1=>refund to Wallet, 2=> refund to Bank")
                .HasColumnName("refund_to");
            entity.Property(e => e.RefundTransactionId)
                .HasMaxLength(100)
                .HasColumnName("refund_transaction_id");
            entity.Property(e => e.RefundType)
                .HasDefaultValueSql("'0'")
                .HasComment("1= refund, 2= chargeback")
                .HasColumnName("refund_type");
            entity.Property(e => e.RequestedBy)
                .HasDefaultValueSql("'0'")
                .HasColumnName("requested_by");
            entity.Property(e => e.RollingRefundAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("rolling_refund_amount");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'0'")
                .HasComment("1= admin, 2=merchant 3=api")
                .HasColumnName("source");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.TransactionableId).HasColumnName("transactionable_id");
            entity.Property(e => e.TransactionableType)
                .HasMaxLength(50)
                .HasDefaultValueSql("'App\\\\Models\\\\Sale'")
                .HasColumnName("transactionable_type");
            entity.Property(e => e.UniqueString)
                .HasMaxLength(60)
                .HasColumnName("unique_string");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.WalletSource)
                .HasDefaultValueSql("'0'")
                .HasComment("1=withdrawable , 2 -  non-withdrrawable")
                .HasColumnName("wallet_source");
            entity.Property(e => e.ApprovedBy)
                .HasDefaultValueSql(null)
                .HasMaxLength(100)
                .HasColumnName("approved_by");
        });

        modelBuilder.Entity<RefundPhysicalPo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("refund_physical_pos")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.PaymentSource, e.UniqueId }, "unique_refund_physical_pos_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("amount to be deducted")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasComment("currency table primary id")
                .HasColumnName("currency_id");
            entity.Property(e => e.Data)
                .HasComment("all data of this transaction in a json format ")
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.MerchantId)
                .HasComment("merchants table primary id")
                .HasColumnName("merchant_id");
            entity.Property(e => e.PaymentSource)
                .HasComment("payment source of this transaction")
                .HasColumnName("payment_source");
            entity.Property(e => e.Status)
                .HasComment("0 = pending, 1 = processed by cronjob")
                .HasColumnName("status");
            entity.Property(e => e.UniqueId)
                .HasMaxLength(50)
                .HasComment("payment unique id to distinguish")
                .HasColumnName("unique_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PurchaseRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("requests")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.MerchantId, e.InvoiceId }, "merchant_id_invoice_id");

            entity.HasIndex(e => e.Ref, "requests_ref_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(255)
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.Ip)
                .HasMaxLength(45)
                .HasColumnName("ip");
            entity.Property(e => e.IsDuplicateInvoice)
                .HasDefaultValueSql("'0'")
                .HasComment("For Duplicate Purchase Request\r\n0 = No Duplicate\r\n1 = Found Duplicate\r\n2 = Cacnelled In Bank\r\n3 = Tmp Refund Request Created")
                .HasColumnName("is_duplicate_invoice");
            entity.Property(e => e.IsExpired).HasColumnName("is_expired");
            entity.Property(e => e.Lang)
                .HasMaxLength(4)
                .HasColumnName("lang");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasComment("Merchant Id of a Merchant")
                .HasColumnName("merchant_id");
            entity.Property(e => e.MerchantKey)
                .HasMaxLength(255)
                .HasColumnName("merchant_key");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.MobilePaymentStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("mobile_payment_status");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("order_id");
            entity.Property(e => e.Ref)
                .HasMaxLength(50)
                .HasColumnName("ref")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.Surname)
                .HasMaxLength(90)
                .HasColumnName("surname")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RequestMoney>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("request_money")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.Commission)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrecnySymbol)
                .HasMaxLength(50)
                .HasColumnName("currecny_symbol")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Explanation)
                .HasMaxLength(255)
                .HasColumnName("explanation")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.ProcessDate)
                .HasColumnType("datetime")
                .HasColumnName("process_date");
            entity.Property(e => e.ReceiverId)
                .HasComment("receiver user id")
                .HasColumnName("receiver_id");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(100)
                .HasColumnName("receiver_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ReceiverPhone)
                .HasMaxLength(50)
                .HasColumnName("receiver_phone")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ReceiverRegion)
                .HasMaxLength(100)
                .HasColumnName("receiver_region")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SenderId)
                .HasComment("sender user id")
                .HasColumnName("sender_id");
            entity.Property(e => e.SenderName)
                .HasMaxLength(100)
                .HasColumnName("sender_name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SenderPhone)
                .HasMaxLength(50)
                .HasColumnName("sender_phone")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SenderRegion)
                .HasMaxLength(100)
                .HasColumnName("sender_region")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SplitAccountId)
                .HasComment("split account table primary id")
                .HasColumnName("split_account_id");
            entity.Property(e => e.Status)
                .HasComment("transactionstate table id")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'0'")
                .HasComment("0=all request money; 1=request money via split account")
                .HasColumnName("type");
            entity.Property(e => e.UniqueSplitUrl)
                .HasMaxLength(255)
                .HasComment("unique url for split account")
                .HasColumnName("unique_split_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("roles")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasComment("creator auth ID")
                .HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasComment("approve auth ID")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<RolePage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("role_pages")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.RoleId, e.PageId }, "role_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<RolePageHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("role_page_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.RoleId, e.PageId }, "role_id_page_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowedById)
                .HasComment("creator auth user id")
                .HasColumnName("allowed_by_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DisallowedById)
                .HasComment("updated auth user ID")
                .HasColumnName("disallowed_by_id");
            entity.Property(e => e.PageId)
                .HasComment("page_id for page table ID")
                .HasColumnName("page_id");
            entity.Property(e => e.RoleId)
                .HasComment("role_id for role table ID")
                .HasColumnName("role_id");
            entity.Property(e => e.Status)
                .HasComment("1= Active, 2 = InActive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RoleSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("role_settings")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsAllowMerchantAuthEmail)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_allow_merchant_auth_email");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RollingBalance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("rolling_balances")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("effective_date");
            entity.Property(e => e.IsManualPaused)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not interrupted, 1= manual interrupted")
                .HasColumnName("is_manual_paused");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Status)
                .HasComment("0=>Awaiting, 1=processed")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RollingReserve>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("rolling_reserves")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.RollingReserveAmount)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(12,2)")
                .HasColumnName("rolling_reserve_amount");
            entity.Property(e => e.RollingReserveTimeLimit)
                .HasDefaultValueSql("'0'")
                .HasColumnName("rolling_reserve_time_limit");
            entity.Property(e => e.RollingStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("rolling_status");
            entity.Property(e => e.SettlementType)
                .HasDefaultValueSql("'3'")
                .HasColumnName("settlement_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sales")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CreatedAtInt, "created_at_int");

            entity.HasIndex(e => e.DplId, "dpl_id");

            entity.HasIndex(e => e.MerchantId, "merchant_id");

            entity.HasIndex(e => e.OrderId, "order_id").IsUnique();

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.HasIndex(e => e.DuplicateInvoiceUniqueStateKey, "duplicate_invoice_unique_state_key").IsUnique();

            entity.HasIndex(e => e.UpdatedAtInt, "updated_at_int");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminForceChargebackDocument)
                .HasMaxLength(255)
                .HasComment("force chargeback document")
                .HasColumnName("admin_force_chargeback_document");
            entity.Property(e => e.AdminForceChargebackExplanation)
                .HasMaxLength(255)
                .HasComment("force chargeback reason")
                .HasColumnName("admin_force_chargeback_explanation");
            entity.Property(e => e.AdminProcessDate)
                .HasColumnType("timestamp")
                .HasColumnName("admin_process_date");
            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(20)
                .HasColumnName("auth_code");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.CardHolderBank)
                .HasMaxLength(100)
                .HasColumnName("card_holder_bank");
            entity.Property(e => e.CardIssuerName)
                .HasMaxLength(100)
                .HasColumnName("card_issuer_name");
            entity.Property(e => e.CardProgram)
                .HasMaxLength(100)
                .HasColumnName("card_program");
            entity.Property(e => e.ChargebackRejectExplanation)
                .HasMaxLength(255)
                .HasColumnName("chargeback_reject_explanation");
            entity.Property(e => e.CommissionForInstallment)
                .HasMaxLength(100)
                .HasColumnName("commission_for_installment");
            entity.Property(e => e.Cost)
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedAtInt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_at_int");
            entity.Property(e => e.CreditCardNo)
                .HasMaxLength(70)
                .HasColumnName("credit_card_no");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.Document)
                .HasMaxLength(255)
                .HasColumnName("document");
            entity.Property(e => e.DplId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("dpl_id");
            entity.Property(e => e.EndUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("end_user_id");
            entity.Property(e => e.Fee)
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(100)
                .HasColumnName("gsm_number");
            entity.Property(e => e.HostReferenceId)
                .HasMaxLength(50)
                .HasComment("host_refernce_id from provider response")
                .HasColumnName("host_reference_id");
            entity.Property(e => e.Installment).HasColumnName("installment");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("ip");
            entity.Property(e => e.IsBankRefundFailed)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not tried yet or pass, 1 = tried and failed")
                .HasColumnName("is_bank_refund_failed");
            entity.Property(e => e.IsComissionFromUser)
                .HasComment("0 => exiting flow\r\n1 => new calculation with user fee brutally change\r\n2 => new calculation with user fee brutally change as zero")
                .HasColumnName("is_comission_from_user");
            entity.Property(e => e.IsCvvLess)
                .HasComment("0 => with cvv\r\n1 => without cvv")
                .HasColumnName("is_cvv_less");
            entity.Property(e => e.IsDuplicateInvoice)
                .HasDefaultValueSql("'0'")
                .HasComment("If duplicate invoice allowed merchant comes with duplicate invoice we will update all the sales with same invoice_id and merchant_id with 1.\r\n0 = No Duplicate\r\n1 = Found Duplicate\r\n2 = Cacnelled In Bank\r\n3 = Tmp Refund Request Created\r\n")
                .HasColumnName("is_duplicate_invoice");
            entity.Property(e => e.DuplicateInvoiceUniqueStateKey)
                .HasDefaultValueSql(null)
                .HasComment("Unique key to prevent duplicate invoice")
                .HasColumnName("duplicate_invoice_unique_state_key");
            entity.Property(e => e.IsInstallmentWiseSettlement)
                .HasDefaultValueSql("'0'")
                .HasComment("To determine if sale settlement is installment wise")
                .HasColumnName("is_installment_wise_settlement");
            entity.Property(e => e.IssuerName)
                .HasMaxLength(100)
                .HasColumnName("issuer_name");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.MaturityPeriod)
                .HasDefaultValueSql("'0'")
                .HasColumnName("maturity_period");
            entity.Property(e => e.MdStatus)
                .HasDefaultValueSql("'-1'")
                .HasComment("mdStatus from bank response ranges from 0-9\r\n0: Card verification failed, do not proceed\r\n1: Verification successful, you can continue with the transaction\r\n2: Card holder or bank is not registered in the system\r\n3: The bank of the card is not registered in the system\r\n4: Verification attempt, cardholder has chosen to register with the system\r\nlater\r\n5: Unable to verify\r\n6: 3-D Secure error\r\n7: System error\r\n8: Unknown card no\r\n9: Member Merchant not registered to 3D-Secure system (merchant or\r\nterminal number is not registered on the back as 3d) ")
                .HasColumnName("md_status");
            entity.Property(e => e.MerchantCommission)
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_commission");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(100)
                .HasColumnName("merchant_name");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'3'")
                .HasColumnName("migration_status");
            entity.Property(e => e.Net)
                .HasComment("net = gross - fee + user_commission")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.Operator)
                .HasMaxLength(50)
                .HasColumnName("operator");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.PayByTokenFee)
                .HasComment("this amount will be calculated from the percentage and fixed on merchant commission tab")
                .HasColumnType("double(12,4)")
                .HasColumnName("pay_by_token_fee");
            entity.Property(e => e.PaymentCompletedBy)
                .HasDefaultValueSql("'1'")
                .HasComment("This is the source to know the initiator of completePayment (2nd step) of a payment model\r\nComplete Payment By\r\n1 = App\r\n2 = Merchant\r\n")
                .HasColumnName("payment_completed_by");
            entity.Property(e => e.PaymentFrequency)
                .HasDefaultValueSql("'0'")
                .HasColumnName("payment_frequency");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.PaymentSource)
                .HasComment("1=3D branding and paid by CC, 2= 2D branding and paid by CC, 3 = Mobile payment, 4 = wallet payment, 5 = white label 3D, 6=whiite label 2D, 7 = Redirected white label 3D, 8 = Redirected white label 2D, 9 = DPL 3d, 10 = DPL 2d, 21 = Payment from Wix")
                .HasColumnName("payment_source");
            entity.Property(e => e.PaymentTypeId)
                .HasComment("1=>credit card, 2=> mobile, 3=>wallet, 4=>depositEFT")
                .HasColumnName("payment_type_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.PosName)
                .HasMaxLength(50)
                .HasColumnName("pos_name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("double(12,4)")
                .HasColumnName("product_price");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.RecurringId)
                .HasComment("0 = Sale, 1 = Recurring, 2 = DPL")
                .HasColumnName("recurring_id");
            entity.Property(e => e.RefundReason)
                .HasMaxLength(255)
                .HasColumnName("refund_reason");
            entity.Property(e => e.RefundRequestAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_request_amount");
            entity.Property(e => e.RefundRequestDate)
                .HasColumnType("timestamp")
                .HasColumnName("refund_request_date");
            entity.Property(e => e.RefundedChargebackFee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("refunded_chargeback_fee");
            entity.Property(e => e.RemoteOrderId)
                .HasMaxLength(40)
                .HasColumnName("remote_order_id");
            entity.Property(e => e.RemoteTransactionDatetime)
                .HasColumnType("datetime")
                .HasColumnName("remote_transaction_datetime");
            entity.Property(e => e.Result)
                .HasMaxLength(255)
                .HasColumnName("result");
            entity.Property(e => e.RollingAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("rolling_amount");
            entity.Property(e => e.SaleType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=auth , 2=PreAuth")
                .HasColumnName("sale_type");
            entity.Property(e => e.SaleVersion)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_version");
            entity.Property(e => e.SaleWebHookKey)
                .HasMaxLength(100)
                .HasColumnName("sale_web_hook_key");
            entity.Property(e => e.SettlementDateBank)
                .HasColumnType("datetime")
                .HasColumnName("settlement_date_bank");
            entity.Property(e => e.SettlementDateMerchant)
                .HasColumnType("datetime")
                .HasColumnName("settlement_date_merchant");
            entity.Property(e => e.TotalRefundedAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("total_refunded_amount");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedAtInt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_at_int");
            entity.Property(e => e.UserCommission)
                .HasColumnType("double(12,4)")
                .HasColumnName("user_commission");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<SaleActiveFraud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_active_frauds")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(16, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("amount");
            entity.Property(e => e.CardNo)
                .HasComment("card no stored with masking")
                .HasColumnType("text")
                .HasColumnName("card_no");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantName)
                .HasColumnType("text")
                .HasColumnName("merchant_name");
            entity.Property(e => e.RequestInputs)
                .HasComment("requests inputs param except card info")
                .HasColumnName("request_inputs");
            entity.Property(e => e.RuleName)
                .HasComment("fraud rule name")
                .HasColumnType("text")
                .HasColumnName("rule_name");
            entity.Property(e => e.Score)
                .HasPrecision(12, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("score");
            entity.Property(e => e.Severity)
                .HasColumnType("double(12,4)")
                .HasColumnName("severity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasColumnType("text")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<SaleAsynchronousProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_asynchronous_processes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Status, "status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityTitle)
                .HasMaxLength(50)
                .HasColumnName("activity_title");
            entity.Property(e => e.BillingData)
                .HasColumnType("text")
                .HasColumnName("billing_data");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyObj)
                .HasColumnType("text")
                .HasColumnName("currency_obj");
            entity.Property(e => e.DplObj)
                .HasColumnType("text")
                .HasColumnName("dpl_obj");
            entity.Property(e => e.ExceptionMessage)
                .HasColumnType("text")
                .HasColumnName("exception_message");
            entity.Property(e => e.Extras)
                .HasColumnType("text")
                .HasColumnName("extras");
            entity.Property(e => e.IsLastRow).HasColumnName("is_last_row");
            entity.Property(e => e.MerchantObj)
                .HasColumnType("text")
                .HasColumnName("merchant_obj");
            entity.Property(e => e.MerchantSettingObj)
                .HasColumnType("text")
                .HasColumnName("merchant_setting_obj");
            entity.Property(e => e.PlanCode)
                .HasMaxLength(100)
                .HasColumnName("plan_code");
            entity.Property(e => e.PurchaseRequestObj)
                .HasColumnType("text")
                .HasColumnName("purchase_request_obj");
            entity.Property(e => e.SaleData)
                .HasColumnType("text")
                .HasColumnName("sale_data");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleObj)
                .HasColumnType("text")
                .HasColumnName("sale_obj");
            entity.Property(e => e.SaleType)
                .HasDefaultValueSql("'1'")
                .HasComment("1= Auth, 2= PreAuth")
                .HasColumnName("sale_type");
            entity.Property(e => e.Status)
                .HasComment("0=not processed yet, 1=processed 2=notify about exception")
                .HasColumnName("status");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserObj)
                .HasColumnType("text")
                .HasColumnName("user_obj");
        });

        modelBuilder.Entity<SaleBilling>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_billings")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.MigrationStatus, "migration_status");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillAddress1)
                .HasMaxLength(100)
                .HasColumnName("bill_address1")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillAddress2)
                .HasMaxLength(100)
                .HasColumnName("bill_address2")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillCity)
                .HasMaxLength(30)
                .HasColumnName("bill_city")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillCountry)
                .HasMaxLength(20)
                .HasColumnName("bill_country")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillEmail)
                .HasMaxLength(50)
                .HasColumnName("bill_email")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillName)
                .HasMaxLength(70)
                .HasColumnName("bill_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillPhone)
                .HasMaxLength(20)
                .HasColumnName("bill_phone")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillPostcode)
                .HasMaxLength(10)
                .HasColumnName("bill_postcode")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillState)
                .HasMaxLength(30)
                .HasColumnName("bill_state")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BillSurname)
                .HasMaxLength(90)
                .HasColumnName("bill_surname")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillTaxNo)
                .HasMaxLength(100)
                .HasColumnName("bill_tax_no")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillTaxOffice)
                .HasMaxLength(150)
                .HasColumnName("bill_tax_office")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.BillTckn)
                .HasMaxLength(50)
                .HasColumnName("bill_tckn")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(100)
                .HasColumnName("card_holder_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(70)
                .HasColumnName("card_number")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasComment("created by merchant user id")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(191)
                .HasComment("created by merchant user name")
                .HasColumnName("created_by_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CustomerType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("customer_type");
            entity.Property(e => e.Cvv)
                .HasMaxLength(50)
                .HasColumnName("cvv")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ExpiryMonth)
                .HasMaxLength(50)
                .HasColumnName("expiry_month")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ExpiryYear)
                .HasMaxLength(50)
                .HasColumnName("expiry_year")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ExtraCardHolderName)
                .HasMaxLength(120)
                .HasDefaultValueSql("''")
                .HasColumnName("extra_card_holder_name")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleCurrencyConversion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sale_currency_conversions");

            entity.HasIndex(e => e.OrderId, "order_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConversionRate)
                .HasColumnType("double(12,4)")
                .HasColumnName("conversion_rate");
            entity.Property(e => e.ConversionType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=normal conversion,2=dcc conversion")
                .HasColumnName("conversion_type");
            entity.Property(e => e.ConvertedAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("converted_amount");
            entity.Property(e => e.ConvertedTotalRefundedAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("converted_total_refunded_amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FromCurrency)
                .HasMaxLength(3)
                .HasColumnName("from_currency");
            entity.Property(e => e.FromPosId).HasColumnName("from_pos_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MigrationStatus).HasColumnName("migration_status");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("order_id");
            entity.Property(e => e.OriginalAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("original_amount");
            entity.Property(e => e.ToCurrency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("to_currency");
            entity.Property(e => e.ToPosId).HasColumnName("to_pos_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleErrorDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_error_details")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(20)
                .HasColumnName("auth_code");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name");
            entity.Property(e => e.BrandErrorCode)
                .HasMaxLength(10)
                .HasColumnName("brand_error_code");
            entity.Property(e => e.BrandErrorMessage)
                .HasMaxLength(255)
                .HasColumnName("brand_error_message");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(255)
                .HasColumnName("currency_code");
            entity.Property(e => e.HostMessage)
                .HasMaxLength(255)
                .HasColumnName("host_message");
            entity.Property(e => e.HostReferenceId)
                .HasMaxLength(40)
                .HasColumnName("host_reference_id");
            entity.Property(e => e.MaskedCard)
                .HasMaxLength(70)
                .HasColumnName("masked_card");
            entity.Property(e => e.MdErrorMessage)
                .HasMaxLength(255)
                .HasColumnName("md_error_message");
            entity.Property(e => e.MdStatus)
                .HasMaxLength(4)
                .HasComment("mdStatus from bank response ranges from 0-9 0: Card verification failed, do not proceed 1: Verification successful, you can continue with the transaction 2: Card holder or bank is not registered in the system 3: The bank of the card is not registered in the system 4: Verification attempt, cardholder has chosen to register with the system later 5: Unable to verify 6: 3-D Secure error 7: System error 8: Unknown card no 9: Member Merchant not registered to 3D-Secure system (merchant or terminal number is not registered on the back as 3d)")
                .HasColumnName("md_status");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.OriginalBankErrorCode)
                .HasMaxLength(10)
                .HasColumnName("original_bank_error_code");
            entity.Property(e => e.OriginalBankErrorDescription)
                .HasMaxLength(255)
                .HasColumnName("original_bank_error_description");
            entity.Property(e => e.ProcReturnCode)
                .HasMaxLength(5)
                .HasColumnName("proc_return_code");
            entity.Property(e => e.Provider)
                .HasMaxLength(30)
                .HasColumnName("provider");
            entity.Property(e => e.RemoteOrderId)
                .HasMaxLength(40)
                .HasColumnName("remote_order_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.TransactionType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=auth , 2=PreAuth")
                .HasColumnName("transaction_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleFailAlert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_fail_alerts")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentNoOfFailedAttempt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("current_no_of_failed_attempt");
            entity.Property(e => e.MaxNoOfFailedAttempt)
                .HasDefaultValueSql("'10'")
                .HasColumnName("max_no_of_failed_attempt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleFraud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_frauds")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AapprovedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("aapproved_datetime");
            entity.Property(e => e.ApprovedById).HasColumnName("approved_by_id");
            entity.Property(e => e.ApprovedByName)
                .HasMaxLength(100)
                .HasColumnName("approved_by_name");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");
            entity.Property(e => e.Remarks)
                .HasComment("format: rule_name - rule_description")
                .HasColumnType("text")
                .HasColumnName("remarks")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.RuleName)
                .HasComment("Single role name , or multiple rule name by comma separator")
                .HasColumnType("text")
                .HasColumnName("rule_name");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Score)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("Single score , or multiple score by adding")
                .HasColumnType("double(12,4)")
                .HasColumnName("score");
            entity.Property(e => e.Severity)
                .HasColumnType("double(12,4)")
                .HasColumnName("severity");
            entity.Property(e => e.Status)
                .HasComment("1=completed, 2=rejected, 3=pending")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleFraudRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_fraud_records")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FraudRuleId)
                .HasComment("id of fraud_rules")
                .HasColumnName("fraud_rule_id");
            entity.Property(e => e.SaleFraudId)
                .HasComment("id of sale_frauds")
                .HasColumnName("sale_fraud_id");
            entity.Property(e => e.Score)
                .HasComment("1 - 100")
                .HasColumnName("score");
            entity.Property(e => e.Severity)
                .HasComment("0 = Please Select, 1 = Low, 2 = Medium, 3 = High")
                .HasColumnName("severity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleInfoOutgoingReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_info_outgoing_report")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.SaleId, "sale_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Exception)
                .HasMaxLength(255)
                .HasComment("when we found any exception to connect with another database")
                .HasColumnName("exception");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasComment("sales table order_id")
                .HasColumnName("order_id");
            entity.Property(e => e.SaleId)
                .HasComment("sales table id")
                .HasColumnName("sale_id");
            entity.Property(e => e.SaleInfo)
                .HasComment("sale info should be stored as json")
                .HasColumnType("text")
                .HasColumnName("sale_info");
        });

        modelBuilder.Entity<SaleIntegrator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_integrators")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CommissionAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_amount");
            entity.Property(e => e.CommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_fixed");
            entity.Property(e => e.CommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IntegratorId).HasColumnName("integrator_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SalePosRedirection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_pos_redirections")
                .HasCharSet("utf16")
                .UseCollation("utf16_unicode_ci");

            entity.Property(e => e.Id)
                .HasComment("N/A")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasComment("N/A")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FromPosId)
                .HasComment("N/A")
                .HasColumnName("from_pos_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.SaleId)
                .HasComment("N/A")
                .HasColumnName("sale_id");
            entity.Property(e => e.ToPosId)
                .HasComment("N/A")
                .HasColumnName("to_pos_id");
        });

        modelBuilder.Entity<SaleProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sale_properties");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankInstallmentNumber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bank_installment_number");
            entity.Property(e => e.CardBrand)
                .HasDefaultValueSql("'0'")
                .HasComment("'7' => 'Any', '1' => 'Visa', '2' => 'Master Card', '3' => 'Amex', '4' => 'Diners', '5' => 'Discover', '6' => 'JCB'")
                .HasColumnName("card_brand");
            entity.Property(e => e.CardCountryCode)
                .HasMaxLength(3)
                .HasColumnName("card_country_code");
            entity.Property(e => e.CardInfo)
                .HasColumnType("text")
                .HasColumnName("card_info");
            entity.Property(e => e.CardNo)
                .HasMaxLength(70)
                .HasColumnName("card_no");
            entity.Property(e => e.CardType)
                .HasDefaultValueSql("'0'")
                .HasComment("1=credit card, 2= debit card")
                .HasColumnName("card_type");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .HasColumnName("country_code");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("currency_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasComment("Description of the transaction if exists.")
                .HasColumnName("description");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(10)
                .HasComment("INSUFFICIENT_FUNDS = 51, LOST_CARD = 41, STOLEN_CARD = 43, HOLD_CARD = 07, EXPIRED_CARD = 54, DECLINED_CVV = 82")
                .HasColumnName("error_code")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Gross)
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.Ip)
                .HasMaxLength(45)
                .HasColumnName("ip");
            entity.Property(e => e.IsProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_processed");
            entity.Property(e => e.Mcc)
                .HasMaxLength(255)
                .HasColumnName("mcc");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantServerId)
                .HasMaxLength(45)
                .HasColumnName("merchant_server_id")
                .UseCollation("utf8mb3_general_ci");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.PaymentSource)
                .HasDefaultValueSql("'0'")
                .HasColumnName("payment_source");
            entity.Property(e => e.PaymentTypeId)
                .HasComment("1=>credit card, 2=> mobile, 3=>wallet, 4=>All")
                .HasColumnName("payment_type_id");
            entity.Property(e => e.PlusInstallment)
                .HasDefaultValueSql("'0'")
                .HasComment("plus installment for pos campaign")
                .HasColumnName("plus_installment");
            entity.Property(e => e.PreAuthAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("pre_auth_amount");
            entity.Property(e => e.RefererUrl)
                .HasMaxLength(255)
                .HasColumnName("referer_url")
                .UseCollation("utf16_unicode_ci")
                .HasCharSet("utf16");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleTransactionStateId).HasColumnName("sale_transaction_state_id");
        });

        modelBuilder.Entity<SaleRecurring>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_recurrings")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.CardNo)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'")
                .HasColumnName("card_no");
            entity.Property(e => e.CardUserKey)
                .HasMaxLength(100)
                .HasColumnName("card_user_key");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.Count)
                .HasDefaultValueSql("'1'")
                .HasColumnName("count");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.FirstAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("first_amount");
            entity.Property(e => e.FirstOrderId)
                .HasMaxLength(255)
                .HasColumnName("first_order_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MigrationStatus).HasColumnName("migration_status");
            entity.Property(e => e.NextActionDate)
                .HasColumnType("datetime")
                .HasColumnName("next_action_date");
            entity.Property(e => e.PaymentCycle)
                .HasMaxLength(2)
                .HasComment("D=>Day, W=>Week, M=Month, Y=Year")
                .HasColumnName("payment_cycle");
            entity.Property(e => e.PaymentInterval)
                .HasDefaultValueSql("'1'")
                .HasComment("In how many days/week/month/year it will be executed again")
                .HasColumnName("payment_interval");
            entity.Property(e => e.PaymentNumber)
                .HasComment("Number of time(frequency), amount will be deducted")
                .HasColumnName("payment_number");
            entity.Property(e => e.PlanCode)
                .HasMaxLength(16)
                .HasColumnName("plan_code");
            entity.Property(e => e.RecurringAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("recurring_amount");
            entity.Property(e => e.RecurringWebHookKey)
                .HasMaxLength(100)
                .HasColumnName("recurring_web_hook_key")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive")
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("total_amount");
            entity.Property(e => e.Type)
                .HasComment("1 = inactive by failed payment number exceed by cronjobb\r\n2 = completed all recurring by cronjob \r\n3 = inactivated by admin\r\n4 = inactivated by merchant\r\n5 = inactivated by API\r\n0 = not set")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleRecurringCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_recurring_cards")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardToken)
                .HasMaxLength(255)
                .HasColumnName("card_token");
            entity.Property(e => e.CardUserKey)
                .HasMaxLength(255)
                .HasColumnName("card_user_key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SaleRecurringId).HasColumnName("sale_recurring_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive, 1=active")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleRecurringHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_recurring_histories")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.SaleId, "sale_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("action_date");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.Attempts)
                .HasDefaultValueSql("'1'")
                .HasColumnName("attempts");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.RecurringNumber)
                .HasDefaultValueSql("'1'")
                .HasColumnName("recurring_number");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasColumnName("remarks");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleRecurringId).HasColumnName("sale_recurring_id");
            entity.Property(e => e.SaleRecurringPaymentScheduleId).HasColumnName("sale_recurring_payment_schedule_id");
            entity.Property(e => e.Status)
                .HasComment("1 => pass, 0 => Fail")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleRecurringPaymentSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_recurring_payment_schedules")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionDate).HasColumnName("action_date");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LastAttemptDate)
                .HasColumnType("datetime")
                .HasColumnName("last_attempt_date");
            entity.Property(e => e.NumberOfFailedCount)
                .HasComment("for failed attempt count")
                .HasColumnName("number_of_failed_count");
            entity.Property(e => e.RecurringNumber).HasColumnName("recurring_number");
            entity.Property(e => e.SaleRecurringId).HasColumnName("sale_recurring_id");
            entity.Property(e => e.Status)
                .HasComment("0=not processed yet, 1= already processed")
                .HasColumnName("status");
        });

        modelBuilder.Entity<SaleReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_reports")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.SaleId, "sale_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.CashbackAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("cashback_amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId)
                .HasDefaultValueSql("'1'")
                .HasComment("1=Unknown, 2=Windows, 3=Linux, 4=MAC, 5=IOS, 6=Android")
                .HasColumnName("device_id");
            entity.Property(e => e.FpWalletUserFee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fp_wallet_user_fee");
            entity.Property(e => e.IntegratorEmail)
                .HasMaxLength(50)
                .HasColumnName("integrator_email");
            entity.Property(e => e.IntegratorFirstName)
                .HasMaxLength(100)
                .HasColumnName("integrator_first_name");
            entity.Property(e => e.IntegratorIntegratorName)
                .HasMaxLength(50)
                .HasColumnName("integrator_integrator_name");
            entity.Property(e => e.IntegratorLastName)
                .HasMaxLength(50)
                .HasColumnName("integrator_last_name");
            entity.Property(e => e.IntegratorPhone)
                .HasMaxLength(20)
                .HasColumnName("integrator_phone");
            entity.Property(e => e.Ipv4CountryName)
                .HasMaxLength(100)
                .HasColumnName("ipv4_country_name");
            entity.Property(e => e.MerchantContactPersonEmail)
                .HasMaxLength(100)
                .HasColumnName("merchant_contact_person_email");
            entity.Property(e => e.MerchantMcc)
                .HasMaxLength(5)
                .HasColumnName("merchant_mcc");
            entity.Property(e => e.MerchantSaleCardType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_sale_card_type");
            entity.Property(e => e.MerchantSaleChargebackCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_chargeback_commission");
            entity.Property(e => e.MerchantSaleChargebackCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_chargeback_commission_fixed");
            entity.Property(e => e.MerchantSaleCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_cot_fixed");
            entity.Property(e => e.MerchantSaleCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_cot_percentage");
            entity.Property(e => e.MerchantSaleEffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("merchant_sale_effective_date");
            entity.Property(e => e.MerchantSaleEndUserCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_end_user_commission_fixed");
            entity.Property(e => e.MerchantSaleEndUserCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_end_user_commission_percentage");
            entity.Property(e => e.MerchantSaleMerchantCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_merchant_commission_fixed");
            entity.Property(e => e.MerchantSaleMerchantCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_merchant_commission_percentage");
            entity.Property(e => e.MerchantSaleMerchantRollingPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_merchant_rolling_percentage");
            entity.Property(e => e.MerchantSalePayByTokenCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_pay_by_token_commission");
            entity.Property(e => e.MerchantSalePayByTokenFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_pay_by_token_fixed");
            entity.Property(e => e.MerchantSaleRefundCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_refund_commission");
            entity.Property(e => e.MerchantSaleRefundCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_sale_refund_commission_fixed");
            entity.Property(e => e.MerchantSaleReportingSettlementDate)
                .HasColumnType("datetime")
                .HasColumnName("merchant_sale_reporting_settlement_date");
            entity.Property(e => e.MerchantTckn)
                .HasMaxLength(50)
                .HasColumnName("merchant_tckn");
            entity.Property(e => e.MerchantTerminalId)
                .HasMaxLength(50)
                .HasComment("Imported Transaction Merchant Terminal Id")
                .HasColumnName("merchant_terminal_id");
            entity.Property(e => e.MerchantType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("merchant_type");
            entity.Property(e => e.MerchantVkn)
                .HasMaxLength(50)
                .HasColumnName("merchant_vkn");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.RemoteAcquirerReference)
                .HasMaxLength(100)
                .HasComment("Remote(Pavo, Oxivo) Transaction Acquirer Reference")
                .HasColumnName("remote_acquirer_reference");
            entity.Property(e => e.RemoteBkmSerialNo)
                .HasMaxLength(100)
                .HasColumnName("remote_bkm_serial_no");
            entity.Property(e => e.RemoteOperationName)
                .HasMaxLength(100)
                .HasComment("Remote(Pavo, Oxivo) Transaction Operation Type Name")
                .HasColumnName("remote_operation_name");
            entity.Property(e => e.RemoteProductPrice)
                .HasComment("Remote(Pavo, Oxivo) Transaction Product Price")
                .HasColumnType("double(12,4)")
                .HasColumnName("remote_product_price");
            entity.Property(e => e.RemoteSaleReferenceId)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("remote_sale_reference_id");
            entity.Property(e => e.RollingBalanceAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("rolling_balance_amount");
            entity.Property(e => e.RollingBalanceEffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("rolling_balance_effective_date");
            entity.Property(e => e.SaleBillingBillAddress1)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_bill_address1");
            entity.Property(e => e.SaleBillingBillAddress2)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_bill_address2");
            entity.Property(e => e.SaleBillingBillCity)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_bill_city");
            entity.Property(e => e.SaleBillingBillCountry)
                .HasMaxLength(20)
                .HasColumnName("sale_billing_bill_country");
            entity.Property(e => e.SaleBillingBillEmail)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_bill_email");
            entity.Property(e => e.SaleBillingBillName)
                .HasMaxLength(70)
                .HasColumnName("sale_billing_bill_name");
            entity.Property(e => e.SaleBillingBillPhone)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_bill_phone");
            entity.Property(e => e.SaleBillingBillPostcode)
                .HasMaxLength(10)
                .HasColumnName("sale_billing_bill_postcode");
            entity.Property(e => e.SaleBillingBillState)
                .HasMaxLength(30)
                .HasColumnName("sale_billing_bill_state");
            entity.Property(e => e.SaleBillingBillSurname)
                .HasMaxLength(90)
                .HasColumnName("sale_billing_bill_surname");
            entity.Property(e => e.SaleBillingBillTaxNo)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_bill_tax_no");
            entity.Property(e => e.SaleBillingBillTaxOffice)
                .HasMaxLength(150)
                .HasColumnName("sale_billing_bill_tax_office");
            entity.Property(e => e.SaleBillingBillTckn)
                .HasMaxLength(50)
                .HasColumnName("sale_billing_bill_tckn");
            entity.Property(e => e.SaleBillingCardHolderName)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_card_holder_name");
            entity.Property(e => e.SaleBillingCreatedBy).HasColumnName("sale_billing_created_by");
            entity.Property(e => e.SaleBillingCreatedByName)
                .HasMaxLength(100)
                .HasColumnName("sale_billing_created_by_name");
            entity.Property(e => e.SaleBillingCustomerType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_billing_customer_type");
            entity.Property(e => e.SaleBillingExtraCardHolderName)
                .HasMaxLength(120)
                .HasDefaultValueSql("''")
                .HasColumnName("sale_billing_extra_card_holder_name");
            entity.Property(e => e.SaleCurrencyConversionConversionRate)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_currency_conversion_conversion_rate");
            entity.Property(e => e.SaleCurrencyConversionConversionType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=normal conversion,2=dcc conversion")
                .HasColumnName("sale_currency_conversion_conversion_type");
            entity.Property(e => e.SaleCurrencyConversionConvertedAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_currency_conversion_converted_amount");
            entity.Property(e => e.SaleCurrencyConversionConvertedTotalRefundedAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_currency_conversion_converted_total_refunded_amount");
            entity.Property(e => e.SaleCurrencyConversionCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("sale_currency_conversion_created_at");
            entity.Property(e => e.SaleCurrencyConversionFromCurrency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_currency_conversion_from_currency");
            entity.Property(e => e.SaleCurrencyConversionFromPosId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_currency_conversion_from_pos_id");
            entity.Property(e => e.SaleCurrencyConversionOriginalAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_currency_conversion_original_amount");
            entity.Property(e => e.SaleCurrencyConversionToCurrency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_currency_conversion_to_currency");
            entity.Property(e => e.SaleCurrencyConversionToPosId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_currency_conversion_to_pos_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleIntegratorAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_integrator_amount");
            entity.Property(e => e.SaleIntegratorCommissionAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_integrator_commission_amount");
            entity.Property(e => e.SaleIntegratorCommissionFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_integrator_commission_fixed");
            entity.Property(e => e.SaleIntegratorCommissionPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_integrator_commission_percentage");
            entity.Property(e => e.SaleIntegratorIntegratorId)
                .HasComment("Integrator_id from sale_integrators")
                .HasColumnName("sale_integrator_integrator_id");
            entity.Property(e => e.SalePropertyBankInstallmentNumber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_property_bank_installment_number");
            entity.Property(e => e.SalePropertyCardCountryCode)
                .HasMaxLength(3)
                .HasColumnName("sale_property_card_country_code");
            entity.Property(e => e.SalePropertyCardType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_property_card_type");
            entity.Property(e => e.SalePropertyErrorCode)
                .HasMaxLength(10)
                .HasColumnName("sale_property_error_code");
            entity.Property(e => e.SalePropertyMerchantServerId)
                .HasMaxLength(45)
                .HasColumnName("sale_property_merchant_server_id");
            entity.Property(e => e.SalePropertyPlusInstallment)
                .HasDefaultValueSql("'0'")
                .HasComment("plus installment for pos campaign")
                .HasColumnName("sale_property_plus_installment");
            entity.Property(e => e.SalePropertyPreAuthAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_property_pre_auth_amount");
            entity.Property(e => e.SalePropertyRefererUrl)
                .HasMaxLength(255)
                .HasColumnName("sale_property_referer_url");
            entity.Property(e => e.SaleRecurringHistoryRecurringNumber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_recurring_history_recurring_number");
            entity.Property(e => e.SaleRecurringPaymentNumber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sale_recurring_payment_number");
            entity.Property(e => e.SaleRecurringPlanCode)
                .HasMaxLength(50)
                .HasColumnName("sale_recurring_plan_code");
            entity.Property(e => e.SaleTaxInfoBankInsuranceTaxDividend)
                .HasDefaultValueSql("'1.0500'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_tax_info_bank_insurance_tax_dividend");
            entity.Property(e => e.SaleTaxInfoBankInsuranceTaxMultiplier)
                .HasDefaultValueSql("'0.0500'")
                .HasColumnType("double(12,4)")
                .HasColumnName("sale_tax_info_bank_insurance_tax_multiplier");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserEndUserEmail)
                .HasMaxLength(100)
                .HasColumnName("user_end_user_email");
            entity.Property(e => e.UserEndUserFirstName)
                .HasMaxLength(100)
                .HasColumnName("user_end_user_first_name");
            entity.Property(e => e.UserEndUserLastName)
                .HasMaxLength(100)
                .HasColumnName("user_end_user_last_name");
            entity.Property(e => e.UserEndUserPhone)
                .HasMaxLength(100)
                .HasColumnName("user_end_user_phone");
            entity.Property(e => e.UserEndUserTcNumber)
                .HasMaxLength(50)
                .HasColumnName("user_end_user_tc_number");
            entity.Property(e => e.UserEndUserUserCategory).HasColumnName("user_end_user_user_category");
            entity.Property(e => e.UserMerchantUserEmail)
                .HasMaxLength(100)
                .HasColumnName("user_merchant_user_email");
            entity.Property(e => e.UserMerchantUserFirstName)
                .HasMaxLength(100)
                .HasColumnName("user_merchant_user_first_name");
            entity.Property(e => e.UserMerchantUserLastName)
                .HasMaxLength(100)
                .HasColumnName("user_merchant_user_last_name");
            entity.Property(e => e.UserMerchantUserPhone)
                .HasMaxLength(100)
                .HasColumnName("user_merchant_user_phone");
            entity.Property(e => e.UserMerchantUserTcNumber)
                .HasMaxLength(100)
                .HasColumnName("user_merchant_user_tc_number");
        });

        modelBuilder.Entity<SaleTaxInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_tax_info")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankInsuranceTaxDividend)
                .HasColumnType("double(8,2)")
                .HasColumnName("bank_insurance_tax_dividend");
            entity.Property(e => e.BankInsuranceTaxMultiplier)
                .HasColumnType("double(8,2)")
                .HasColumnName("bank_insurance_tax_multiplier");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SaleWalletHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sale_wallet_histories")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.NonWithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("non_withdrawable_amount");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("withdrawable_amount");
        });

        modelBuilder.Entity<SalesPfRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sales_pf_records")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.OrderId, "order_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankLandingStatus)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not landend for same order id, 1= already landed for same order id")
                .HasColumnName("bank_landing_status");
            entity.Property(e => e.ClientIdentityNumber)
                .HasMaxLength(20)
                .HasComment("Identity number from Insurance Payment / Pay By TCKN")
                .HasColumnName("client_identity_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdentityNin)
                .HasMaxLength(20)
                .HasColumnName("identity_nin")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Mcc)
                .HasMaxLength(10)
                .HasComment("mcc")
                .HasColumnName("mcc");
            entity.Property(e => e.MerchantId)
                .HasMaxLength(20)
                .HasColumnName("merchant_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PfMerchantId)
                .HasMaxLength(50)
                .HasColumnName("pf_merchant_id");
            entity.Property(e => e.PfMerchantName)
                .HasMaxLength(100)
                .HasColumnName("pf_merchant_name");
            entity.Property(e => e.SubMerchantId)
                .HasMaxLength(80)
                .HasColumnName("sub_merchant_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Version)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = older than 8th nov 2022, \r\n2= new after this date")
                .HasColumnName("version");
        });

        modelBuilder.Entity<SalesSettlement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sales_settlements")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.SaleId, e.InstallmentsNumber }, "sale_id_installments_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.InstallmentsNumber)
                .HasComment("1st, 2nd, 3rd ... nth installment")
                .HasColumnName("installments_number");
            entity.Property(e => e.IsFullyRefunded)
                .HasDefaultValueSql("'0'")
                .HasComment("indicates whether this indicates whether this settlement is fully refunded")
                .HasColumnName("is_fully_refunded");
            entity.Property(e => e.MerchantCommission)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_commission");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.NetSettlement)
                .HasComment("merchant net divided by installments_number")
                .HasColumnType("double(12,4)")
                .HasColumnName("net_settlement");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RefundHistoryId)
                .HasComment("id from refund_histories")
                .HasColumnName("refund_history_id");
            entity.Property(e => e.RefundRequestAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("refund request amount from refund")
                .HasColumnType("double(12,4)")
                .HasColumnName("refund_request_amount");
            entity.Property(e => e.RefundedAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("refunded amount from a refund")
                .HasColumnType("double(12,4)")
                .HasColumnName("refunded_amount");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SettledAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("settled_amount");
            entity.Property(e => e.SettlementDateBank)
                .HasColumnType("datetime")
                .HasColumnName("settlement_date_bank");
            entity.Property(e => e.SettlementDateMerchant)
                .HasColumnType("datetime")
                .HasColumnName("settlement_date_merchant");
            entity.Property(e => e.Status)
                .HasComment("0 = not settled, 1 = Settled")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SavedCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("saved_cards")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bank_id");
            entity.Property(e => e.BrandToken)
                .HasMaxLength(100)
                .HasColumnName("brand_token");
            entity.Property(e => e.CardIssuerBank)
                .HasMaxLength(60)
                .HasColumnName("card_issuer_bank");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(20)
                .HasColumnName("card_number")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CardToken)
                .HasMaxLength(255)
                .HasColumnName("card_token")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CardUserKey)
                .HasMaxLength(255)
                .HasComment("For Craft Grate Api")
                .HasColumnName("card_user_key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(50)
                .HasColumnName("customer_email")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("customer_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(50)
                .HasColumnName("customer_number")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(50)
                .HasColumnName("customer_phone")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sectors");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.NameTr)
                .HasMaxLength(150)
                .HasColumnName("name_tr");
            entity.Property(e => e.Status)
                .HasComment("0=inactive; 1=active")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'2'")
                .HasComment("0=customer; 2=merchant")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SecurityImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("security_images")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(10)
                .HasColumnName("brand_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(100)
                .HasColumnName("image_path");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = active, 0 = inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Send>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sends")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.HasIndex(e => e.UniqueId, "unique_id").IsUnique();

            entity.HasIndex(e => e.UniqueString, "unique_string").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.AdminProcessDate)
                .HasColumnType("timestamp")
                .HasColumnName("admin_process_date");
            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .HasColumnName("bank_name");
            entity.Property(e => e.BankStaticId).HasColumnName("bank_static_id");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Net)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.NonWithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("non_withdrawable_amount");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.ReceiveId).HasColumnName("receive_id");
            entity.Property(e => e.ReceiverMerchantId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("receiver_merchant_id");
            entity.Property(e => e.ReceiverMerchantName)
                .HasMaxLength(100)
                .HasColumnName("receiver_merchant_name");
            entity.Property(e => e.SendType)
                .HasDefaultValueSql("'1'")
                .HasComment("1 -> send money 2 -> B2B Payment 3-> B2C Payment 4 -> to_non_supay 5 -> to_banks 6 -> C2B payment 7 -> Request Money, 8 -> B2U Payment, 9 -> C2C Cashout To Bank, 10 -> Send Money To Walletgate, 11 -> Reverted Split Account Send Money")
                .HasColumnName("send_type");
            entity.Property(e => e.ToGsmNumber)
                .HasMaxLength(50)
                .HasColumnName("to_gsm_number");
            entity.Property(e => e.ToId).HasColumnName("to_id");
            entity.Property(e => e.ToName)
                .HasMaxLength(100)
                .HasColumnName("to_name");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UniqueId)
                .HasMaxLength(50)
                .HasColumnName("unique_id");
            entity.Property(e => e.UniqueString).HasColumnName("unique_string");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserGsmNumber)
                .HasMaxLength(50)
                .HasColumnName("user_gsm_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
            entity.Property(e => e.WithdrawableAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("withdrawable_amount");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("service_types")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.NameTr)
                .HasMaxLength(100)
                .HasColumnName("name_tr")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("settings")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Key, "settings_key_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminName)
                .HasMaxLength(255)
                .HasColumnName("admin_name");
            entity.Property(e => e.AdminPhone)
                .HasMaxLength(50)
                .HasColumnName("admin_phone");
            entity.Property(e => e.Advertisment)
                .HasColumnType("text")
                .HasColumnName("advertisment")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.CompanyAddress)
                .HasColumnType("text")
                .HasColumnName("company_address");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(191)
                .HasColumnName("display_name");
            entity.Property(e => e.FaviconPath)
                .HasMaxLength(255)
                .HasColumnName("favicon_path");
            entity.Property(e => e.Footer)
                .HasColumnType("text")
                .HasColumnName("footer");
            entity.Property(e => e.FooterTr)
                .HasMaxLength(255)
                .HasComment("Admin panel footer copyright area tr version")
                .HasColumnName("footer_tr");
            entity.Property(e => e.Group)
                .HasMaxLength(191)
                .HasColumnName("group");
            entity.Property(e => e.Key)
                .HasMaxLength(191)
                .HasColumnName("key");
            entity.Property(e => e.LogoPath)
                .HasColumnType("text")
                .HasColumnName("logo_path");
            entity.Property(e => e.MetaTag)
                .HasMaxLength(255)
                .HasColumnName("meta_tag");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'1'")
                .HasColumnName("order");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasColumnType("text")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Settlement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("settlements")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .HasColumnName("code")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.NameTr)
                .HasMaxLength(40)
                .HasColumnName("name_tr")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment(" (1=active, 0=inactive)")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasMaxLength(30)
                .HasColumnName("value")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<SinglePaymentMerchantCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("single_payment_merchant_commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Id, "single_payment_merchant_commissions_id_uindex").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.CardType)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Debit Card, 2 => Credit Card")
                .HasColumnName("card_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(100)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EndUserCommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_fixed");
            entity.Property(e => e.EndUserCommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("end_user_commission_percentage");
            entity.Property(e => e.IssuerName)
                .HasMaxLength(100)
                .HasColumnName("issuer_name");
            entity.Property(e => e.MerchantCommissionFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_commission_fixed");
            entity.Property(e => e.MerchantCommissionPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_commission_percentage");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Active, 2 => Inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UpdatedByName)
                .HasMaxLength(100)
                .HasColumnName("updated_by_name");
        });

        modelBuilder.Entity<SmsArchive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sms_archive")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content")
                .UseCollation("utf32_general_ci")
                .HasCharSet("utf32");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Provider)
                .HasMaxLength(15)
                .HasColumnName("provider");
            entity.Property(e => e.Response)
                .HasMaxLength(255)
                .HasColumnName("response")
                .UseCollation("utf32_general_ci")
                .HasCharSet("utf32");
            entity.Property(e => e.ToGsm)
                .HasMaxLength(20)
                .HasColumnName("to_gsm");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasComment("0=>customer; 1=>admin; 2=>merchant; 3=>submerchant")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<SplitAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("split_accounts")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.NumberOfMember).HasColumnName("number_of_member");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SenderAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("sender_amount");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.Status)
                .HasComment("0 = no one paid, 1 = some paid, 2 = all paid, 3 = expired")
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<StaticContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("static_contents")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasComment("user aggreement, policy, faq")
                .HasColumnName("category_name")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_user_id");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .HasComment("en, tr")
                .HasColumnName("language_code")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.SectionContent)
                .HasComment("section tabs content")
                .HasColumnName("section_content")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.SectionOrder)
                .HasDefaultValueSql("'0'")
                .HasComment("sorting the section tabs")
                .HasColumnName("section_order");
            entity.Property(e => e.SectionTitle)
                .HasMaxLength(200)
                .HasComment("section tabs title")
                .HasColumnName("section_title")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedByUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_user_id");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statistics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuditReportsReceiverMail)
                .HasColumnType("text")
                .HasColumnName("audit_reports_receiver_mail");
            entity.Property(e => e.AutomaticWithdrawalList)
                .HasColumnType("text")
                .HasColumnName("automatic_withdrawal_list");
            entity.Property(e => e.BinBlockToEmails)
                .HasColumnType("text")
                .HasColumnName("bin_block_to_emails");
            entity.Property(e => e.BlockUserEmail)
                .HasComment("user blocked mail receivers ")
                .HasColumnType("text")
                .HasColumnName("block_user_email");
            entity.Property(e => e.BrandServerIpList)
                .HasColumnType("text")
                .HasColumnName("brand_server_ip_list");
            entity.Property(e => e.BtransEmailReceivers)
                .HasComment("List of btrans email receivers email_address in comma separately")
                .HasColumnType("text")
                .HasColumnName("btrans_email_receivers");
            entity.Property(e => e.CashoutFileUploadedAlert)
                .HasColumnType("text")
                .HasColumnName("cashout_file_uploaded_alert");
            entity.Property(e => e.CommissionReportEmail)
                .HasColumnType("text")
                .HasColumnName("commission_report_email");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentNoOfFailedAttempt).HasColumnName("current_no_of_failed_attempt");
            entity.Property(e => e.DailyBalanceReportReceivers)
                .HasColumnType("text")
                .HasColumnName("daily_balance_report_receivers");
            entity.Property(e => e.DailySentEmailCounter)
                .HasDefaultValueSql("'0'")
                .HasColumnName("daily_sent_email_counter");
            entity.Property(e => e.DailySentEmailDate)
                .HasColumnType("datetime")
                .HasColumnName("daily_sent_email_date");
            entity.Property(e => e.FinflowServerIps)
                .HasComment("allowed ip list for finflow server")
                .HasColumnType("text")
                .HasColumnName("finflow_server_ips");
            entity.Property(e => e.FirstTransactionAlert)
                .HasColumnType("text")
                .HasColumnName("first_transaction_alert");
            entity.Property(e => e.FraudEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("fraud_email_receivers");
            entity.Property(e => e.Group)
                .HasMaxLength(70)
                .HasDefaultValueSql("'Alert'")
                .HasColumnName("group");
            entity.Property(e => e.InactivityNotificationEmail)
                .HasComment("Send notification email if user have no activity in panel for (n) days")
                .HasColumnType("text")
                .HasColumnName("inactivity_notification_email");
            entity.Property(e => e.IncorrectLoginNotificationEmail)
                .HasColumnType("text")
                .HasColumnName("incorrect_login_notification_email");
            entity.Property(e => e.IsApplicationOnline)
                .HasDefaultValueSql("'1'")
                .HasComment("0=application block, 1=application enable")
                .HasColumnName("is_application_online");
            entity.Property(e => e.KycVerificationIpWhiteList)
                .HasColumnType("text")
                .HasColumnName("kyc_verification_ip_white_list");
            entity.Property(e => e.MailAddresses)
                .HasColumnType("text")
                .HasColumnName("mail_addresses");
            entity.Property(e => e.MakerCheckerNotificationEmails)
                .HasComment("Maker Checker Created, Approved, Rejected notification emails")
                .HasColumnType("text")
                .HasColumnName("maker_checker_notification_emails");
            entity.Property(e => e.MaxCustomerNumber).HasColumnName("max_customer_number");
            entity.Property(e => e.MaxNoOfFailedAttempt)
                .HasDefaultValueSql("'10'")
                .HasColumnName("max_no_of_failed_attempt");
            entity.Property(e => e.MerchantStatusUpdateEmail)
                .HasComment("merchant status change email receivers")
                .HasColumnType("text")
                .HasColumnName("merchant_status_update_email");
            entity.Property(e => e.MonthlyB2cEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("monthly_b2c_email_receivers");
            entity.Property(e => e.NegativeBalanceEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("negative_balance_email_receivers");
            entity.Property(e => e.NegativeRevenueEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("negative_revenue_email_receivers");
            entity.Property(e => e.NewMerchantsEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("new_merchants_email_receivers");
            entity.Property(e => e.NewWithdrawalRequestEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("new_withdrawal_request_email_receivers");
            entity.Property(e => e.PavoAlertEmails)
                .HasComment("send email of pavo transaction if it is a success and bank pos not found")
                .HasColumnType("text")
                .HasColumnName("pavo_alert_emails");
            entity.Property(e => e.PosFailedEmailAddresses)
                .HasColumnType("text")
                .HasColumnName("pos_failed_email_addresses");
            entity.Property(e => e.PosMaxFailedAttempt).HasColumnName("pos_max_failed_attempt");
            entity.Property(e => e.PosNotWorkingAlertReceivers)
                .HasComment("Test POS transaction failure notification receivers email")
                .HasColumnType("text")
                .HasColumnName("pos_not_working_alert_receivers");
            entity.Property(e => e.PosNotWorkingMerchantId)
                .HasComment("Test POS default Merchant id ")
                .HasColumnName("pos_not_working_merchant_id");
            entity.Property(e => e.RecurringPosNotificationEmail)
                .HasComment("pos not found receicer email")
                .HasColumnType("text")
                .HasColumnName("recurring_pos_notification_email");
            entity.Property(e => e.SessionUserEmail)
                .HasComment("login session user email receivers")
                .HasColumnType("text")
                .HasColumnName("session_user_email");
            entity.Property(e => e.TenantServerIps)
                .HasComment("allowed ip list for tenant server")
                .HasColumnType("text")
                .HasColumnName("tenant_server_ips");
            entity.Property(e => e.TransactionStatusIpWhitelist)
                .HasColumnType("text")
                .HasColumnName("transaction_status_ip_whitelist");
            entity.Property(e => e.TransactionSummaryEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("transaction_summary_email_receivers");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserChangeInformationEmail)
                .HasComment("Send Email when a user change information")
                .HasColumnType("text")
                .HasColumnName("user_change_information_email");
            entity.Property(e => e.UserWalletEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("user_wallet_email_receivers");
            entity.Property(e => e.UserWrongAttemptsSecretQuestionEmail)
                .HasComment("User Max 5 Wrong Attempts Secret Question")
                .HasColumnType("text")
                .HasColumnName("user_wrong_attempts_secret_question_email");
            entity.Property(e => e.WalletGateReportEmailReceivers)
                .HasColumnType("text")
                .HasColumnName("wallet_gate_report_email_receivers");
            entity.Property(e => e.WithdrawalRequestCreated)
                .HasColumnType("text")
                .HasColumnName("withdrawal_request_created");
        });

        modelBuilder.Entity<SubMerchant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sub_merchants")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => new { e.MerchantId, e.SubMerchantId }, "merchant_id_sub_merchant_id");

            entity.HasIndex(e => new { e.MerchantId, e.TerminalNo, e.MerchantTerminalUniqueCounter }, "merchant_id_terminal_no_unique_counter").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorizedPersonEmail)
                .HasMaxLength(100)
                .HasColumnName("authorized_person_email")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AuthorizedPersonName)
                .HasMaxLength(100)
                .HasColumnName("authorized_person_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AuthorizedPersonPhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("authorized_person_phone_number")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AutoApprovalDays)
                .HasDefaultValueSql("'-1'")
                .HasComment("In case merchant fails to aprove an item for settlement via TransactionApprove API after this number of days item will be auto approved for settlement\r\n Values: -1 : Only Allowed if transaction is approved via TransactionApprove API\r\n0 : Immediately Approved\r\n>0 : Approved after this amount of days")
                .HasColumnName("auto_approval_days");
            entity.Property(e => e.BusinessArea)
                .HasMaxLength(100)
                .HasColumnName("business_area")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ContactPersonPhone)
                .HasMaxLength(100)
                .HasColumnName("contact_person_phone")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullCompanyName)
                .HasMaxLength(100)
                .HasColumnName("full_company_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IbanNo)
                .HasMaxLength(100)
                .HasColumnName("iban_no")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IdTcKn)
                .HasMaxLength(100)
                .HasColumnName("id_tc_kn");
            entity.Property(e => e.IsEnableAutoWithdrawal).HasColumnName("is_enable_auto_withdrawal");
            entity.Property(e => e.MerchantDescription)
                .HasMaxLength(100)
                .HasColumnName("merchant_description")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantKey)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("merchant_key");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(100)
                .HasColumnName("merchant_name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MerchantTerminalUniqueCounter)
                .HasDefaultValueSql("'0'")
                .HasComment("unique counter for sariTaxi submerchants to unique merchant_id and terminal_no . Default will be 0 for other type submerchants")
                .HasColumnName("merchant_terminal_unique_counter");
            entity.Property(e => e.MerchantType)
                .HasMaxLength(100)
                .HasColumnName("merchant_type")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PaymentReceiveOptions)
                .HasMaxLength(100)
                .HasColumnName("payment_receive_options")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("phone_number");
            entity.Property(e => e.SettlementId)
                .HasDefaultValueSql("'0'")
                .HasComment("Settlement ID for the Submerchant ")
                .HasColumnName("settlement_id");
            entity.Property(e => e.SubMerchantId)
                .HasDefaultValueSql("''")
                .HasColumnName("sub_merchant_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TerminalNo)
                .HasMaxLength(100)
                .HasColumnName("terminal_no");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(100)
                .HasColumnName("zip_code")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<SubMerchantAutomaticWithdrawalSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sub_merchant_automatic_withdrawal_settings")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'1'")
                .HasComment("Auto Withdrawal currency id")
                .HasColumnName("currency_id");
            entity.Property(e => e.LastProcessedAt)
                .HasComment("last processed date of Auto Withdrawal")
                .HasColumnType("datetime")
                .HasColumnName("last_processed_at");
            entity.Property(e => e.RemainAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("Auto Withdrawal remain amount for the submerchant")
                .HasColumnType("double(12,4)")
                .HasColumnName("remain_amount");
            entity.Property(e => e.SettlementId)
                .HasDefaultValueSql("'0'")
                .HasComment("Auto Withdrawal settlement id for the submerchant")
                .HasColumnName("settlement_id");
            entity.Property(e => e.SubMerchantId).HasColumnName("sub_merchant_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SubMerchantPf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sub_merchant_pfs")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.MerchantId, e.PfId }, "merchant_id_pf_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.GroupId)
                .HasMaxLength(50)
                .HasComment("isbank,alternatifbank,halkbank")
                .HasColumnName("group_id");
            entity.Property(e => e.IsoCountryCode)
                .HasMaxLength(3)
                .HasColumnName("iso_country_code");
            entity.Property(e => e.Mcc)
                .HasMaxLength(50)
                .HasColumnName("mcc");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.PfId)
                .HasMaxLength(100)
                .HasColumnName("pf_id");
            entity.Property(e => e.PostCode)
                .HasMaxLength(6)
                .HasColumnName("post_code");
            entity.Property(e => e.RemoteSubMerchantId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("remote_sub_merchant_id");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>by Admin, 2=> by Merchant, 3=> by API ")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive;1=>active")
                .HasColumnName("status");
            entity.Property(e => e.Tckn)
                .HasMaxLength(100)
                .HasColumnName("tckn");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
            entity.Property(e => e.Vkn)
                .HasMaxLength(100)
                .HasColumnName("vkn");
        });

        modelBuilder.Entity<SubModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sub_modules")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ControllerName)
                .HasMaxLength(255)
                .HasColumnName("controller_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DefaultMethod)
                .HasMaxLength(50)
                .HasColumnName("default_method");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.Icon)
                .HasMaxLength(255)
                .HasColumnName("icon");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TemporaryTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("temporary_transactions")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id)
                .HasComment("Auto incrementing")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ReceiverEmail)
                .HasMaxLength(100)
                .HasComment("Receiver email that does not exist on user table")
                .HasColumnName("receiver_email");
            entity.Property(e => e.ReceiverPhone)
                .HasMaxLength(100)
                .HasColumnName("receiver_phone")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.ReceiverTransactionId).HasColumnName("receiver_transaction_id");
            entity.Property(e => e.RegistrationStatus)
                .HasDefaultValueSql("'PENDING'")
                .HasComment("Check if email receiver registered.")
                .HasColumnType("enum('PENDING','REGISTERED','REJECTED')")
                .HasColumnName("registration_status");
            entity.Property(e => e.SenderTransactionId)
                .HasComment("Transaction ID")
                .HasColumnName("sender_transaction_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TestPo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("test_pos")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("pos amount")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId)
                .HasComment("currency primary key")
                .HasColumnName("currency_id");
            entity.Property(e => e.EmailSentStatus)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = failed email notification sent ,\r\n1 = success email notification sent")
                .HasColumnName("email_sent_status");
            entity.Property(e => e.NextActionDate)
                .HasComment("next checking time")
                .HasColumnType("datetime")
                .HasColumnName("next_action_date");
            entity.Property(e => e.PosId)
                .HasComment("cron interval")
                .HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive, 1=>active")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TestPosHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("test_pos_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankErrorCode)
                .HasMaxLength(50)
                .HasColumnName("bank_error_code");
            entity.Property(e => e.BankErrorDescription)
                .HasMaxLength(255)
                .HasColumnName("bank_error_description");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.BankResponseJson)
                .HasColumnType("text")
                .HasColumnName("bank_response_json");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasComment("0 = failed, 1= success")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TestPosInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("test_pos_informations")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Info)
                .HasMaxLength(255)
                .HasColumnName("info");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasComment("error response")
                .HasColumnName("note");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive, 1=>active")
                .HasColumnName("status");
            entity.Property(e => e.TestPosId)
                .HasComment("test_pos primary key")
                .HasColumnName("test_pos_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tickets")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.AssignedUserId)
                .HasDefaultValueSql("'0'")
                .HasComment("tickets current assigned admin user id")
                .HasColumnName("assigned_user_id");
            entity.Property(e => e.Attachment)
                .HasMaxLength(191)
                .HasColumnName("attachment");
            entity.Property(e => e.CloseNote)
                .HasMaxLength(255)
                .HasColumnName("close_note")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ClosedBy).HasColumnName("closed_by");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Messagefrom)
                .HasDefaultValueSql("'CUSTOMER'")
                .HasColumnType("enum('CUSTOMER','SUPPORT')")
                .HasColumnName("messagefrom");
            entity.Property(e => e.Priority)
                .HasMaxLength(255)
                .HasColumnName("priority");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(255)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketcategoryId).HasColumnName("ticketcategory_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasComment("0=customer, 2=merchant")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<TicketConversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ticket_conversations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attachment)
                .HasMaxLength(191)
                .HasColumnName("attachment");
            entity.Property(e => e.ClosedBy).HasColumnName("closed_by");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Messagefrom)
                .HasDefaultValueSql("'CUSTOMER'")
                .HasColumnType("enum('CUSTOMER','SUPPORT','')")
                .HasColumnName("messagefrom");
            entity.Property(e => e.Priority)
                .HasMaxLength(255)
                .HasColumnName("priority");
            entity.Property(e => e.TicketId)
                .HasMaxLength(255)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketcategoryId).HasColumnName("ticketcategory_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Ticketcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ticketcategories")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Ticketcomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ticketcomments")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Timezone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("timezones")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country_code");
            entity.Property(e => e.TimeZone1)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("time_zone");
            entity.Property(e => e.UtcDstOffset)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("utc_dst_offset");
            entity.Property(e => e.UtcOffset)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("utc_offset");
        });

        modelBuilder.Entity<TmpAdvanceCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tmp_advance_commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("effective_date");
            entity.Property(e => e.EffectiveStatus)
                .HasDefaultValueSql("'0'")
                .HasComment("0=not processed yet by Cron; 1=already processed by cron")
                .HasColumnName("effective_status");
            entity.Property(e => e.IsAllowForeignCard)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_allow_foreign_card");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<TmpBankResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_bank_responses")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankResponse)
                .HasComment("bank_landing_response from CCPayment")
                .HasColumnType("text")
                .HasColumnName("bank_response");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasComment("Sale order_id")
                .HasColumnName("order_id");
            entity.Property(e => e.SessionData)
                .HasComment("Payment extras/session_data")
                .HasColumnType("text")
                .HasColumnName("session_data");
            entity.Property(e => e.Status)
                .HasComment("0 = Not Processed\r\n1 = Processed")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TmpFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_files")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .HasColumnName("file_name");
            entity.Property(e => e.Status)
                .HasComment("0 => pending , 1 => completed , 2 => in progress")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1 => yapi , 2 => fp_mt")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TmpGovBtransReportDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_gov_btrans_report_data")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.B2bObj)
                .HasColumnType("text")
                .HasColumnName("b2b_obj");
            entity.Property(e => e.B2cBankObj)
                .HasColumnType("text")
                .HasColumnName("b2c_bank_obj");
            entity.Property(e => e.B2cWalletObj)
                .HasColumnType("text")
                .HasColumnName("b2c_wallet_obj");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DepositObj)
                .HasColumnType("text")
                .HasColumnName("deposit_obj");
            entity.Property(e => e.MerchantObj)
                .HasColumnType("text")
                .HasColumnName("merchant_obj");
            entity.Property(e => e.ReferenceId)
                .HasDefaultValueSql("'0'")
                .HasComment("Referenceable  id against type. Ex. sale id or withdrawal id or deposit id")
                .HasColumnName("reference_id");
            entity.Property(e => e.RefundHistoryObj)
                .HasColumnType("text")
                .HasColumnName("refund_history_obj");
            entity.Property(e => e.SaleData)
                .HasColumnType("text")
                .HasColumnName("sale_data");
            entity.Property(e => e.SaleExtras)
                .HasColumnType("text")
                .HasColumnName("sale_extras");
            entity.Property(e => e.SaleObj)
                .HasColumnType("text")
                .HasColumnName("sale_obj");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment("0 => Processed , 1 => Not Processed")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'0'")
                .HasComment("1 => Sale , 2 => Refund, 3 => Deposit, 4 => B2C Bank, 5 => B2C Wallet, 6 => B2B' after status")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WithdrawObj)
                .HasColumnType("text")
                .HasColumnName("withdraw_obj");
        });

        modelBuilder.Entity<TmpMerchantHashKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tmp_merchant_hash_keys");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthEmail)
                .HasMaxLength(50)
                .HasColumnName("auth_email");
            entity.Property(e => e.AuthPhone)
                .HasMaxLength(20)
                .HasColumnName("auth_phone");
            entity.Property(e => e.BankCode)
                .HasMaxLength(50)
                .HasComment("pavo successful transactions acquirerBKMCode for sending alert email")
                .HasColumnName("bank_code");
            entity.Property(e => e.LastActionDate)
                .HasColumnType("datetime")
                .HasColumnName("last_action_date");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.RequestUrl)
                .HasMaxLength(255)
                .HasColumnName("request_url");
            entity.Property(e => e.Type)
                .HasComment("0 => hash key alert , 1 => imported transaction ( pavo ) alert")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TmpMerchantPosCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tmp_merchant_pos_commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComFixed)
                .HasPrecision(8, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("com_fixed");
            entity.Property(e => e.ComPercentage)
                .HasPrecision(8, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("com_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.EndUserComFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(8,4)")
                .HasColumnName("end_user_com_fixed");
            entity.Property(e => e.EndUserComPercentage)
                .HasColumnType("double(8,4)")
                .HasColumnName("end_user_com_percentage");
            entity.Property(e => e.InstallmentNumber).HasColumnName("installment_number");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TmpAdvanceCommissionId).HasColumnName("tmp_advance_commission_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<TmpObjectStorage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_object_storage")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.OrderId, "order_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CampaignPosInstallment)
                .HasColumnType("text")
                .HasColumnName("campaign_pos_installment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Currency)
                .HasColumnType("text")
                .HasColumnName("currency");
            entity.Property(e => e.DplObj)
                .HasColumnType("text")
                .HasColumnName("dpl_obj");
            entity.Property(e => e.DplSettingsObj)
                .HasColumnType("mediumtext")
                .HasColumnName("dpl_settings_obj");
            entity.Property(e => e.Merchant)
                .HasColumnType("text")
                .HasColumnName("merchant");
            entity.Property(e => e.MerchantCommission)
                .HasColumnType("text")
                .HasColumnName("merchant_commission");
            entity.Property(e => e.MerchantPosCommission)
                .HasColumnType("text")
                .HasColumnName("merchant_pos_commission");
            entity.Property(e => e.MerchantSettings)
                .HasColumnType("text")
                .HasColumnName("merchant_settings");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("order_id");
            entity.Property(e => e.PfRecords)
                .HasColumnType("text")
                .HasColumnName("pf_records");
            entity.Property(e => e.Pos)
                .HasColumnType("text")
                .HasColumnName("pos");
            entity.Property(e => e.PosInstallment)
                .HasColumnType("text")
                .HasColumnName("pos_installment");
            entity.Property(e => e.Request)
                .HasColumnType("text")
                .HasColumnName("request");
            entity.Property(e => e.SaleCurrencyConversion)
                .HasColumnType("text")
                .HasColumnName("sale_currency_conversion");
            entity.Property(e => e.Settlement)
                .HasColumnType("text")
                .HasColumnName("settlement");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TmpPaymentRecord)
                .HasColumnType("text")
                .HasColumnName("tmp_payment_record");
        });

        modelBuilder.Entity<TmpOrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_order_status")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.InvoiceId, e.MerchantKey }, "invoice_id_merchant_key");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.JsonResponse)
                .HasColumnType("text")
                .HasColumnName("json_response");
            entity.Property(e => e.LastRequestedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_requested_at");
            entity.Property(e => e.MerchantKey)
                .HasDefaultValueSql("''")
                .HasColumnName("merchant_key")
                .UseCollation("utf8mb4_0900_ai_ci");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TmpPaymentRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_payment_records")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.OrderId, "order_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.BankCode)
                .HasMaxLength(30)
                .HasColumnName("bank_code")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.BankUrl)
                .HasMaxLength(100)
                .HasColumnName("bank_url")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ClientId)
                .HasMaxLength(200)
                .HasColumnName("client_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Comission)
                .HasColumnType("text")
                .HasColumnName("comission")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Commission)
                .HasColumnType("mediumtext")
                .HasColumnName("commission")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DplId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("dpl_id");
            entity.Property(e => e.DplToken)
                .HasMaxLength(100)
                .HasColumnName("dpl_token")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.InvoiceDetails)
                .HasColumnType("text")
                .HasColumnName("invoice_details")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Ip)
                .HasMaxLength(45)
                .HasColumnName("ip")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IsAllowOrderStatus)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_allow_order_status");
            entity.Property(e => e.IsPreAuthPending)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_pre_auth_pending");
            entity.Property(e => e.MerchantId)
                .HasDefaultValueSql("'0'")
                .HasComment("merchant id from merchants table")
                .HasColumnName("merchant_id");
            entity.Property(e => e.MerchantKey)
                .HasMaxLength(100)
                .HasColumnName("merchant_key")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("order_id")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PaymentProvider)
                .HasMaxLength(30)
                .HasColumnName("payment_provider")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RemoteOrderId)
                .HasMaxLength(100)
                .HasColumnName("remote_order_id")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SaleType)
                .HasDefaultValueSql("'1'")
                .HasComment("1=auth , 2=PreAuth")
                .HasColumnName("sale_type");
            entity.Property(e => e.SessionData)
                .HasColumnType("text")
                .HasColumnName("session_data")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive, 2=waiting for delete, 5= Special Order Status, 6= Waiting for PreAuth confirm/reject event")
                .HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(90)
                .HasColumnName("surname")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TokenUrl)
                .HasMaxLength(130)
                .HasColumnName("token_url")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>Sale, 2=>Deposit")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .HasColumnName("username")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<TmpPaymentRecordAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_payment_record_actions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsAvoidCheckOrderStatus)
                .HasComment("value to avoid check order status cron job")
                .HasColumnName("is_avoid_check_order_status");
            entity.Property(e => e.ReferenceId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasComment("value could be order_id or tmp_payment_record_id")
                .HasColumnName("reference_id")
                .UseCollation("utf16_unicode_ci")
                .HasCharSet("utf16");
            entity.Property(e => e.ReferenceType)
                .HasComment("1=tmp_payment_record_id , 2= order_id")
                .HasColumnName("reference_type");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("0 = delete, 1= update")
                .HasColumnName("type");
            entity.Property(e => e.UpdateValue)
                .HasComment("after set keyword. ")
                .HasColumnType("mediumtext")
                .HasColumnName("update_value")
                .UseCollation("utf16_unicode_ci")
                .HasCharSet("utf16");
            entity.Property(e => e.WhereBy)
                .HasComment("After where keyword. update for which rows")
                .HasColumnType("mediumtext")
                .HasColumnName("where_by")
                .UseCollation("utf16_unicode_ci")
                .HasCharSet("utf16");
        });

        modelBuilder.Entity<TmpPo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_pos")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowForeignCard)
                .HasDefaultValueSql("'0'")
                .HasComment("0 =allow_foreign_card inactive; 1= allow_foreign_card active")
                .HasColumnName("allow_foreign_card");
            entity.Property(e => e.AllowPayByCardToken)
                .HasDefaultValueSql("'0'")
                .HasColumnName("allow_pay_by_card_token");
            entity.Property(e => e.BankClosingTime)
                .HasDefaultValueSql("'23:59:59'")
                .HasColumnType("time")
                .HasColumnName("bank_closing_time");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name");
            entity.Property(e => e.Bolum).HasColumnName("bolum");
            entity.Property(e => e.BrandBankAccountId)
                .HasDefaultValueSql("'0'")
                .HasComment("id from brand_bank_accounts table where pos account is true")
                .HasColumnName("brand_bank_account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DebitCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("debit_cot_fixed");
            entity.Property(e => e.DebitCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("debit_cot_percentage");
            entity.Property(e => e.EffectDate)
                .HasColumnType("datetime")
                .HasColumnName("effect_date");
            entity.Property(e => e.EffectStatus)
                .HasComment("0 = not processed by cron, 1 = already processed by cron")
                .HasColumnName("effect_status");
            entity.Property(e => e.ForeignAmexCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_amex_cot_fixed");
            entity.Property(e => e.ForeignAmexCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_amex_cot_percentage");
            entity.Property(e => e.ForeignCardSettlementId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("foreign_card_settlement_id");
            entity.Property(e => e.ForeignCcCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_cc_cot_fixed");
            entity.Property(e => e.ForeignCcCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("foreign_cc_cot_percentage");
            entity.Property(e => e.IsAllowDcc)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not  allow,  1=allow")
                .HasColumnName("is_allow_dcc");
            entity.Property(e => e.IsAllowForeignAmexCard)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not  allow,  1=allow")
                .HasColumnName("is_allow_foreign_amex_card");
            entity.Property(e => e.IsAllowInsurancePayment)
                .HasDefaultValueSql("'0'")
                .HasComment("To check if POS is allowed for insurance payment\r\n0 : Not Allowed\r\n1 : Allowed")
                .HasColumnName("is_allow_insurance_payment");
            entity.Property(e => e.IsAllowLocalAmexCard)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = not  allow,  1=allow")
                .HasColumnName("is_allow_local_amex_card");
            entity.Property(e => e.IsAllowPreAuth)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = auth ; 1 = pre_auth")
                .HasColumnName("is_allow_pre_auth");
            entity.Property(e => e.IsAllowSale)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_allow_sale");
            entity.Property(e => e.IsEnable2d)
                .HasDefaultValueSql("'0'")
                .HasComment("1=enable; 0=disable")
                .HasColumnName("is_enable_2d");
            entity.Property(e => e.IsEnable3d)
                .HasDefaultValueSql("'1'")
                .HasComment("1=enable; 0=disable")
                .HasColumnName("is_enable_3d");
            entity.Property(e => e.IsInstallmentWiseSettlement)
                .HasDefaultValueSql("'0'")
                .HasComment("To check if POS is allowed for installment wise settlement\r\n0 : Not Allowed\r\n1 : Allowed")
                .HasColumnName("is_installment_wise_settlement");
            entity.Property(e => e.IsRecurring)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_recurring");
            entity.Property(e => e.IsShowOnDeposit)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_show_on_deposit");
            entity.Property(e => e.LocalAmexCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("local_amex_cot_fixed");
            entity.Property(e => e.LocalAmexCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("local_amex_cot_percentage");
            entity.Property(e => e.MaxInstallment)
                .HasDefaultValueSql("'1'")
                .HasColumnName("max_installment");
            entity.Property(e => e.MaxNoOfFailedAttempt).HasColumnName("max_no_of_failed_attempt");
            entity.Property(e => e.MinInstallment)
                .HasDefaultValueSql("'1'")
                .HasColumnName("min_installment");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NotUsCcCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_cc_cot_fixed");
            entity.Property(e => e.NotUsCcCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_cc_cot_percentage");
            entity.Property(e => e.NotUsDebitCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_debit_cot_fixed");
            entity.Property(e => e.NotUsDebitCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("not_us_debit_cot_percentage");
            entity.Property(e => e.OnUsCcCotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("on_us_cc_cot_fixed");
            entity.Property(e => e.OnUsCcCotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("on_us_cc_cot_percentage");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Program)
                .HasMaxLength(100)
                .HasColumnName("program");
            entity.Property(e => e.RefundSettlementId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("refund_settlement_id");
            entity.Property(e => e.RemoteSubMerchantId)
                .HasMaxLength(50)
                .HasColumnName("remote_sub_merchant_id");
            entity.Property(e => e.SameProgramDiffrentBankCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_diffrent_bank_cot_fixed");
            entity.Property(e => e.SameProgramDiffrentBankCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_diffrent_bank_cot_percentage");
            entity.Property(e => e.SameProgramSameBankCotFixed)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_same_bank_cot_fixed");
            entity.Property(e => e.SameProgramSameBankCotPercentage)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("same_program_same_bank_cot_percentage");
            entity.Property(e => e.SendPfRecords)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = dont send, 1 = send")
                .HasColumnName("send_pf_records");
            entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1 = active, 0 = inactive")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_id");
            entity.Property(e => e.VirtualPosId)
                .HasMaxLength(50)
                .HasColumnName("virtual_pos_id")
                .UseCollation("utf8mb3_unicode_ci");
        });

        modelBuilder.Entity<TmpPosInstallment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_pos_installments")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CotFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_fixed");
            entity.Property(e => e.CotPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("cot_percentage");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.InstallmentsNumber).HasColumnName("installments_number");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>inactive;1=>active;")
                .HasColumnName("status");
            entity.Property(e => e.TmpPosId).HasColumnName("tmp_pos_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TmpPosIssuerTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_pos_issuer_tags")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.TmpPosId).HasColumnName("tmp_pos_id");
        });

        modelBuilder.Entity<TmpRefundRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tmp_refund_requests");

            entity.HasIndex(e => new { e.MerchantId, e.OrderId }, "merchant_id");

            entity.HasIndex(e => e.UniqueId, "unique_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.Attempt)
                .HasDefaultValueSql("'0'")
                .HasComment("Field to control frequency of immediate refund request")
                .HasColumnName("attempt");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id");
            entity.Property(e => e.MerchantId)
                .HasMaxLength(50)
                .HasColumnName("merchant_id");
            entity.Property(e => e.MerchantKey)
                .HasMaxLength(255)
                .HasColumnName("merchant_key");
            entity.Property(e => e.MerchantUserId).HasColumnName("merchant_user_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'1'")
                .HasComment("Priority of refunds\r\n1 = express\r\n\r\n2 = high\r\n\r\n3 = medium\r\n\r\n4= low")
                .HasColumnName("priority");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("double(12,4)")
                .HasColumnName("product_price");
            entity.Property(e => e.RefundReferenceNumber)
                .HasMaxLength(50)
                .HasComment("This reference number is prvided by bank. And it is store when manually bulk refund. ")
                .HasColumnName("refund_reference_number");
            entity.Property(e => e.RefundTransactionId)
                .HasMaxLength(255)
                .HasColumnName("refund_transaction_id");
            entity.Property(e => e.RefundType)
                .HasDefaultValueSql("'2'")
                .HasComment("1 = Refund to Wallet, 2 = Refund to Bank")
                .HasColumnName("refund_type");
            entity.Property(e => e.RefundWebHookKey)
                .HasMaxLength(255)
                .HasColumnName("refund_web_hook_key");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'1'")
                .HasComment("1 - From Api\r\n2 - From FP\r\n3 - From Paybill\r\n4 - From Pavo\r\n5 - From Duplicate Invoice")
                .HasColumnName("source");
            entity.Property(e => e.Status)
                .HasComment("0 = Not Processed Yet\r\n1 = Processed")
                .HasColumnName("status");
            entity.Property(e => e.StatusCode).HasColumnName("status_code");
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(255)
                .HasColumnName("status_description");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'1'")
                .HasComment("type of refund,\r\n1 = refund\r\n2 = chargeback\r\n3 = retry awaiting refund")
                .HasColumnName("type");
            entity.Property(e => e.UniqueId).HasColumnName("unique_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TmpSaleAutomation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_sale_automations")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempt)
                .HasDefaultValueSql("'0'")
                .HasComment("increase every time. after 3 times, change status = 2")
                .HasColumnName("attempt");
            entity.Property(e => e.BankObj)
                .HasColumnType("text")
                .HasColumnName("bank_obj");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyObj)
                .HasColumnType("text")
                .HasColumnName("currency_obj");
            entity.Property(e => e.DplObj)
                .HasColumnType("text")
                .HasColumnName("dpl_obj");
            entity.Property(e => e.Extras)
                .HasColumnType("text")
                .HasColumnName("extras");
            entity.Property(e => e.IsCallSaleWebhook)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_call_sale_webhook");
            entity.Property(e => e.IsCallSaleWebhookProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_call_sale_webhook_processed");
            entity.Property(e => e.IsFirstTransactionAlert)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_first_transaction_alert");
            entity.Property(e => e.IsFirstTransactionAlertProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_first_transaction_alert_processed");
            entity.Property(e => e.IsIpToCountry)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_ip_to_country");
            entity.Property(e => e.IsIpToCountryProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_ip_to_country_processed");
            entity.Property(e => e.IsLastRow)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_last_row");
            entity.Property(e => e.IsManualPos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_manual_pos");
            entity.Property(e => e.IsManualPosProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_manual_pos_processed");
            entity.Property(e => e.IsNotificationOff)
                .HasDefaultValueSql("'0'")
                .HasComment("1 = do not send any notiification or webhook,\r\n0 =  Send notification and webhook")
                .HasColumnName("is_notification_off");
            entity.Property(e => e.IsProcessFailAlert)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_process_fail_alert");
            entity.Property(e => e.IsProcessFailAlertProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_process_fail_alert_processed");
            entity.Property(e => e.IsSaveCard)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_save_card");
            entity.Property(e => e.IsSaveCardProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_save_card_processed");
            entity.Property(e => e.IsSendCraftGatePaymentResponseProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_send_craft_gate_payment_response_processed");
            entity.Property(e => e.IsSendPuchaseEmail)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_send_puchase_email");
            entity.Property(e => e.IsSendPuchaseEmailProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_send_puchase_email_processed");
            entity.Property(e => e.IsSendSms)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_send_sms");
            entity.Property(e => e.IsSendSmsProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_send_sms_processed");
            entity.Property(e => e.IsSendToPayer)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_send_to_payer");
            entity.Property(e => e.IsSendToPayerProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_send_to_payer_processed");
            entity.Property(e => e.IsTaxInfo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_tax_info");
            entity.Property(e => e.IsTaxInfoProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_tax_info_processed");
            entity.Property(e => e.IsWix).HasColumnName("is_wix");
            entity.Property(e => e.IsWixProcessed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_wix_processed");
            entity.Property(e => e.MerchantObj)
                .HasColumnType("text")
                .HasColumnName("merchant_obj");
            entity.Property(e => e.MerchantUserObj)
                .HasColumnType("text")
                .HasColumnName("merchant_user_obj");
            entity.Property(e => e.PayByCardTokenProvider)
                .HasMaxLength(20)
                .HasColumnName("pay_by_card_token_provider");
            entity.Property(e => e.PurchaseRequestObj)
                .HasColumnType("text")
                .HasColumnName("purchase_request_obj");
            entity.Property(e => e.SaleBillingData)
                .HasColumnType("text")
                .HasColumnName("sale_billing_data");
            entity.Property(e => e.SaleBillingObj)
                .HasColumnType("text")
                .HasColumnName("sale_billing_obj");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleObj)
                .HasColumnType("text")
                .HasColumnName("sale_obj");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasComment(" 0=pending, 1=processed, 2=awaiting state for deleting")
                .HasColumnName("status");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserObj)
                .HasColumnType("text")
                .HasColumnName("user_obj");
            entity.Property(e => e.Version)
                .HasDefaultValueSql("'1'")
                .HasColumnName("version");
        });

        modelBuilder.Entity<TmpWixForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_wix_forms")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FormObj)
                .HasColumnType("text")
                .HasColumnName("form_obj");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(100)
                .HasColumnName("invoice_id");
            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .HasColumnName("key_name");
            entity.Property(e => e.MerchantId)
                .HasMaxLength(200)
                .HasColumnName("merchant_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("order_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.WixRefundId)
                .HasMaxLength(100)
                .HasColumnName("wix_refund_id");
        });

        modelBuilder.Entity<TmpYapiReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tmp_yapi_reports")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.ReferenceNo, "reference_no").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.Commission)
                .HasColumnType("double(12,4)")
                .HasColumnName("commission");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.NetAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("net_amount");
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(100)
                .HasColumnName("reference_no");
            entity.Property(e => e.RemoteStatus).HasColumnName("remote_status");
            entity.Property(e => e.Status)
                .HasComment("0=>Not Processed, 1=>Processed")
                .HasColumnName("status");
            entity.Property(e => e.TerminalNo)
                .HasMaxLength(100)
                .HasColumnName("terminal_no");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TransactionState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("transaction_states")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameTr)
                .HasMaxLength(80)
                .HasColumnName("name_tr");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Transactionable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("transactionable")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CreatedAtInt, "created_at_int");

            entity.HasIndex(e => e.PaymentId, "payment_id");

            entity.HasIndex(e => e.RequestId, "request_id");

            entity.HasIndex(e => new { e.TransactionableType, e.TransactionableId }, "transactionable_type_transactionable_id");

            entity.HasIndex(e => e.UpdatedAtInt, "updated_at_int");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.ActivityTitle)
                .HasMaxLength(191)
                .HasColumnName("activity_title");
            entity.Property(e => e.Balance)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("balance");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedAtInt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_at_int");
            entity.Property(e => e.Currency)
                .HasMaxLength(191)
                .HasDefaultValueSql("'TL'")
                .HasColumnName("currency");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.EntityId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("entity_id");
            entity.Property(e => e.EntityName)
                .HasMaxLength(191)
                .HasColumnName("entity_name");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.JsonData)
                .HasColumnType("mediumtext")
                .HasColumnName("json_data");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.MoneyFlow)
                .HasMaxLength(191)
                .HasColumnName("money_flow");
            entity.Property(e => e.Net)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.NonSipayUserEmail)
                .HasMaxLength(191)
                .HasColumnName("non_sipay_user_email");
            entity.Property(e => e.NonSipayUserPhone)
                .HasMaxLength(100)
                .HasColumnName("non_sipay_user_phone");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.ReasonTitle)
                .HasMaxLength(255)
                .HasColumnName("reason_title");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.TransactionableId).HasColumnName("transactionable_id");
            entity.Property(e => e.TransactionableType)
                .HasMaxLength(191)
                .HasColumnName("transactionable_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedAtInt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_at_int");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Translation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("translations")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.TableName, e.ColumnName, e.ForeignKey, e.Locale }, "translations_table_name_column_name_foreign_key_locale_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(191)
                .HasColumnName("column_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ForeignKey).HasColumnName("foreign_key");
            entity.Property(e => e.Locale)
                .HasMaxLength(191)
                .HasColumnName("locale");
            entity.Property(e => e.TableName)
                .HasMaxLength(191)
                .HasColumnName("table_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasColumnType("text")
                .HasColumnName("value");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.CustomerNumber, "customer_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountStatus)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("account_status");
            entity.Property(e => e.ActivatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("activated_at");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AnswerOne)
                .HasColumnType("text")
                .HasColumnName("answer_one");
            entity.Property(e => e.Avatar)
                .HasMaxLength(191)
                .HasColumnName("avatar");
            entity.Property(e => e.Balance)
                .HasColumnType("double(8,2)")
                .HasColumnName("balance");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.ContractedFile)
                .HasMaxLength(255)
                .HasColumnName("contracted_file");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_id");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(191)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("currency_id");
            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(20)
                .HasColumnName("customer_number");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.FailedLoginAttempt)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = Right password has been attempted,1=Wrong password has been attempted")
                .HasColumnName("failed_login_attempt");
            entity.Property(e => e.FbId)
                .HasMaxLength(50)
                .HasColumnName("fb_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(191)
                .HasColumnName("first_name");
            entity.Property(e => e.FirstTimeLogin)
                .HasDefaultValueSql("'0'")
                .HasColumnName("first_time_login");
            entity.Property(e => e.Gender)
                .HasComment("1=Male, 2=Female")
                .HasColumnName("gender");
            entity.Property(e => e.ImgPath)
                .HasColumnType("text")
                .HasColumnName("img_path");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("ip");
            entity.Property(e => e.IsAdminVerified)
                .HasComment("0=Pending, 1=Approved, 2=Not Approved, 3=Lock User")
                .HasColumnName("is_admin_verified");
            entity.Property(e => e.IsEmailVerifyed)
                .HasComment("0 => not Verified\r\n1 => Verified")
                .HasColumnName("is_email_verifyed");
            entity.Property(e => e.IsMerchantRestrictedByAccountManager)
                .HasDefaultValueSql("'0'")
                .HasComment("0 = Not Restricted, 1= this user will be restricted to see the merchants only which are under this account as account manager\r\n\r\n")
                .HasColumnName("is_merchant_restricted_by_account_manager");
            entity.Property(e => e.IsOnline)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_online");
            entity.Property(e => e.IsOtpRequired)
                .HasDefaultValueSql("'1'")
                .HasComment("1=> otp required, 0=> otp not required")
                .HasColumnName("is_otp_required");
            entity.Property(e => e.IsSelfDeactivated)
                .HasComment("0=>Default, 1=>User Self Deactivation")
                .HasColumnName("is_self_deactivated");
            entity.Property(e => e.IsSendActivationRequest)
                .HasComment("0=>Default, 1=>Request send to admin")
                .HasColumnName("is_send_activation_request");
            entity.Property(e => e.IsTicketAdmin)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_ticket_admin");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Language)
                .HasMaxLength(2)
                .HasDefaultValueSql("'tr'")
                .HasColumnName("language");
            entity.Property(e => e.LastActivityDatetime)
                .HasColumnType("datetime")
                .HasColumnName("last_activity_datetime");
            entity.Property(e => e.LastFailedLoginDatetime)
                .HasColumnType("timestamp")
                .HasColumnName("last_failed_login_datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(191)
                .HasColumnName("last_name");
            entity.Property(e => e.LastSeen)
                .HasColumnType("datetime")
                .HasColumnName("last_seen");
            entity.Property(e => e.LoginAt)
                .HasComment("user logged in time")
                .HasColumnType("datetime")
                .HasColumnName("login_at");
            entity.Property(e => e.Merchant).HasColumnName("merchant");
            entity.Property(e => e.MerchantParentUserId).HasColumnName("merchant_parent_user_id");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.OtpChannel)
                .HasComment("0 => all channel like sms, email\r\n1 => only sms\r\n2=> only email")
                .HasColumnName("otp_channel");
            entity.Property(e => e.Password)
                .HasMaxLength(191)
                .HasColumnName("password");
            entity.Property(e => e.PermissionVersion).HasColumnName("permission_version");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.QuestionOne)
                .HasMaxLength(255)
                .HasColumnName("question_one");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.ResetPasswordToken)
                .HasMaxLength(20)
                .HasColumnName("reset_password_token");
            entity.Property(e => e.SectorId).HasColumnName("sector_id");
            entity.Property(e => e.SecurityImageId)
                .HasComment("id from security_images table")
                .HasColumnName("security_image_id");
            entity.Property(e => e.SelfDeactivationDate)
                .HasComment("User deactivation date ")
                .HasColumnType("datetime")
                .HasColumnName("self_deactivation_date");
            entity.Property(e => e.SessionId)
                .HasMaxLength(150)
                .HasComment("Stores the id of the user session")
                .HasColumnName("session_id");
            entity.Property(e => e.Settings)
                .HasColumnType("text")
                .HasColumnName("settings");
            entity.Property(e => e.Social).HasColumnName("social");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM")
                .HasColumnName("status");
            entity.Property(e => e.TcNumber)
                .HasMaxLength(100)
                .HasColumnName("tc_number");
            entity.Property(e => e.TicketitAdmin).HasColumnName("ticketit_admin");
            entity.Property(e => e.TicketitAgent).HasColumnName("ticketit_agent");
            entity.Property(e => e.TokenEmail)
                .HasMaxLength(100)
                .HasColumnName("token_email");
            entity.Property(e => e.TokenEmailDatetime)
                .HasColumnType("datetime")
                .HasColumnName("token_email_datetime");
            entity.Property(e => e.TokenPhone)
                .HasMaxLength(100)
                .HasColumnName("token_phone");
            entity.Property(e => e.TokenPhoneDatetime)
                .HasColumnType("datetime")
                .HasColumnName("token_phone_datetime");
            entity.Property(e => e.UniqueInvitationLinkKey)
                .HasMaxLength(255)
                .HasColumnName("unique_invitation_link_key");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedPasswordAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_password_at");
            entity.Property(e => e.UserCategory)
                .HasDefaultValueSql("'1'")
                .HasComment("1=>UNKNOWN, 2=>UNVERIFIED, 3=>VERIFIED, 4=>CONTRACT")
                .HasColumnName("user_category");
            entity.Property(e => e.UserPrivilegeType)
                .HasDefaultValueSql("'1'")
                .HasComment("1 =  global, who can see all records of merchant,  0 = local, who  can  see only his/her own created  records")
                .HasColumnName("user_privilege_type");
            entity.Property(e => e.UserType)
                .HasComment("0=>customer; 1=>admin; 2=>merchant; 3=>submerchant")
                .HasColumnName("user_type");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
            entity.Property(e => e.VerificationToken)
                .HasColumnType("text")
                .HasColumnName("verification_token");
            entity.Property(e => e.Verified).HasColumnName("verified");
            entity.Property(e => e.WrongSecretAnswerAttempt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("wrong_secret_answer_attempt");
        });

        modelBuilder.Entity<UserActionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_action_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionId)
                .HasComment("0 => Defult\r\n1 => USER_UPDATE\r\n2 => ROLE_UPDATE\r\n3 => USERGROUP_UPDATE\r\n4 => USERGROUP_ROLE_ASSOCIATION_UPDATE\r\n5 => ROLE_PAGE_ASSOCIATION_UPDATE")
                .HasColumnName("action_id");
            entity.Property(e => e.ApprovedBy)
                .HasComment("Approve by using on maker checker")
                .HasColumnName("approved_by");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasComment("user email")
                .HasColumnName("email");
            entity.Property(e => e.Gsm)
                .HasMaxLength(100)
                .HasComment("user gsm ")
                .HasColumnName("gsm");
            entity.Property(e => e.ProcessedBy)
                .HasComment("process by using on maker checker")
                .HasColumnName("processed_by");
            entity.Property(e => e.Status)
                .HasComment("0=>awaiting, 1=>approved")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("1=>Banned, 2=>Blocked, 3=>Failed Login, user Action History")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(191)
                .HasComment("user first name and last name")
                .HasColumnName("user_name");
            entity.Property(e => e.UserType)
                .HasComment("0=>customer; 1=>admin; 2=>merchant; 3=>submerchant")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<UserAnnouncement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_announcements")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnnouncementId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("announcement_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasComment("0=>unread, 1=>read")
                .HasColumnName("is_read");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<UserAwaitingCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_awaiting_categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionBy).HasColumnName("action_by");
            entity.Property(e => e.ContractedFile)
                .HasMaxLength(255)
                .HasColumnName("contracted_file");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FromCategory).HasColumnName("from_category");
            entity.Property(e => e.RejectReason)
                .HasMaxLength(255)
                .HasColumnName("reject_reason");
            entity.Property(e => e.RequestedUserId).HasColumnName("requested_user_id");
            entity.Property(e => e.RequestedUserName)
                .HasMaxLength(100)
                .HasColumnName("requested_user_name");
            entity.Property(e => e.Status)
                .HasComment("0=>pending, 1=>approved, 2=>rejected")
                .HasColumnName("status");
            entity.Property(e => e.ToCategory).HasColumnName("to_category");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<UserBankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_bank_accounts")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(150)
                .HasColumnName("account_holder_name");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(50)
                .HasColumnName("account_no");
            entity.Property(e => e.BankName)
                .HasMaxLength(150)
                .HasColumnName("bank_name");
            entity.Property(e => e.BranchCode)
                .HasMaxLength(50)
                .HasColumnName("branch_code");
            entity.Property(e => e.BranchName)
                .HasMaxLength(150)
                .HasColumnName("branch_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.StaticBankId)
                .HasComment("primary key of banks table")
                .HasColumnName("static_bank_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SwiftCode)
                .HasMaxLength(50)
                .HasColumnName("swift_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserChangeHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_change_histories")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomReason)
                .HasMaxLength(255)
                .HasColumnName("custom_reason");
            entity.Property(e => e.NewValue)
                .HasMaxLength(50)
                .HasColumnName("new_value");
            entity.Property(e => e.OldValue)
                .HasMaxLength(50)
                .HasColumnName("old_value");
            entity.Property(e => e.ProcessedBy).HasColumnName("processed_by");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.Status)
                .HasComment("0=>awaiting, 1=> approved")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("1=>gsm, 2=>email")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserCurrenciesLimit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_currencies_limits")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrentMaxAllowValue)
                .HasColumnType("double(12,2)")
                .HasColumnName("current_max_allow_value");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_devices")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.UserId, "user_devices_user_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApnsToken)
                .HasMaxLength(191)
                .HasColumnName("apns_token");
            entity.Property(e => e.AppUniqueKey)
                .HasMaxLength(191)
                .HasColumnName("app_unique_key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeviceBrand)
                .HasMaxLength(191)
                .HasColumnName("device_brand");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(191)
                .HasColumnName("device_name");
            entity.Property(e => e.FirstConnectionIp)
                .HasMaxLength(191)
                .HasColumnName("first_connection_ip");
            entity.Property(e => e.HuaweiPushNotificationKey)
                .HasMaxLength(191)
                .HasColumnName("huawei_push_notification_key");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("'1'")
                .HasComment("0=>false, 1=>true")
                .HasColumnName("is_active");
            entity.Property(e => e.IsTablet)
                .HasComment("0=>false, 1=>true")
                .HasColumnName("is_tablet");
            entity.Property(e => e.NetworkOperator)
                .HasMaxLength(191)
                .HasColumnName("network_operator");
            entity.Property(e => e.PushNotificationKey)
                .HasMaxLength(191)
                .HasColumnName("push_notification_key");
            entity.Property(e => e.SystemVersion)
                .HasMaxLength(191)
                .HasColumnName("system_version");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(191)
                .HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_documents")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Document)
                .HasMaxLength(191)
                .HasColumnName("document");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserFavouriteOperation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_favourite_operations")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankStaticId).HasColumnName("bank_static_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Data)
                .HasComment("api request input params")
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.FavouriteUserId)
                .HasComment("user id of selected favourite person")
                .HasColumnName("favourite_user_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(191)
                .HasColumnName("first_name");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(50)
                .HasColumnName("gsm_number");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.LastName)
                .HasMaxLength(191)
                .HasColumnName("last_name");
            entity.Property(e => e.OperationType)
                .HasComment("1 = send money, 2 = request money, 3 = withdrawal, 4 = bill payment")
                .HasColumnName("operation_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserHideMerchant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_hide_merchants")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.UserId, "unique_index").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.UserId)
                .HasComment("admin user id")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<UserLoginAlertSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_login_alert_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("created_by_user_id");
            entity.Property(e => e.EmailAddresses)
                .HasColumnType("text")
                .HasColumnName("email_addresses")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FromTime)
                .HasColumnType("time")
                .HasColumnName("from_time");
            entity.Property(e => e.IsNotificationTypeEmail)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive")
                .HasColumnName("is_notification_type_email");
            entity.Property(e => e.IsNotificationTypeSms)
                .HasDefaultValueSql("'0'")
                .HasComment("1=active, 0=inactive")
                .HasColumnName("is_notification_type_sms");
            entity.Property(e => e.SmsNumbers)
                .HasColumnType("text")
                .HasColumnName("sms_numbers")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active, 0=inactive")
                .HasColumnName("status");
            entity.Property(e => e.ToTime)
                .HasColumnType("time")
                .HasColumnName("to_time");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedByUserId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("updated_by_user_id");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'1'")
                .HasComment("0=Customer, 1=Admin, 2 = Merchant")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_profiles")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ActivationCode, "activation_code").IsUnique();

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivationCode)
                .HasMaxLength(25)
                .HasColumnName("activation_code");
            entity.Property(e => e.ActivationCodeCount)
                .HasDefaultValueSql("'0'")
                .HasColumnName("activation_code_count");
            entity.Property(e => e.ActivationCodeUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("activation_code_updated_at");
            entity.Property(e => e.ActivationRemoteReferenceId)
                .HasMaxLength(255)
                .HasColumnName("activation_remote_reference_id");
            entity.Property(e => e.ActivationStatusCode)
                .HasMaxLength(10)
                .HasColumnName("activation_status_code");
            entity.Property(e => e.ActivationStatusDescription)
                .HasMaxLength(255)
                .HasColumnName("activation_status_description");
            entity.Property(e => e.ActivationWrongAttempt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("activation_wrong_attempt");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EnableMoneyTransfer)
                .HasDefaultValueSql("'1'")
                .HasComment("0=disabled; 1=enabled")
                .HasColumnName("enable_money_transfer");
            entity.Property(e => e.IncomeInfo)
                .HasDefaultValueSql("'0.0000'")
                .HasComment("user income info")
                .HasColumnType("double(12,4)")
                .HasColumnName("income_info");
            entity.Property(e => e.InfoChangeCount)
                .HasDefaultValueSql("'0'")
                .HasComment("when a user change information here it will be count")
                .HasColumnName("info_change_count");
            entity.Property(e => e.IsFaceToFaceVerified)
                .HasComment("0 -> not_verifed;1 -> verifed;")
                .HasColumnName("is_face_to_face_verified");
            entity.Property(e => e.IsIntegrationCalled)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_integration_called");
            entity.Property(e => e.IsMoneyTransferMaxExceed)
                .HasComment("0=>No; 1=>Yes;")
                .HasColumnName("is_money_transfer_max_exceed");
            entity.Property(e => e.IsShowBalance)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=yes, 0=no")
                .HasColumnName("is_show_balance");
            entity.Property(e => e.IsShowRecentActivities)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_show_recent_activities");
            entity.Property(e => e.IsWelcomeEmailSent)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1 => Email Sent, 0 => Email Not Sent Yet")
                .HasColumnName("is_welcome_email_sent");
            entity.Property(e => e.KycUpdatedAt)
                .HasComment("date of kyc completed by user")
                .HasColumnType("datetime")
                .HasColumnName("kyc_updated_at");
            entity.Property(e => e.MoneyTransferFromTotalBalance)
                .HasDefaultValueSql("'0'")
                .HasComment("0=>No; 1=>Yes;")
                .HasColumnName("money_transfer_from_total_balance");
            entity.Property(e => e.NumberOfAllowedCreditCard)
                .HasDefaultValueSql("'2'")
                .HasColumnName("number_of_allowed_credit_card");
            entity.Property(e => e.NumberOfIncomeModification)
                .HasDefaultValueSql("'0'")
                .HasComment("User can't update income info more than three time's for yemekpay")
                .HasColumnName("number_of_income_modification");
            entity.Property(e => e.OtherSector)
                .HasMaxLength(50)
                .HasComment("other sector name")
                .HasColumnName("other_sector");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=active; 2=suspected; 3=banned")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserPushNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_push_notifications", tb => tb.HasComment("track push notifications read status"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsRead)
                .HasComment("0=>unread, 1=>read")
                .HasColumnName("is_read");
            entity.Property(e => e.OutGoingPushNotificationId)
                .HasComment("out_going_push_notifications primary key")
                .HasColumnName("out_going_push_notification_id");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("1=>pending, 2=>in progress, 3=> successfully sent, 4=>failed")
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .HasComment("users primary key")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_roles")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.UserId, e.RoleId }, "user_id_role_id").IsUnique();

            entity.HasIndex(e => e.UserId, "user_roles_user_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_roles_user_id_foreign");
        });

        modelBuilder.Entity<UserSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionName).HasColumnName("action_name");
            entity.Property(e => e.IsAppNotificationEnable)
                .HasComment("0=>disabled, 1=>enabled")
                .HasColumnName("is_app_notification_enable");
            entity.Property(e => e.IsEmailEnable)
                .HasComment("0=disabled; 1=enabled")
                .HasColumnName("is_email_enable");
            entity.Property(e => e.IsSmsEnable)
                .HasComment("0=disabled; 1=enabled")
                .HasColumnName("is_sms_enable");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserTrustedDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_trusted_devices")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(50)
                .HasComment("mac id of trusted device")
                .HasColumnName("device_id");
            entity.Property(e => e.ExpiredAt)
                .HasComment("expiration of being treated as trusted device")
                .HasColumnType("datetime")
                .HasColumnName("expired_at");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'0'")
                .HasComment("user id or merchant auth user id")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<UserUsergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_usergroups")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<UserUsergroupSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_usergroup_settings")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IsAllowB2bWithoutDoc).HasColumnName("is_allow_b2b_without_doc");
            entity.Property(e => e.IsAllowCreateB2b)
                .HasComment("1=allowed, 0=not allowed")
                .HasColumnName("is_allow_create_b2b");
            entity.Property(e => e.IsAllowCreateB2c)
                .HasComment("1=allowed, 0=not allowed")
                .HasColumnName("is_allow_create_b2c");
            entity.Property(e => e.IsAllowCreateDeposit)
                .HasComment("1=allowed, 0=not allowed")
                .HasColumnName("is_allow_create_deposit");
            entity.Property(e => e.IsAllowCreateWithdrawal)
                .HasComment("1=allowed, 0=not allowed")
                .HasColumnName("is_allow_create_withdrawal");
            entity.Property(e => e.IsAllowDirectExport).HasColumnName("is_allow_direct_export");
            entity.Property(e => e.IsShowAuthEmail)
                .HasComment("1=allowed, 0=not allowed")
                .HasColumnName("is_show_auth_email");
            entity.Property(e => e.IsShowWebsite)
                .HasComment("1=show, 0=hide")
                .HasColumnName("is_show_website");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserViewedNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_viewed_notifications");

            entity.HasIndex(e => e.NotificationId, "notification_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Usergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usergroups")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DashboardUrl)
                .HasMaxLength(255)
                .HasColumnName("dashboard_url");
            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .HasColumnName("group_name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UsergroupNotificationSubcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usergroup_notification_subcategories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsEmail).HasColumnName("is_email");
            entity.Property(e => e.IsPush).HasColumnName("is_push");
            entity.Property(e => e.IsSms).HasColumnName("is_sms");
            entity.Property(e => e.NotificationSubcategoryId).HasColumnName("notification_subcategory_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<UsergroupRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usergroup_roles")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");
        });

        modelBuilder.Entity<UsertypeSubmodule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usertype_submodules")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SubModuleId).HasColumnName("sub_module_id");
            entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
        });

        modelBuilder.Entity<VirtualAccountMoneytransferRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("virtual_account_moneytransfer_requests")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasComment("money transfer amount")
                .HasColumnType("double(12,4)")
                .HasColumnName("amount");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasComment("any kind of description")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MerchantId)
                .HasComment("merchants table primary key")
                .HasColumnName("merchant_id");
            entity.Property(e => e.MerchantVirtualAccountWalletId)
                .HasComment("merchant_virtual_account table primary key")
                .HasColumnName("merchant_virtual_account_wallet_id");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasComment("unique transaction id to send to walletgate side for topup")
                .HasColumnName("payment_id");
            entity.Property(e => e.ProcessedAt)
                .HasComment("cron job process datetime")
                .HasColumnType("datetime")
                .HasColumnName("processed_at");
            entity.Property(e => e.SendId)
                .HasComment("sends table primary key")
                .HasColumnName("send_id");
            entity.Property(e => e.Status)
                .HasComment("0 = pending, 1 = completed, 2 = waiting for remove")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("vouchers")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.VoucherCode, "vouchers_voucher_id_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.IsLoaded)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_loaded");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserLoader).HasColumnName("user_loader");
            entity.Property(e => e.VoucherAmount).HasColumnName("voucher_amount");
            entity.Property(e => e.VoucherCode)
                .HasMaxLength(191)
                .HasColumnName("voucher_code");
            entity.Property(e => e.VoucherFee).HasColumnName("voucher_fee");
            entity.Property(e => e.VoucherValue).HasColumnName("voucher_value");
            entity.Property(e => e.WalletId).HasColumnName("wallet_id");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wallets")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.UserId, e.CurrencyId }, "wallets_user_id_currency_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowCcDeposit)
                .HasDefaultValueSql("'0'")
                .HasColumnName("allow_cc_deposit");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(16,4)")
                .HasColumnName("amount");
            entity.Property(e => e.BlockAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(16,4)")
                .HasColumnName("block_amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.NonWithdrawableAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(16,4)")
                .HasColumnName("non_withdrawable_amount");
            entity.Property(e => e.PendingSaleAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(16,4)")
                .HasColumnName("pending_sale_amount");
            entity.Property(e => e.RollingAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(16,4)")
                .HasColumnName("rolling_amount");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WithdrawableAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(16,4)")
                .HasColumnName("withdrawable_amount");
        });

        modelBuilder.Entity<WalletAnnouncement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wallet_announcements")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("admin_id");
            entity.Property(e => e.AdminName)
                .HasMaxLength(191)
                .HasColumnName("admin_name");
            entity.Property(e => e.AnnouncementDate)
                .HasColumnType("datetime")
                .HasColumnName("announcement_date");
            entity.Property(e => e.AnnouncementEnd)
                .HasColumnType("datetime")
                .HasColumnName("announcement_end");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EmailAttachment)
                .HasMaxLength(191)
                .HasColumnName("email_attachment");
            entity.Property(e => e.EnBody)
                .HasColumnType("text")
                .HasColumnName("en_body");
            entity.Property(e => e.EnSubject)
                .HasMaxLength(191)
                .HasColumnName("en_subject");
            entity.Property(e => e.IsEmail)
                .HasDefaultValueSql("'0'")
                .HasComment("0=no, 1=yes")
                .HasColumnName("is_email");
            entity.Property(e => e.IsPanel)
                .HasDefaultValueSql("'0'")
                .HasComment("0=no, 1=yes")
                .HasColumnName("is_panel");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'0'")
                .HasColumnName("order");
            entity.Property(e => e.PanelAttachment)
                .HasMaxLength(191)
                .HasColumnName("panel_attachment");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'2'")
                .HasComment("2=active, 1=inactive")
                .HasColumnName("status");
            entity.Property(e => e.TrBody)
                .HasColumnType("text")
                .HasColumnName("tr_body");
            entity.Property(e => e.TrSubject)
                .HasMaxLength(191)
                .HasColumnName("tr_subject");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserCategory)
                .HasDefaultValueSql("'1'")
                .HasComment("1=not verified, 2=verified, 3=verified plus")
                .HasColumnName("user_category");
            entity.Property(e => e.UserType)
                .HasComment("0=>customer; 1=>admin; 2=>merchant; 3=>submerchant; 4=>integrator; 5=>sales admin; 6=>sales expert")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<WalletGateSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("wallet_gate_settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .HasColumnName("currency_code");
            entity.Property(e => e.NationalIdOrTaxNo)
                .HasMaxLength(50)
                .HasColumnName("national_id_or_tax_no");
            entity.Property(e => e.ReceiverBankCode)
                .HasMaxLength(10)
                .HasColumnName("receiver_bank_code");
            entity.Property(e => e.ReceiverBankName)
                .HasMaxLength(100)
                .HasColumnName("receiver_bank_name");
            entity.Property(e => e.ReceiverIban)
                .HasMaxLength(50)
                .HasColumnName("receiver_iban");
            entity.Property(e => e.RegexDefinitionResultData)
                .HasMaxLength(50)
                .HasColumnName("regex_definition_result_data");
            entity.Property(e => e.SenderAccountNumber)
                .HasMaxLength(50)
                .HasColumnName("sender_account_number");
            entity.Property(e => e.SenderBankCode)
                .HasMaxLength(10)
                .HasColumnName("sender_bank_code");
            entity.Property(e => e.SenderBankName)
                .HasMaxLength(100)
                .HasColumnName("sender_bank_name");
            entity.Property(e => e.SenderIban)
                .HasMaxLength(50)
                .HasColumnName("sender_iban");
            entity.Property(e => e.SenderWalletNumber)
                .HasMaxLength(50)
                .HasColumnName("sender_wallet_number");
            entity.Property(e => e.TenantCode)
                .HasMaxLength(10)
                .HasColumnName("tenant_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WalletLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wallet_logs")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.MigrationStatus, "idx_migration_status");

            entity.HasIndex(e => e.UniqueString, "unique_string").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionName)
                .HasMaxLength(30)
                .HasColumnName("action_name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.AfterAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("after_amount");
            //entity.Property(e => e.AfterLog)
            //    .HasColumnType("text")
            //    .HasColumnName("after_log");
            entity.Property(e => e.AfterNonwithdrawableAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("after_nonwithdrawable_amount");
            entity.Property(e => e.AfterRollingAmount)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(16,4)")
                .HasColumnName("after_rolling_amount");
            entity.Property(e => e.AfterWithdrawableAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("after_withdrawable_amount");
            entity.Property(e => e.BeforeAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("before_amount");
            //entity.Property(e => e.BeforeLog)
            //    .HasColumnType("text")
            //    .HasColumnName("before_log");
            entity.Property(e => e.BeforeNonwithdrawableAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("before_nonwithdrawable_amount");
            entity.Property(e => e.BeforeRollingAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("before_rolling_amount");
            entity.Property(e => e.BeforeWithdrawableAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("before_withdrawable_amount");
            entity.Property(e => e.EffectPendingSaleAmount)
                .HasMaxLength(20)
                .HasColumnName("effect_pending_sale_amount");
            entity.Property(e => e.BeforePendingSaleAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("before_pending_sale_amount");
            entity.Property(e => e.AfterPendingSaleAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("after_pending_sale_amount");
            entity.Property(e => e.BlockAmount)
                .HasColumnType("double(16,4)")
                .HasColumnName("block_amount");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EffectAmount)
                .HasMaxLength(20)
                .HasColumnName("effect_amount");
            entity.Property(e => e.EffectNonwithdrawableAmount)
                .HasMaxLength(20)
                .HasColumnName("effect_nonwithdrawable_amount");
            entity.Property(e => e.EffectRollingAmount)
                .HasMaxLength(20)
                .HasColumnName("effect_rolling_amount");
            entity.Property(e => e.EffectWithdrawableAmount)
                .HasMaxLength(20)
                .HasColumnName("effect_withdrawable_amount");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .HasColumnName("event_name");
            entity.Property(e => e.MigrationStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("migration_status");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ReferenceId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("reference_id");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(20)
                .HasColumnName("reference_type");
            entity.Property(e => e.UniqueString).HasColumnName("unique_string");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Withdrawal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("withdrawals")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.PaymentId, "payment_id").IsUnique();

            entity.HasIndex(e => e.UniqueId, "unique_id").IsUnique();

            entity.HasIndex(e => e.UniqueString, "unique_string").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(200)
                .HasColumnName("account_holder_name");
            entity.Property(e => e.ActionById)
                .HasComment("Authenticated user id")
                .HasColumnName("action_by_id");
            entity.Property(e => e.AdminApproveById)
                .HasDefaultValueSql("'0'")
                .HasColumnName("admin_approve_by_id");
            entity.Property(e => e.AdminApproveByName)
                .HasMaxLength(100)
                .HasColumnName("admin_approve_by_name");
            entity.Property(e => e.AdminProcessDate)
                .HasColumnType("timestamp")
                .HasColumnName("admin_process_date");
            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .HasColumnName("bank_name");
            entity.Property(e => e.BankStaticId).HasColumnName("bank_static_id");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.DestinationType)
                .HasComment("1=IBAN, 2=Bank Account, 3=paypal, 4=stipe, 5=authorize.net, 6=Automatic Withdrawal")
                .HasColumnName("destination_type");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("fee");
            entity.Property(e => e.FlowType)
                .HasComment("0=default (finflow disable & manually approve/reject); 1 = sent to finflow from merchant panel and successful; 2 = sent to finflow from merchant panel and rejected, now admin can send again or manually approve/reject; 3 = sent to finflow from admin panel and successful; 4 = sent to finflow from admin panel and rejected, 5 = customized cost , 6 = imported withdrawal")
                .HasColumnName("flow_type");
            entity.Property(e => e.Gross)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("gross");
            entity.Property(e => e.GsmNumber)
                .HasMaxLength(30)
                .HasColumnName("gsm_number");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Net)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("net");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id")
                .UseCollation("utf8mb3_unicode_ci");
            entity.Property(e => e.PlatformId)
                .HasMaxLength(50)
                .HasColumnName("platform_id");
            entity.Property(e => e.RefundReason)
                .HasMaxLength(255)
                .HasColumnName("refund_reason");
            entity.Property(e => e.RejectReason)
                .HasMaxLength(255)
                .HasColumnName("reject_reason");
            entity.Property(e => e.RemoteTransactionId)
                .HasMaxLength(20)
                .HasComment("sorguno number that will be generated on bank side")
                .HasColumnName("remote_transaction_id");
            entity.Property(e => e.SipayBankAccountId).HasColumnName("sipay_bank_account_id");
            entity.Property(e => e.SwiftCode)
                .HasMaxLength(50)
                .HasColumnName("swift_code");
            entity.Property(e => e.TransactionStateId).HasColumnName("transaction_state_id");
            entity.Property(e => e.UniqueId)
                .HasMaxLength(50)
                .HasColumnName("unique_id");
            entity.Property(e => e.UniqueString).HasColumnName("unique_string");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("user_type");
            entity.Property(e => e.WalletId).HasColumnName("wallet_id");
            entity.Property(e => e.WithdrawalMethodId).HasColumnName("withdrawal_method_id");
        });

        modelBuilder.Entity<WithdrawalBankName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("withdrawal_bank_names");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WithdrawalMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("withdrawal_methods")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(200)
                .HasColumnName("account_holder_name");
            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .HasColumnName("bank_name");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FixedFee)
                .HasColumnType("double(8,2)")
                .HasColumnName("fixed_fee");
            entity.Property(e => e.JsonData)
                .HasColumnType("text")
                .HasColumnName("json_data");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.PercentageFee)
                .HasColumnType("double(8,2)")
                .HasColumnName("percentage_fee");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WithdrawalOperation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("withdrawal_operations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cot)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnType("double(12,4)")
                .HasColumnName("cot");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.SipayBankId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sipay_bank_id");
            entity.Property(e => e.Type)
                .HasComment("1 = withdrawal reject, 2 = withdrawal Approve, 3 = AML withdrawal Reject, 4 = AML withdrawal approve, 5 = Cashout to bank reject, 6 = Cashout to bank approve")
                .HasColumnName("type");
            entity.Property(e => e.WithdrawalId).HasColumnName("withdrawal_id");
        });

        modelBuilder.Entity<WithdrawalOperationsOutgoing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("withdrawal_operations_outgoing")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PaymentId, "unique_payment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyObject)
                .HasColumnType("text")
                .HasColumnName("currency_object");
            entity.Property(e => e.ExtraData)
                .HasColumnType("text")
                .HasColumnName("extra_data");
            entity.Property(e => e.MerchantObject)
                .HasColumnType("text")
                .HasColumnName("merchant_object");
            entity.Property(e => e.OperationId)
                .HasComment("id from withdrawal_operations table")
                .HasColumnName("operation_id");
            entity.Property(e => e.OperationType)
                .HasComment("1=withdrawal reject, 2=withdrawal Approve, 3=AML withdrawal Reject, 4=AML withdrawal approve, 5=Cashout to bank reject, 6=Cashout to bank approve")
                .HasColumnName("operation_type");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(50)
                .HasColumnName("payment_id");
            entity.Property(e => e.TransactionObject)
                .HasColumnType("text")
                .HasColumnName("transaction_object");
            entity.Property(e => e.UserObject)
                .HasColumnType("text")
                .HasColumnName("user_object");
        });

        modelBuilder.Entity<WithdrawalSavedAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("withdrawal_saved_accounts")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountHolder)
                .HasMaxLength(100)
                .HasColumnName("account_holder");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(100)
                .HasColumnName("account_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.SwiftCode)
                .HasMaxLength(100)
                .HasColumnName("swift_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WithdrawBankId).HasColumnName("withdraw_bank_id");
        });

        modelBuilder.Entity<WixStateData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wix_state_datas")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdempotencyKeyType)
                .HasMaxLength(100)
                .HasColumnName("idempotency_key_type");
            entity.Property(e => e.IdempotencyKeyValue)
                .HasMaxLength(100)
                .HasColumnName("idempotency_key_value");
            entity.Property(e => e.ResponseData)
                .HasColumnType("text")
                .HasColumnName("response_data");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WrongPasswordHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("wrong_password_histories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id)
                .HasComment("primary key of this table")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasComment("created date time")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UserId)
                .HasComment("primary key of users table")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<YapiCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("yapi_commissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComFixed)
                .HasColumnType("double(12,4)")
                .HasColumnName("com_fixed");
            entity.Property(e => e.ComPercentage)
                .HasColumnType("double(12,4)")
                .HasColumnName("com_percentage");
            entity.Property(e => e.CreatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.FromAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("from_amount");
            entity.Property(e => e.MerchantId)
                .HasMaxLength(200)
                .HasColumnName("merchant_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.ToAmount)
                .HasColumnType("double(12,4)")
                .HasColumnName("to_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<YapiToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("yapi_tokens");

            entity.HasIndex(e => e.ReferenceNo, "reference_no").IsUnique();

            entity.HasIndex(e => new { e.Token, e.OrderId }, "token").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempt)
                .HasDefaultValueSql("'0'")
                .HasColumnName("attempt");
            entity.Property(e => e.BrandShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("brand_share");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(5)
                .HasColumnName("currency_code");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(10)
                .HasColumnName("error_code");
            entity.Property(e => e.ErrorMessage)
                .HasMaxLength(100)
                .HasColumnName("error_message");
            entity.Property(e => e.ExpiredOn)
                .HasColumnType("datetime")
                .HasColumnName("expired_on");
            entity.Property(e => e.Gross).HasColumnName("gross");
            entity.Property(e => e.IntegratorShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("integrator_share");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(50)
                .HasColumnName("invoice_id")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            entity.Property(e => e.MerchantShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("merchant_share");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(100)
                .HasColumnName("reference_no");
            entity.Property(e => e.Status)
                .HasComment("0 = Not Processed Yet, 1 = Processed")
                .HasColumnName("status");
            entity.Property(e => e.SubMerchantShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("sub_merchant_share");
            entity.Property(e => e.TaxiShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("taxi_share");
            entity.Property(e => e.TerminalNo)
                .HasMaxLength(100)
                .HasColumnName("terminal_no");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .HasColumnName("token")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.TotalCommission)
                .HasColumnType("double(12,4)")
                .HasColumnName("total_commission");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.YkbShare)
                .HasColumnType("double(12,4)")
                .HasColumnName("ykb_share");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
