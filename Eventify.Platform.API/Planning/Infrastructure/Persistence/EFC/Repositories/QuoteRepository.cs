using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Planning.Domain.Repositories;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.Planning.Infrastructure.Persistence.EFC.Repositories;

public class QuoteRepository(AppDbContext context):BaseRepository<Quote>(context), IQuoteRepository
{
    public async Task<IEnumerable<Quote>> FindByOrganizerIdAsync(OrganizerId organizerId)
    {
        return await Context.Set<Quote>()
            .Where(quote => quote.OrganizerId == organizerId)
            .ToListAsync();
    }

    public new async Task<Quote?> FindByIdAsync(QuoteId quoteId)
    {
        return await Context.Set<Quote>().FirstOrDefaultAsync(quote => quote.Id == quoteId);
    }
}