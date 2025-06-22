using Eventify.Platform.API.Operation.Domain.Model.Aggregates;
using Eventify.Platform.API.Operation.Domain.Repositories;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.Operation.infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository (AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{
    public new async Task<Review?> FindByIdAsync(int id)
    {
        return await Context.Set<Review>()
            .FirstOrDefaultAsync(review => review.Id == id);
    }

    public new async Task<IEnumerable<Review>> ListAsync()
    {
        return await Context.Set<Review>()
            .ToListAsync();
    }
}