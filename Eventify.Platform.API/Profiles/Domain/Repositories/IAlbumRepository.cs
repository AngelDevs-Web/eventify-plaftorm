using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Profiles.Domain.Repositories;

public interface IAlbumRepository : IBaseRepository<Album>
{
    Task<IEnumerable<Album>> ListByProfileIdAsync(int profileId);
    Task<Album?> FindByIdAndProfileIdAsync(int albumId, int profileId);
}