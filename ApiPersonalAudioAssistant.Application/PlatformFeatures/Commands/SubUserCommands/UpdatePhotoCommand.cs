using MediatR;
using ApiPersonalAudioAssistant.Application.Interfaces;
using ApiPersonalAudioAssistant.Application.Services;
using System;

namespace ApiPersonalAudioAssistant.Application.PlatformFeatures.Commands.SubUserCommands
{
    public class UpdatePhotoCommand : IRequest<Unit>
    {
        public string PhotoURL { get; set; }
        public string PhotoPath { get; set; }
    }

    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, Unit>
    {
        private readonly ISubUserRepository _subUserRepository;
        private readonly IBlobStorage _blobStorage;

        public UpdatePhotoCommandHandler(ISubUserRepository subUserRepository, IBlobStorage blobStorage)
        {
            _subUserRepository = subUserRepository;
            _blobStorage = blobStorage;
        }

        public async Task<Unit> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken = default)
        {
            if (request.PhotoPath != null && request.PhotoURL != null)
            {
                using var stream = System.IO.File.OpenRead(request.PhotoPath);
                string fileName = $"{Path.GetFileName(request.PhotoURL)}";
                var a = await _blobStorage.FileExistsAsync(fileName, BlobContainerType.UserImage);

                await _blobStorage.DeleteAsync(fileName, BlobContainerType.UserImage);
                //a = await _blobStorage.FileExistsAsync(fileName, BlobContainerType.UserImage);

                await _blobStorage.PutContextAsync(fileName, stream, BlobContainerType.UserImage);
            }
            return Unit.Value;
        }
    }
}
