using System.Collections.Generic;
using System.Linq;
using Eventify.Platform.API.Profiles.Domain.Model.Commands;
using Eventify.Platform.API.Profiles.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;

public class Album
{
    public int Id { get; }
    public int ProfileId { get; private set; }
    public string Name { get; private set; }
    public List<PhotoUrl> Photos { get; private set; }

    public Album()
    {
        Name = string.Empty;
        Photos = new List<PhotoUrl>();
    }

    public Album(int profileId, string name, IEnumerable<string> photos)
    {
        ProfileId = profileId;
        Name = name;
        Photos = photos.Select(url => new PhotoUrl(url)).ToList();
    }

    public Album(CreateAlbumCommand command) : this(command.ProfileId, command.Name, command.Photos)
    {
    }
    public void Update(string name, IEnumerable<string> photos)
    {
        Name = name;
        Photos = photos.Select(url => new PhotoUrl(url)).ToList();
    }
}