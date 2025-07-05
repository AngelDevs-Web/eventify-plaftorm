namespace Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

public record AlbumResource(
    int Id,
    int ProfileId,
    string Name,
    IEnumerable<string> Photos);