using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Queries;
using Eventify.Platform.API.Profiles.Domain.Repositories;
using Eventify.Platform.API.Profiles.Domain.Services;

namespace Eventify.Platform.API.Profiles.Application.Internal.QueryServices;

public class AlbumQueryService(
    IAlbumRepository albumRepository
) : IAlbumQueryService
{
    public async Task<IEnumerable<Album>> Handle(GetAllAlbumsQuery query)
    {
        return await albumRepository.ListAsync();
    }

    public async Task<Album?> Handle(GetAlbumByIdQuery query)
    {
        return await albumRepository.FindByIdAsync(query.AlbumId);
    }
    public async Task<IEnumerable<Album>> Handle(GetAlbumsByProfileIdQuery query)
    {
        return await albumRepository.ListByProfileIdAsync(query.ProfileId);
    }

    public async Task<Album?> Handle(GetAlbumByIdForProfileQuery query)
    {
        return await albumRepository.FindByIdAndProfileIdAsync(query.AlbumId, query.ProfileId);
    }
}
