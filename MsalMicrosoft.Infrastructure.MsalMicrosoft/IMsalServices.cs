using System.Threading.Tasks;

namespace MsalMicrosoft.Infrastructure.MsalMicrosoft
{
    public interface IMsalServices
    {
        Task<string> GetTokenMicrosoftAccount();
        Task<string> GetDisplayNomeWithTokenMicrosoftAccount(string token);
    }
}
