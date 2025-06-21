using System;
using System.Linq;
using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Eventify.Platform.API.SocialEvents.Domain.Model.Queries;
using Eventify.Platform.API.SocialEvents.Domain.Repositories;
using Eventify.Platform.API.SocialEvents.Domain.Services;

namespace Eventify.Platform.API.SocialEvents.Application.Internal.QueryServices;

public class SocialEventQueryService : ISocialEventQueryService
{
    private readonly ISocialEventRepository _socialEventRepository;

    public SocialEventQueryService(ISocialEventRepository socialEventRepository)
    {
        _socialEventRepository = socialEventRepository;
    }

    public async Task<IEnumerable<SocialEvent>> Handle(GetAllSocialEventQuery query)
    {
        return await _socialEventRepository.ListAsync();
    }

    public async Task<SocialEvent?> Handle(GetSocialEventByIdQuery query)
    {
        return await _socialEventRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByCustomerQuery query)
    {
        var allEvents = await _socialEventRepository.ListAsync();
        return allEvents.Where(se => se.NameCustomer.NameCustomer.Contains(query.CustomerName, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByLocationQuery query)
    {
        var allEvents = await _socialEventRepository.ListAsync();
        return allEvents.Where(se => se.Location.Contains(query.Location , StringComparison.OrdinalIgnoreCase));
        
    }

    public async Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByTitleQuery query)
    {
        var allEvents = await _socialEventRepository.ListAsync();
        return allEvents.Where(se => se.EventTitle.Contains(query.EventTitle, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<SocialEvent>> Handle(GetSocialEventByStatusQuery query)
    {
        var allEvents = await _socialEventRepository.ListAsync();
        return allEvents.Where(se => se.Status == query.Status);
    }
}