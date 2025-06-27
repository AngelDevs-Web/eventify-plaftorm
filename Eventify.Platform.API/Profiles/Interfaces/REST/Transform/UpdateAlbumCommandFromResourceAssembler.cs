using Eventify.Platform.API.Profiles.Domain.Model.Commands;
using Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Profiles.Interfaces.REST.Transform;

public class UpdateAlbumCommandFromResourceAssembler
{
    public static UpdateAlbumCommand ToCommandFromResource(int albumId, UpdateAlbumResource resource)
    {
        return new UpdateAlbumCommand(albumId, resource.Name, resource.Photos);
    }
}