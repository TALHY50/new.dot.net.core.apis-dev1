namespace SharedLibrary.Utilities;

public static class Url
{
    public static string GetFullUrl(string route)
    {
        return SharedLibrary.Constants.Constants.APP_DOMAIN + "/"+ route;
    }
    
}