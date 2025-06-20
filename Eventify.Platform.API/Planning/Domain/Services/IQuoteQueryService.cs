using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Queries;

namespace Eventify.Platform.API.Planning.Domain.Services;

public interface IQuoteQueryService
{
    public Task<IEnumerable<Quote>> Handle(GetAllQuotesByOrganizerIdQuery query);
    public Task<Quote?> Handle(GetQuoteByIdQuery query);
}