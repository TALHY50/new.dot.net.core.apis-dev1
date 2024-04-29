using DotNetEnv;
using SharedLibrary.Utilities;

namespace SharedLibrary.Constants
{
   
    public static partial class Constants
    {
        public static readonly string BRAND_SECRET_KEY = Env.GetString("BRAND_SECRET_KEY", "@hnis!hsk@nos");
        


    }
}