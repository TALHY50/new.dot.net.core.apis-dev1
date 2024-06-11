using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using NUnit.Framework;

namespace IMT.PayAll.Sample
{
    public static class BaseSample
    {
        public static string ServerEnvironment = "Local";

        public static string SetEnvironment()
        {
            Env.NoClobber().TraversePath().Load();
            return Env.GetString("Environment");
        }
     

    }
}