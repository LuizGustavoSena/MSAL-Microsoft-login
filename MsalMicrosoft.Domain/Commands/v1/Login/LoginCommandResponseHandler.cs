using MediatR;
using MsalMicrosoft.Infrastructure.MsalMicrosoft;
using System.Threading;
using System.Threading.Tasks;

namespace MsalMicrosoft.Domain.Commands.v1.Login
{
    public class LoginCommandResponseHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IMsalServices _msalServices;

        public LoginCommandResponseHandler(IMsalServices msalServices)
        {
            _msalServices = msalServices;
        }
        
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _msalServices.GetTokenMicrosoftAccount();
            var response = new LoginCommandResponse
            {
                Token = token,
                InformationAccotun = await _msalServices.GetDisplayNomeWithTokenMicrosoftAccount(token)
            };

            return response; 
        }
    }
}
