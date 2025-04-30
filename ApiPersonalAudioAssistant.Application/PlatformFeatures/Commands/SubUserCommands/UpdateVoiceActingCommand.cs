using ApiPersonalAudioAssistant.Application.Interfaces;
using MediatR;

namespace ApiPersonalAudioAssistant.Application.PlatformFeatures.Commands.SubUserCommands
{
    public class UpdateVoiceActingCommand : IRequest<Unit>
    {
        public string? Id { get; set; }
        public string? VoiceId { get; set; }
    }

    public class UpdateVoiceActingCommandHandler : IRequestHandler<UpdateVoiceActingCommand, Unit>
    {
        private readonly ISubUserRepository _subUserRepository;

        public UpdateVoiceActingCommandHandler(ISubUserRepository subUserRepository)
        {
            _subUserRepository = subUserRepository;
        }

        public async Task<Unit> Handle(UpdateVoiceActingCommand request, CancellationToken cancellationToken = default)
        {
            var userExist = await _subUserRepository.GetUserByIdAsync(request.Id, cancellationToken);

            if (userExist == null)
            {
                throw new Exception("Користувача не знайдено");
            }

            userExist.VoiceId = request.VoiceId;

            await _subUserRepository.UpdateUser(userExist, cancellationToken);
            return Unit.Value;
        }
    }
}
