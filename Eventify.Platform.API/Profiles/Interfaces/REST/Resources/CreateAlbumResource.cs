namespace Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

public record CreateAlbumResource(
    string Name,
    List<string> Photos);