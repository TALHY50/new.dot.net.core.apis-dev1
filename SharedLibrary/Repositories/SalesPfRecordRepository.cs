using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using Bank = SharedLibrary.Models.Bank;

namespace SharedLibrary.Repositories
{
    public class SalesPfRecordRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        const int VERSION_ONE = 1;
        const int VERSION_TWO = 2;

        public SalesPfRecordRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Dictionary<string, string> GetPF(string order_id, Bank bankObj)
        {
            Dictionary<string, string> pfArr = new();

            Models.SalesPfRecord? salePFRecordsObj = _unitOfWork.ApplicationDbContext.SalesPfRecords.FirstOrDefault(s => s.OrderId == order_id && s.Version == VERSION_TWO);
            if (salePFRecordsObj != null && salePFRecordsObj.Version == VERSION_TWO)
            {
                if (bankObj.PaymentProvider == Constants.Constants.PaymentProvider.YAPI_VE_KREDI)
                {
                    string merchant_id = salePFRecordsObj.SubMerchantId ?? String.Empty;
                    string visa_mrc_pf_id = salePFRecordsObj.PfMerchantId ?? String.Empty;
                    string mcc = salePFRecordsObj.Mcc ?? String.Empty;
                    pfArr = new Dictionary<string, string>
                    {
                        { "mrcPfId", visa_mrc_pf_id },
                        { "subMrcId", merchant_id },
                        { "mcc", mcc }
                    };
                }

                if (bankObj.PaymentProvider == Constants.Constants.PaymentProvider.DENIZ_PTT)
                {
                    string merchant_id = salePFRecordsObj.PfMerchantId ?? String.Empty;
                    string name = salePFRecordsObj.PfMerchantName ?? String.Empty;
                    string client_identity_number = salePFRecordsObj.ClientIdentityNumber ?? String.Empty;
                    pfArr = new Dictionary<string, string>
                    {
                        { "SubMerchantCode", merchant_id.PadLeft(15, '0') },
                        { "SubMerchantName", name },
                        { "IdentityNumber", client_identity_number }
                    };
                }
            }
            return pfArr;
        }

        public bool InsertEntry(Dictionary<string, string> data)
        {
            SalesPfRecord model = new()
            {
                OrderId = data["order_id"],
                IdentityNin = data["identity_nin"],
                SubMerchantId = data["sub_merchant_id"],
                PfMerchantId = data["pf_merchant_id"] ?? "0",
                PfMerchantName = data["pf_merchant_name"] ?? String.Empty,
                Mcc = data["mcc"] ?? String.Empty,
                Version = VERSION_TWO,
                MerchantId = data["merchant_id"] ?? String.Empty,
                ClientIdentityNumber = data["client_identity_number"] ?? null
            };

            _unitOfWork.ApplicationDbContext.Add(model);

            return _unitOfWork.ApplicationDbContext.SaveChanges()>0;

        }
        
        



    }
}
