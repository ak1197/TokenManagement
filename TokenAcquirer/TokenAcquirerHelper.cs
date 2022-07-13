using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System;
using System.Threading.Tasks;

namespace TokenAcquirer
{
    public interface ITokenAcquirerHelper
    {
        Task<AuthenticationResult> GetTokenAsync();
    }
    public class TokenAcquirerHelper : ITokenAcquirerHelper
    {
        private static readonly string ClientId = "";
        private static readonly string TenantId = "";
        private static readonly string ClientSecret = "";
        private static readonly string Instance = "https://login.microsoftonline.com/{0}";

        public async Task<AuthenticationResult> GetTokenAsync()
        {
            // Congiguration as per the flow you are using
            var config = new AuthenticationConfig
            {
                ClientId = ClientId,
                Tenant = TenantId,
                ClientSecret = ClientSecret,
                Instance = Instance
            };


            IConfidentialClientApplication app;

            // Building the client application
            app = ConfidentialClientApplicationBuilder.Create(config.ClientId)
                .WithClientSecret(config.ClientSecret)
                .WithAuthority(new Uri(config.Authority))
                .Build();

            // Setting in-memory cache
            app.AddInMemoryTokenCache();

            // Setting scopes
            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };

            // Acquiring token
            AuthenticationResult result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return result;
        }
    }
}
