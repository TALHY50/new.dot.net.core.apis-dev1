using Microsoft.AspNetCore.Http;

namespace SharedLibrary.Utilities;

public class System
{
    public const int OS_UNKNOWN = 1;
    public const int OS_WIN = 2;
    public const int OS_LINUX = 3;
    public const int OS_OSX = 4;
    public const int OS_IOS = 5;
    public const int OS_ANDROID = 6;

    public static readonly Dictionary<int, string> DEVICE_LIST = new Dictionary<int, string>
    {
        { OS_UNKNOWN, "Unknown" },
        { OS_WIN, "Windows" },
        { OS_LINUX, "Linux" },
        { OS_OSX, "Mac" },
        { OS_IOS, "iOS" },
        { OS_ANDROID, "Android" }
    };

    public static int GetOS()
    {
        switch (Environment.OSVersion.Platform)
        {
            case PlatformID.MacOSX:
                return OS_OSX;
            case PlatformID.Win32NT:
            case PlatformID.Win32S:
            case PlatformID.Win32Windows:
            case PlatformID.WinCE:
                return OS_WIN;
            case PlatformID.Unix:
                return OS_LINUX;
            default:
                return OS_UNKNOWN;
        }
    }

    public static int GetClientDeviceId(IHttpContextAccessor httpContextAccessor)
    {
        int device_id = OS_UNKNOWN;
        string user_agent = httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();

        if (!string.IsNullOrEmpty(user_agent))
        {
            if (user_agent.Contains("linux"))
            {
                device_id = OS_LINUX;
            }
            else if (user_agent.Contains("macintosh") || user_agent.Contains("mac os x") || user_agent.Contains("mac_powerpc"))
            {
                device_id = OS_OSX;
            }
            else if (user_agent.Contains("windows") || user_agent.Contains("win32") || user_agent.Contains("win98") || user_agent.Contains("win95") || user_agent.Contains("win16"))
            {
                device_id = OS_WIN;
            }
            else if (user_agent.Contains("ipod") || user_agent.Contains("ipad") || user_agent.Contains("iphone"))
            {
                device_id = OS_IOS;
            }
            else if (user_agent.Contains("android"))
            {
                device_id = OS_ANDROID;
            }
        }

        return device_id;
    }
}