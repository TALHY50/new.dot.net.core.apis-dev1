using Microsoft.AspNetCore.Http;
using SharedLibrary.Services;

namespace SharedLibrary.Utilities
{
    public class Ip
    {
        protected readonly IIpAddressService IpAddressService;
        public Ip(IIpAddressService ipAddressService)
        {
            IpAddressService = ipAddressService;
        }

        public string ClientAddr()
        {
            return IpAddressService.GetClientIpAddress();
        }

        public bool IsLocal()
        {
            var host = ClientAddr();
            if (host == "::1" || host == "127.0.0.1" || host == "localhost" || host == "UNKNOWN")
            {
                return true;
            }
            return false;
        }
    }


}
