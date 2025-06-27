using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Commands;

namespace Eventify.Platform.API.Profiles.Domain.Services;

public interface IAlbumCommandService
{
    Task<Album?> Handle(CreateAlbumCommand command);
    Task<Album?> Handle(UpdateAlbumCommand command);
    Task<bool> Handle(DeleteAlbumCommand command);
}