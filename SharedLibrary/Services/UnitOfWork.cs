using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace SharedLibrary.Services;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext context;
    private ILogger logger;
    private ICacheService cacheService;
    private IIpAddressService ipAddressService;
    private ILogService logService;
    private IHttpContextAccessor _httpContextAccessor;

    public UnitOfWork(IIpAddressService ipAddressService, ApplicationDbContext context, ILoggerFactory loggerFactory, ICacheService cacheService,
         IHttpContextAccessor httpContextAccessor)
    {
        this.context = context;
        this.cacheService = cacheService;
        this.logger = loggerFactory.CreateLogger("Logs");
        this.ipAddressService = ipAddressService;
        this._httpContextAccessor = httpContextAccessor;
        this.logService = new LogService(this.logger, loggerFactory);
    }


    public ApplicationDbContext ApplicationDbContext
    {
        get{return this.context;}
        set{this.context = value;}
    }

    public ILogger Logger
    {
        get{return this.logger;}
        set{this.logger = value;}
    }

    public ICacheService CacheService
    {
        get
        {return this.cacheService;}
        set{this.cacheService = value;}
    }

    

    public IIpAddressService IpAddressService
    {
        get { return this.ipAddressService; }
        set { this.ipAddressService = value; }
    }

    public ILogService LogService
    {
        get { return this.logService; }
        set { this.logService = value; }
    }
    

    public IHttpContextAccessor HttpContextAccessor
    {
        get { return this._httpContextAccessor;}
        set { this._httpContextAccessor = value; }
    }
    
    
    public IMerchantRepository MerchantRepository
    {
        get { return new MerchantRepository(this); }

    }
    
    
    public IMerchantSettingRepository MerchantSettingRepository
    {
        get
        {
            return new MerchantSettingRepository(this);
        }
    }

    public IPosInstallmentRepository PosInstallmentRepository
    {
        get { return new PosInstallmentRepository(this); }
    }

    public IPosCampaignRepository PosCampaignRepository
    {
        get { return new PosCampaignRepository(this); }
    }

    public IPosRedirectionRepository PosRedirectionRepository
    {
        get
        {
            return new PosRedirectionRepository(this);
        }
    }

    public IPosRiskyCountryRepository PosRiskyCountryRepository
    {
        get
        {
            return new PosRiskyCountryRepository(this);
        }
    }

    public IPosRepository PosRepository
    {
        get
        {
            return new PosRepository(this);
        }
    }

    public IBankRepository BankRepository
    {
        get
        {
            return new BankRepository(this);
        }
    }
    
    
    public IBankReferenceInformationRepository BankReferenceInformationRepository
    {
        get
        {
            return new BankReferenceInformationRepository(this);
        }
    }

    public ICurrencyRepository CurrencyRepository
    {
        get
        {
            return new CurrencyRepository(this);
        }
    }

    public IMerchantsCommissionRepository MerchantsCommissionRepository
    {
        get
        {
            return new MerchantsCommissionRepository(this);
        }
    }

    public IMerchantPosCommissionRepository MerchantPosCommissionRepository
    {
        get
        {
            return new MerchantPosCommissionsRepository(this);
        }
    }

    public ICommercialCardCommissionRepository CommercialCardCommissionRepository
    {
        get
        {
            return new CommercialCardCommissionRepository(this);
        }
    }

    public ISinglePaymentMerchantCommissionRepository SinglePaymentMerchantCommissionRepository
    {
        get
        {
            return new SinglePaymentMerchantCommissionRepository(this);
        }
    }

    public IPurchaseRequestRepository PurchaseRequestRepository
    {
        get
        {
            return new PurchaseRequestRepository(this);
        }
    }
    
    public IArchivedRequestRepository ArchivedRequestRepository
    {
        get
        {
            return new ArchivedRequestRepository(this);
        }
    }

    public ITmpPaymentRecordRepository TmpPaymentRecordRepository
    {
        get
        {
            return new TmpPaymentRecordRepository(this);
        }
    }


    public IRollingReserveRepository RollingReserveRepository
    {
        get
        {
            return new RollingReserveRepository(this);
        }
    }

    public IMerchantSaleRepository MerchantSaleRepository
    {
        get
        {
            return new MerchantSaleRepository(this);
        }
        
    }

    public IWalletRepository WalletRepository
    {
        get
        {
            return new WalletRepository(this);
        }
    }

    public IRollingBalanceRepository RollingBalanceRepository
    {
        get
        {
            return new RollingBalanceRepository(this);
        }
    }

    public async Task CompleteAsync()
    {
        await this.ApplicationDbContext.SaveChangesAsync();
    }


    public void Complete()
    {
        ApplicationDbContext.SaveChanges();
    }

    public void Dispose()
    {
        this.ApplicationDbContext.Dispose();
    }

    public IUnitOfWork GetService()
    {
        return this;
    }






    public ITmpObjectStorageRepository TmpObjectStorageRepository
    {
        get
        {
            return new TmpObjectStorageRepository(this);
        }
    }

    public ISaleRepository SaleRepository
    {
        get { return new SaleRepository(this); }
    }



    public ISettlementRepository SettlementRepository
    {
        get
        {
            return new SettlementRepository(this);
        }
    }

    public IHolidaySettingRepository HolidaySettingRepository
    {
        get
        {
            return new HolidaySettingRepository(this);
        }
    }

    public ITransactionRepository TransactionRepository
    {
        get
        {
            return new TransactionRepository(this);
        }
    }

    public ICcBlockListsRepository CcBlockListsRepository
    {
        get
        {
            return new CCBlockListsRepository(this);
        }
    }
    
    public ISaleReportRepository SaleReportRepository
    {
        get
        {
            return new SaleReportRepository(this);
        }
    }
    
    
    public IRefundHistoryRepository RefundHistoryRepository
    {
        get
        {
            return new RefundHistoryRepository(this);
        }
    }

    public IMerchantWebHookKeysRepository MerchantWebHookKeysRepository
    {
        get
        {
            return new MerchantWebHookKeysRepository(this);
        }
    }


    public ISaveCardsRepository SaveCardsRepository
    {
        get
        {
            return new SaveCardsRepository(this);
        } 
        
    }

    public ITmpBankResponseRepository TmpBankResponseRepository
    {
        get
        {
            return new TmpBankResponseRepository(this);
        }
    }

    public ICurrencyConversionRateRepository CurrencyConversionRateRepository
    {
        get
        {
            return new CurrencyConversionRateRepository(this);
        }
    }

    public IDirectPaymentLinkRepository DirectPaymentLinkRepository
    {
        get
        {
            return new DirectPaymentLinkRepository(this);
        }
    }


    public ISaleRecurringRepository SaleRecurringRepository
    {
        
            get
            {
                return new SaleRecurringRepository(this);
            }
        
    }
    
    public ISaleRecurringPaymentScheduleRepository SaleRecurringPaymentScheduleRepository
    {
        
        get
        {
            return new SaleRecurringPaymentScheduleRepository(this);
        }
        
    }
    
    
    public ISaleRecurringHistoryRepository SaleRecurringHistoryRepository
    {
        
        get
        {
            return new SaleRecurringHistoryRepository(this);
        }
        
    }


    public ISaleRecurringCardRepository SaleRecurringCardRepository
    {
        get { return new SaleRecurringCardRepository(this); }
    }

    public async Task BeginTransactionAsync()
    {
        await this.ApplicationDbContext.Database.BeginTransactionAsync();
    }
    
    
    public IDbTransaction BeginTransaction()
    {
        var transaction = ApplicationDbContext.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
    
    
    public async Task CommitTransactionAsync()
    {
        await this.ApplicationDbContext.Database.CommitTransactionAsync();
    }


    public void CommitTransaction()
    {
        this.ApplicationDbContext.Database.CommitTransaction();
    }
    
    
    public async Task RollbackTransactionAsync()
    {
        await this.ApplicationDbContext.Database.RollbackTransactionAsync();
    }
    
    
    
    public void RollbackTransaction()
    {
        this.ApplicationDbContext.Database.RollbackTransaction();
    }
    
    




    
    
    
}