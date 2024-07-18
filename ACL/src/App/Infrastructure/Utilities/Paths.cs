using System.Reflection;

namespace ACL.Application.Infrastructure.Utilities;

public class Paths
{
    
    public static string LogPath()
    {
        var mExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = mExePath;
        string searchString = "bin/";

        int index = (int)(path?.IndexOf(searchString)!);
            
        if (index != -1)
        {
            path = path.Substring(0, index-1);
                
        }
            
        path = path + "/Logs" ;

        return path;

    }
}