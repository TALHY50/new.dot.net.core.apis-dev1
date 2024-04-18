using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace ACL.Utilities;

public class Paths
{
    
    public static string logPath()
    {
        var m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = m_exePath;
        string searchString = "bin/";

        int index = path.IndexOf(searchString);
            
        if (index != -1)
        {
            path = path.Substring(0, index-1);
                
        }
            
        path = path + "/Logs" ;

        return path;

    }
}