using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Services;

namespace SharedLibrary.Interfaces;

public interface IUnitOfWork
{
    
    public ApplicationDbContext ApplicationDbContext { get; set; }
    public ILogger Logger { get; set; }
    
    public ICacheService CacheService { get; set; }
    
    
    public IIpAddressService IpAddressService{get;set;}
    
    public ILogService LogService { get; set; }
    
    public IHttpContextAccessor HttpContextAccessor { get; set; }
    
    
    
    
    IUnitOfWork GetService();
    //IMerchantIUnitRepository MerchantIUnitRepository { get; }
    IMerchantRepository MerchantRepository { get; }
    IMerchantSettingRepository MerchantSettingRepository { get; }
    IPosInstallmentRepository PosInstallmentRepository { get; }
    IPosCampaignRepository PosCampaignRepository { get; }
    IPosRedirectionRepository PosRedirectionRepository { get; }
    IPosRiskyCountryRepository PosRiskyCountryRepository { get; }
    IPosRepository PosRepository { get; }
    IBankRepository BankRepository { get; }
    IBankReferenceInformationRepository BankReferenceInformationRepository { get; }
    ICurrencyRepository CurrencyRepository { get; }
    IMerchantsCommissionRepository MerchantsCommissionRepository { get; }
    IMerchantPosCommissionRepository MerchantPosCommissionRepository { get; }
    ICommercialCardCommissionRepository CommercialCardCommissionRepository { get; }
    ISinglePaymentMerchantCommissionRepository SinglePaymentMerchantCommissionRepository { get; }


    public IArchivedRequestRepository ArchivedRequestRepository { get; }

    public ITmpPaymentRecordRepository TmpPaymentRecordRepository { get; }
    public ITmpObjectStorageRepository TmpObjectStorageRepository { get; }
    public IPurchaseRequestRepository PurchaseRequestRepository { get; }
   
    public ISaleRepository SaleRepository { get; }

    public ICcBlockListsRepository CcBlockListsRepository { get; }
    public IHolidaySettingRepository HolidaySettingRepository { get; }
    
    public ITransactionRepository TransactionRepository { get;}
    
    public ISaleReportRepository SaleReportRepository { get; }

    public IRefundHistoryRepository RefundHistoryRepository { get; }
    
    public IRollingReserveRepository RollingReserveRepository { get; }
    
    public IMerchantSaleRepository MerchantSaleRepository { get;}
    
    public IWalletRepository WalletRepository { get; }
    
    public IRollingBalanceRepository RollingBalanceRepository { get; }
    
    public IMerchantWebHookKeysRepository MerchantWebHookKeysRepository { get; }
    
    
    public ISaveCardsRepository SaveCardsRepository { get; }
    
    public ITmpBankResponseRepository TmpBankResponseRepository { get; }
    public ICurrencyConversionRateRepository CurrencyConversionRateRepository { get; }
    public IDirectPaymentLinkRepository DirectPaymentLinkRepository { get; }
    
    public ISaleRecurringRepository SaleRecurringRepository { get; }
    
    
    public ISaleRecurringPaymentScheduleRepository SaleRecurringPaymentScheduleRepository { get; }
    
    
    public ISaleRecurringHistoryRepository SaleRecurringHistoryRepository { get; }
    
    public ISaleRecurringCardRepository SaleRecurringCardRepository { get; }

    public IDbTransaction BeginTransaction();
    Task CompleteAsync();

    public void Complete();




}