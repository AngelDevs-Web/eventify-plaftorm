namespace Eventify.Platform.API.Profiles.Interfaces.REST.Resources;
using System.Collections.Generic;


/**
 * Represents the resource for updating an album.
 */

public record UpdateAlbumResource(
    string Name,
    List<string> Photos);