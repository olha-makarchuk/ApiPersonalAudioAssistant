using ApiPersonalAudioAssistant.Application.PlatformFeatures.Commands.MessageCommands;
using ApiPersonalAudioAssistant.Application.PlatformFeatures.Commands.SubUserCommands;
using ApiPersonalAudioAssistant.Application.PlatformFeatures.Queries.MessageQuery;
using ApiPersonalAudioAssistant.Application.PlatformFeatures.Queries.SubUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonalAudioAssistant.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SubUserController : BaseApiController
    {
        public SubUserController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> AddSubUser(AddSubUserCommand command)
        {
            return Ok(await Mediator.Send(command));//string Id
        }

        [HttpDelete("password")]
        public async Task<IActionResult> DeletePasswordSubUser(DeletePasswordSubUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubUser(DeleteSubUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("photo")]
        public async Task<IActionResult> UpdatePhoto(UpdatePhotoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubUser(UpdateSubUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("check-password")]
        public async Task<IActionResult> CheckSubUserPassword(CheckSubUserPasswordQuery command)
        {
            return Ok(await Mediator.Send(command)); // bool
        }

        [HttpPost("allusers")]
        public async Task<IActionResult> GetAllUsersByUserId(GetAllUsersByUserIdQuery command)
        {
            var subUsersList = await Mediator.Send(command);
            return Ok(subUsersList); 
        }

        [HttpPost("userbyid")]
        public async Task<IActionResult> GetUserById(GetUserByIdQuery command)
        {
            var subUser = await Mediator.Send(command);
            return Ok(subUser);
        }

        [HttpPost("userbystartphrase")]
        public async Task<IActionResult> GetUserByStartPhrase(GetUserByStartPhraseQuery command)
        {
            var subUser = await Mediator.Send(command);
            return Ok(subUser);
        }
    }
}
