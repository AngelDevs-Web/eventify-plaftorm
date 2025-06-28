using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Queries;
using Eventify.Platform.API.Planning.Domain.Repositories;
using Eventify.Platform.API.Planning.Domain.Services;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Planning.Application.Internal.QueryServices;

public class ServiceItemQueryService(IServiceItemRepository serviceItemRepository, IUnitOfWork unitOfWork):IServiceItemQueryService
{
    public async Task<ServiceItem?> Handle(GetServiceItemByIdQuery query)
    {
        return await serviceItemRepository.FindByIdAsync(query.ServiceItemId);
    }

    public async Task<IEnumerable<ServiceItem>> Handle(GetAllServiceItemsByQuoteIdQuery query)
    {
        return await serviceItemRepository.FindByQuoteIdAsync(query.QuoteId);
    }
}