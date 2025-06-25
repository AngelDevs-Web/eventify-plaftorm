using Eventify.Platform.API.Profiles.Domain.Model.Commands;
using Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Profiles.Interfaces.REST.Transform;

public class CreateAlbumCommandFromResourceAssembler
{
    public static CreateAlbumCommand ToCommandFromResource(CreateAlbumResource resource)
    {
        return new CreateAlbumCommand(resource.ProfileId, resource.Name, resource.Photos);
    }
}