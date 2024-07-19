using System.Net;
using Microsoft.AspNetCore.Http;

namespace SharedKernel.Main.Infrastructure.Services
{
#pragma warning disable CS8602 // Possible null reference argument.
    public interface IIpAddressService
    {
        string GetClientIpAddress();
        string GetMerchantServerIp();
        string GetRefererFromRequest(HttpRequest Request);
        IPAddress? GetMerchantServerIpFromRequest(HttpRequest Request);

    }
    public class IpAddressService(IHttpContextAccessor httpContextAccessor) : IIpAddressService
    {
        public string GetClientIpAddress()
        {
            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return ipAddress ?? "UNKNOWN";
        }

        //TODO: more about nginx- public function getServerIpAddress()
        public string GetMerchantServerIp()
        {
            string ipAddress = string.Empty;
            // Check if the request is coming from a proxy server
            if (httpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                // Get the list of IP addresses in the X-Forwarded-For header
                string forwardedForHeader = httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString();
                
                // Split the IP addresses and get the first one (client IP)
                ipAddress = forwardedForHeader.Split(',')[0].Trim();
            }
            else
            {
                // Get the remote IP address
                ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            
            return ipAddress;
        }
        
        
        public string GetRefererFromRequest(HttpRequest Request)
        {
            return Request.Headers["Referer"].ToString();
        }
        
        public IPAddress? GetMerchantServerIpFromRequest(HttpRequest Request)
        {
            return Request.HttpContext.Connection.LocalIpAddress;
        }

        
        

    }
}
