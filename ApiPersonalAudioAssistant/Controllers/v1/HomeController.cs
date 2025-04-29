using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonalAudioAssistant.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HomeController : BaseApiController
    {
        public HomeController(IMediator mediator) : base(mediator) { }

        [HttpGet("voices")]
        public async Task<IActionResult> GetAllVoices(string UserId)
        {
            var cmd = new GetAllVoicesByUserIdQuery
            {
                UserId = UserId
            };

            return Ok(await Mediator.Send(cmd));
        }

        [HttpGet("subusers")]
        public async Task<IActionResult> GetSubUsers(string UserId)
        {
            var cmd = new GetUserByIdQuery
            {
                UserId = UserId
            };

            return Ok(await Mediator.Send(cmd));
        }
    }
}
