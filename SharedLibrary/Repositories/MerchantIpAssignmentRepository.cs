using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class MerchantIpAssignmentRepository : GenericRepository<MerchantIpAssignment>
{
    public MerchantIpAssignmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    
    
    public List<MerchantIpAssignment> GetIpAssignment(int merchantId, int type = MerchantIpAssignment.SALE_IP_RESTICTION)
    {
        return UnitOfWork.ApplicationDbContext.MerchantIpAssaignments.AsNoTracking()
            .Where(x => x.MerchantId == merchantId)
            .Where(x => x.Type == type)
            .Where(x => x.IpBlockType == MerchantIpAssignment.IP_BLOCK_TYPE_WHITELIST).ToList();
    }


    public MerchantIpAssignment? FindIsBlockedIp(string ip)
    {
        var merchantIpAssignment = UnitOfWork.ApplicationDbContext.MerchantIpAssaignments
            .Where(x => x.AssignedIp == ip)
            .Where(x => x.IpSourceType == MerchantIpAssignment.IP_SOURCE_TYPE_USER)
            .First(x => x.IpBlockType == MerchantIpAssignment.IP_BLOCK_TYPE_BLACKLIST);

        return merchantIpAssignment;
    }
    
    
    /*
     *     public function getIpListByMerchantId($merchant_id, $type = self::SALE_IP_RESTICTION){
        return $this->where('merchant_id',$merchant_id)
                ->where('type',$type)
                ->where('ip_block_type', self::IP_BLOCK_TYPE_WHITELIST)
                ->pluck('assigned_ip');
    }
     */

    public List<MerchantIpAssignment> GetIpListByMerchantId(int merchantId, int type = MerchantIpAssignment.SALE_IP_RESTICTION)
    {
        var ipList = UnitOfWork.ApplicationDbContext.MerchantIpAssaignments
            .Where(x => x.Type == type)
            .Where(x => x.IpBlockType == MerchantIpAssignment.IP_BLOCK_TYPE_WHITELIST)
            .ToList();

        return ipList;

    }

}