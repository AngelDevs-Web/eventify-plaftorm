namespace Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

public record CreateAlbumResource(
    int ProfileId,
    string Name,
    List<string> Photos);