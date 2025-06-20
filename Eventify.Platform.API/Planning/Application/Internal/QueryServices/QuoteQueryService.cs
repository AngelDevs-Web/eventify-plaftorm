using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Queries;
using Eventify.Platform.API.Planning.Domain.Repositories;
using Eventify.Platform.API.Planning.Domain.Services;

namespace Eventify.Platform.API.Planning.Application.Internal.QueryServices;

public class QuoteQueryService(IQuoteRepository quoteRepository):IQuoteQueryService
{
    public async Task<IEnumerable<Quote>> Handle(GetAllQuotesByOrganizerIdQuery query)
    {
        return await quoteRepository.FindByOrganizerIdAsync(query.OrganizerId);
    }

    public async Task<Quote?> Handle(GetQuoteByIdQuery query)
    {
        return await quoteRepository.FindByIdAsync(query.QuoteId);
    }
}