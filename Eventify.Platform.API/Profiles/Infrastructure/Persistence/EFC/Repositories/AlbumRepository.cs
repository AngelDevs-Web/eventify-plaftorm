using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Repositories;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class AlbumRepository(AppDbContext context) : BaseRepository<Album>(context), IAlbumRepository
{
    public async Task<IEnumerable<Album>> ListByProfileIdAsync(int profileId)
    {
        return await Context.Set<Album>()
            .Where(a => a.ProfileId == profileId)
            .ToListAsync();
    }

    public async Task<Album?> FindByIdAndProfileIdAsync(int albumId, int profileId)
    {
        return await Context.Set<Album>()
            .FirstOrDefaultAsync(a => a.Id == albumId && a.ProfileId == profileId);
    }
}