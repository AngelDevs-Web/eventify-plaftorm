namespace Eventify.Platform.API.Profiles.Domain.Model.Commands;

public record CreateAlbumCommand(
    int ProfileId,
    string Name,
    IEnumerable<string> Photos);