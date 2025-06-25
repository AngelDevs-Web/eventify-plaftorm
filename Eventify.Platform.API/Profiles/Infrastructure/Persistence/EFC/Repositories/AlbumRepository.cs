using Eventify.Platform.API.Profiles.Albums.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Repositories;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Eventify.Platform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class AlbumRepository(AppDbContext context) : BaseRepository<Album>(context), IAlbumRepository
{
}