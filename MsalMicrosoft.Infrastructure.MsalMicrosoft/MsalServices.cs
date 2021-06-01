using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using MsalMicrosoft.CrossCutting;
using System;
using System.Threading.Tasks;
using Flurl.Http;

namespace MsalMicrosoft.Infrastructure.MsalMicrosoft
{
    public class MsalServices : IMsalServices
    {
        private readonly IOptions<AppSettings> _appSettings;

        public MsalServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;

        }

        public async Task<string> GetTokenMicrosoftAccount()
        {
            Uri authority = new Uri(_appSettings.Value.Azure.AuthorityUrl + _appSettings.Value.Azure.DirectoryId);

            IPublicClientApplication publicClient = PublicClientApplicationBuilder
                .Create(_appSettings.Value.Azure.ClientId)
                .WithAuthority(authority)
                .WithRedirectUri(_appSettings.Value.Azure.RedirectUrl)
                .Build();

            string[] scopes = new string[] { _appSettings.Value.Azure.Scope };

            AuthenticationResult result = await publicClient.AcquireTokenInteractive(scopes).ExecuteAsync();

            return result.AccessToken;
        }

        public Task<string> GetDisplayNomeWithTokenMicrosoftAccount(string token)
        {
            var resultJson =_appSettings.Value.Azure.InformationUrl
                                .WithOAuthBearerToken(token)
                                .GetStringAsync();
            return resultJson;
        }
    }
}
