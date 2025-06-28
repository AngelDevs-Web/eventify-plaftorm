using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Planning.Domain.Repositories;

public interface IServiceItemRepository:IBaseRepository<ServiceItem>
{
    Task<IEnumerable<ServiceItem>> FindByQuoteIdAsync(QuoteId quoteId);
    
    Task<ServiceItem?> FindByIdAsync(ServiceItemId serviceItemId);
}