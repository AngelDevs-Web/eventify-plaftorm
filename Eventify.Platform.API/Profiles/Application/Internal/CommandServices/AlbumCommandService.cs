using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Commands;
using Eventify.Platform.API.Profiles.Domain.Repositories;
using Eventify.Platform.API.Profiles.Domain.Services;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Profiles.Application.Internal.CommandServices;

public class AlbumCommandService(
    IAlbumRepository albumRepository,
    IUnitOfWork unitOfWork) : IAlbumCommandService
{
    public async Task<Album?> Handle(CreateAlbumCommand command)
    {
        if (command.Photos.Count() > 10) return null;
        var album = new Album(command);
        try
        {
            await albumRepository.AddAsync(album);
            await unitOfWork.CompleteAsync();
            return album;
        }
        catch
        {
            return null;
        }
    }
}