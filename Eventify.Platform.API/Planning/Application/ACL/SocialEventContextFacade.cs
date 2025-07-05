using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Commands;
using Eventify.Platform.API.Planning.Domain.Model.Queries;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Planning.Domain.Services;
using Eventify.Platform.API.Planning.Interfaces.ACL;

namespace Eventify.Platform.API.Planning.Application.ACL;

public class SocialEventContextFacade : ISocialEventContextFacade
{
    private readonly ISocialEventCommandService _socialEventCommandService;
    private readonly ISocialEventQueryService _socialEventQueryService;

    public SocialEventContextFacade(ISocialEventCommandService socialEventCommandService, 
        ISocialEventQueryService socialEventQueryService)
    {
        _socialEventCommandService = socialEventCommandService;
        _socialEventQueryService = socialEventQueryService;
    }
    
    

    public async Task<string> CreateSocialEventAsync(string eventTitle, DateTime eventDate, string customerName,
        string location, EStatusType status)
    {
        var command = new CreateSocialEventCommand(eventTitle, eventDate, customerName, location, status);
        var result = await _socialEventCommandService.Handle(command);
        
        return result?.Id.IdSocialEvent.ToString() ?? string.Empty;
        
        
    }

    public async Task<SocialEvent?> GetSocialEventByIdAsync(int socialEventId)
    {
        var query = new GetSocialEventByIdQuery(socialEventId);
        return await _socialEventQueryService.Handle(query);
    }

    public async Task<IEnumerable<SocialEvent>> GetAllSocialEventsAsync()
    {
        var query = new GetAllSocialEventQuery();
        return await _socialEventQueryService.Handle(query);
    }

    public async Task<bool> UpdateSocialEventAsync(int socialEventId, string eventTitle, DateTime eventDate, string customerName, string location, EStatusType status)
    {
        var command = new UpdateSocialEventCommand(socialEventId, eventTitle, eventDate, customerName, location, status);
        var result = await _socialEventCommandService.Handle(command);
        return result != null;
    }

    public async Task<bool> DeleteSocialEventAsync(int socialEventId)
    {
        var command = new DeleteSocialEventCommand(socialEventId);
        await _socialEventCommandService.Handle(command);
        return true;
    }

    public async Task<IEnumerable<SocialEvent>> GetSocialEventsByCustomerNameAsync(string customerName)
    {
        var query = new GetSocialEventByCustomerQuery(customerName);
        return await _socialEventQueryService.Handle(query);
    }
}