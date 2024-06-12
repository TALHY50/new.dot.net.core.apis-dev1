

using IMT.PayAll.Request.Common;

namespace IMT.PayAll.Common
{
    public static class BaseRequirement
    {
        // Server
        private const string Sandbox = "https://api.sandbox.payall.com";
        private const string Stage = "https://api.stage.payall.com";
        private const string Production = "https://api.payall.com";
        private const string LocalHost = "http://localhost:3001";

        // ClientId
        private const string SandboxClientId = "sandbox";
        private const string StageClientId = "https://api.stage.payall.com";
        private const string ProductionClientId = "https://api.payall.com";
        private const string LocalHostClientId = "local";

        // ClientSecret
        private const string SandboxClientSecret = "sandbox-Secret";
        private const string StageClientSecret = "https://api.stage.payall.com";
        private const string ProductionClientSecret = "https://api.payall.com";
        private const string LocalHostClientSecret = "local-Secret";

        public enum Servers{ Sandbox,Stage,Production,Local};

        public readonly static RequestOptions RequestOptions;

      
        public static RequestOptions GetBaseRequirement(string environment)
        {
            if(environment == Servers.Local.ToString())
            {
                return GetLocalBaseRequirement();
            }
            if(environment == Servers.Sandbox.ToString())
            {
                return GetSandboxBaseRequirement();
            }
            if(environment == Servers.Stage.ToString())
            {
                return GetStageBaseRequirement();
            }
            if(environment == Servers.Production.ToString())
            {
                return GetProductionBaseRequirement();
            }
            return new RequestOptions {  BaseUrl = Sandbox, ClientID = SandboxClientId, ClientSecret = SandboxClientSecret };
        }
        private static RequestOptions GetLocalBaseRequirement()
        {
            var RequestOptions = new RequestOptions();
            RequestOptions.BaseUrl = LocalHost;
            RequestOptions.ClientID = LocalHostClientId;
            RequestOptions.ClientSecret = LocalHostClientSecret;
            return RequestOptions;
        }
        private static RequestOptions GetSandboxBaseRequirement()
        {
            var RequestOptions = new RequestOptions();
            RequestOptions.BaseUrl = Sandbox;
            RequestOptions.ClientID = SandboxClientId;
            RequestOptions.ClientSecret = SandboxClientSecret;
            return RequestOptions;
        }
        private static RequestOptions GetStageBaseRequirement()
        {
            var RequestOptions = new RequestOptions();
            RequestOptions.BaseUrl = Stage;
            RequestOptions.ClientID = StageClientId;
            RequestOptions.ClientSecret = StageClientSecret;
            return RequestOptions;
        }
        private static RequestOptions GetProductionBaseRequirement()
        {
            var RequestOptions = new RequestOptions();
            RequestOptions.BaseUrl = Production;
            RequestOptions.ClientID = ProductionClientId;
            RequestOptions.ClientSecret = ProductionClientSecret;
            return RequestOptions;
        }


    }
}