using DotNetEnv;
using PayAll.Common;

namespace PayAll.Sample
{
    public static class BaseSample
    {
        public static string ServerEnvironment = BaseRequirement.Servers.Local.ToString();

        public static string SetEnvironment()
        {
            Env.NoClobber().TraversePath().Load();
            return Env.GetString("Environment");
        }
     

    }
}