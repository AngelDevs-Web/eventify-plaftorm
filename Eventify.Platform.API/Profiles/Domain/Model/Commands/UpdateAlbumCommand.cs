namespace Eventify.Platform.API.Profiles.Domain.Model.Commands;

using System.Collections.Generic;

/**
 * Represents a command to update an album.
 */
public record UpdateAlbumCommand(
    int ProfileId,
    int AlbumId,
    string Name,
    IEnumerable<string> Photos);