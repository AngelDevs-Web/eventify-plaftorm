using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Queries;

namespace Eventify.Platform.API.Profiles.Domain.Services;

public interface IAlbumQueryService
{
    Task<IEnumerable<Album>> Handle(GetAllAlbumsQuery query);
    Task<Album?> Handle(GetAlbumByIdQuery query);
}