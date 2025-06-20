using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Planning.Domain.Repositories;

public interface IQuoteRepository:IBaseRepository<Quote>
{
    Task<IEnumerable<Quote>> FindByOrganizerIdAsync(OrganizerId organizerId);
    Task<Quote?> FindByIdAsync(QuoteId quoteId);
}