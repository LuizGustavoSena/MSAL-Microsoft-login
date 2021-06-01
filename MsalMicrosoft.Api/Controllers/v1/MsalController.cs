using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsalMicrosoft.Domain.Commands.v1.Login;
using System.Threading.Tasks;

namespace MsalMicrosoft.Api.Controllers.v1
{
    [Route("api/v1/mfal")]
    [ApiController]
    public class MsalController : ControllerBase
    {
        private readonly IMediator _mediatorService;

        public MsalController(IMediator mediatorService)
        {
            _mediatorService = mediatorService;
        }

        [HttpPost("login")]
        public Task<LoginCommandResponse> Login([FromBody] LoginCommand login)
        {
            return _mediatorService.Send(login);
        }
    }
}
