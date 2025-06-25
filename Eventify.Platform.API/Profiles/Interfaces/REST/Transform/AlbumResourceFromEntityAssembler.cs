using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Profiles.Interfaces.REST.Transform;

public class AlbumResourceFromEntityAssembler
{
    public static AlbumResource ToResourceFromEntity(Album entity)
    {
        var photos = entity.Photos.Select(p => p.Url);
        return new AlbumResource(entity.Id, entity.ProfileId, entity.Name, photos);
    }
}