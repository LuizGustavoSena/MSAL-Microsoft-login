using MediatR;

namespace MsalMicrosoft.Domain.Commands.v1.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
    }
}
